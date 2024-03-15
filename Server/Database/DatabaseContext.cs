using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using Shared.Models.Tabels;
using Shared.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        private readonly string _connectionString;
        private readonly StreamWriter _logStream;
        /// <summary>
        /// Название файла для логов
        /// </summary>
        private const string _fileNameLog = "errorDbLog.text";
        // Объекты БД
        internal DbSet<Pump> Pumps { get; set; }
        internal DbSet<Shared.Models.Tabels.File> Files { get; set; }
        internal DbSet<FileType> FileTypes { get; set; }
        internal DbSet<Material> Materials { get; set; }
        internal DbSet<Motor> Motors { get; set; }
        internal DbSet<SourceType> Sources { get; set; }
        internal DbSet<Detail> Details { get; set; }
        internal DbSet<PumpDetail> PumpDetails { get; set; }
        internal DbSet<FileToTable> FileToTables { get; set; }


        public DatabaseContext() : this(Settings.ConnectionString) { }  

        public DatabaseContext(string connectionString)
        {
            _connectionString = connectionString;
            _logStream = new StreamWriter(_fileNameLog, true);
            // Проверяем наличие БД, если нет создаем
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Настраиваем
                // подключение
                optionsBuilder.UseNpgsql(_connectionString);
                // логирование
                optionsBuilder.LogTo(_logStream.WriteLine, LogLevel.Error);
                ModelBuilder builder = new ModelBuilder();
                
                //base.OnModelCreating(optionsBuilder);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            _logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _logStream.DisposeAsync();
        }
    }
}
