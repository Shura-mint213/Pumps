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

using File = Shared.Models.Tabels.File;

namespace Database
{
    public class PumpsContext : DbContext
    {
        /// <summary>
        /// Строка подключения к БД
        /// </summary>
        private readonly string _connectionString;
        private readonly StreamWriter _logStream;
        /// <summary>
        /// Название файла для логов
        /// </summary>
        private const string _fileNameLog = "errorDbLog.txt";
        // Объекты БД
        internal virtual DbSet<Pump> Pumps { get; set; }
        internal virtual DbSet<File> Files { get; set; }
        internal virtual DbSet<FileExtension> FileTypes { get; set; }
        internal virtual DbSet<Material> Materials { get; set; }
        internal virtual DbSet<SourceType> Sources { get; set; }
        internal virtual DbSet<Detail> Details { get; set; }
        internal virtual DbSet<PumpDetail> PumpDetails { get; set; }
        //internal DbSet<FileToTable> FileToTables { get; set; }


        public PumpsContext() : this(Settings.ConnectionString) { }

        public PumpsContext(DbContextOptions<PumpsContext> options) : base(options) { }

        public PumpsContext(string connectionString)
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
                // Настраиваем подключение
                if (string.IsNullOrEmpty(_connectionString))
                {
                    optionsBuilder.UseSqlServer(_connectionString);
                }
                // логирование
                optionsBuilder.LogTo(_logStream.WriteLine, LogLevel.Error);
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Заполняем бд тестовыми данными
            #region Materials
            modelBuilder.Entity<Material>().HasData(
                new Material() { MaterialId = 1, Name = "Сталь", Description = "Сталь (от нем. Stahl)[1] — сплав железа с углеродом (и другими элементами периодической таблицы), содержащий не менее 45 % железа и в котором содержание углерода находится в диапазоне от 0,02 до 2,14 %, причём содержанию от 0,6 % до 2,14 % соответствует высокоуглеродистая сталь." },
                new Material() { MaterialId = 2, Name = "Чугун", Description = "Чугу́н — сплав железа с углеродом (и другими элементами), в котором содержание углерода — не менее 2,14 % (точка предельной растворимости углерода в аустените на диаграмме состояний), а сплавы с содержанием углерода менее 2,14 % называются сталью. Углерод придаёт сплавам железа твёрдость, снижая пластичность и вязкость." },
                new Material() { MaterialId = 3, Name = "Нержавеющая сталь", Description = "Нержавеющая сталь (коррозионно-стойкие стали, в просторечье «нержавейка») — легированная сталь, устойчивая к коррозии в атмосфере и агрессивных средах, обладающая термостойкими свойствами[1][2]. Различные марки нержавеющей стали включают хром, никель, углерод, азот, алюминий, кремний, серу, титан, медь, селен, ниобий и молибден[3]. Однако, в условиях, например, солевого тумана и морской воды, а также при нарушении технологии сварки и термической обработки, и нержавеющая сталь подвергается коррозии." },
                new Material() { MaterialId = 4, Name = "Бронза", Description = "Бро́нза — сплав меди, обычно с оловом в качестве основного компонента, но к бронзам также относят медные сплавы с алюминием, кремнием, бериллием, свинцом и другими элементами, за исключением цинка (это латунь), никеля (это мельхиор), цинка и никеля (это нейзильбер). Как правило, в любой бронзе в незначительных количествах присутствуют добавки: цинк, свинец, фосфор и другие." },
                new Material() { MaterialId = 5, Name = "Керамики", Description = "Кера́мика (др.-греч. κέραμος — глина) — материалы, изготавливаемые из глин или их смесей с минеральными добавками (а иногда из других неорганических соединений) под воздействием высокой температуры с последующим охлаждением; а также изделия из таких материалов[." });
            #endregion

            #region Details 
            modelBuilder.Entity<Detail>()
                .Property(k => k.DetailId)
                .ValueGeneratedNever();

            modelBuilder.Entity<Detail>().HasData(
                new Detail() { DetailId = 1, Name = "Приводной вал"},
                new Detail() { DetailId = 2, Name = "Сальник вала"},
                new Detail() { DetailId = 3, Name = "Лопастное колесо" },
                new Detail() { DetailId = 4, Name = "Корпус насоса" },
                new Detail() { DetailId = 5, Name = "Подшипник" },
                new Detail() { DetailId = 6, Name = "Опорный вал" },
                new Detail() { DetailId = 7, Name = "Рабочее колесо" });
            #endregion

            #region File extension
            modelBuilder.Entity<FileExtension>()
                .Property(k => k.FileExtensionId)
                .ValueGeneratedNever();

            modelBuilder.Entity<FileExtension>().HasData(
                new FileExtension() { FileExtensionId = 1, Name = "jpg" },
                new FileExtension() { FileExtensionId = 2, Name = "png" },
                new FileExtension() { FileExtensionId = 3, Name = "zip" },
                new FileExtension() { FileExtensionId = 4, Name = "jpeg" },
                new FileExtension() { FileExtensionId = 5, Name = "pdf" },
                new FileExtension() { FileExtensionId = 6, Name = "rar" },
                new FileExtension() { FileExtensionId = 7, Name = "7z" });
            #endregion

            #region File types
            modelBuilder.Entity<SourceType>().HasData(
                new SourceType() { SourcesId = 1, Name = "Файл на сервере", Description = "Файлы хронятся на сервере" },
                new SourceType() { SourcesId = 2, Name = "Файл на Яндекс облаке", Description = "Файлы хронятся на в яндекс облаке" },
                new SourceType() { SourcesId = 3, Name = "Файл в Google облаке", });
            #endregion

            #region Pumps 
            modelBuilder.Entity<Pump>(p =>
            {
                p.Property(k => k.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Pump>().HasData(
                new Pump() { PumpId = 1, Name = "Поверхностный насос ПН-900 Вихрь", MaxPressure = 45F, Price = 11_980M, Weight = 25F, MaxLiquidTemperature = 50F, Description = "Поверхностный насос предназначен для подачи под давлением чистой воды в дом, для орошения сада и огорода.\r\n\r\nВода не должна содержать абразивных или волокнистых, а также химических составных частей, которые могли бы повредить материал деталей насоса." });
            #endregion

            #region Pump details
            modelBuilder.Entity<PumpDetail>().HasData(
                new PumpDetail() { PumpDetailId = 1, DetailId = 1, MaterialId = 1, PumpId = 1 }, 
                new PumpDetail() { PumpDetailId = 2, DetailId = 2, MaterialId = 1, PumpId = 1 }, 
                new PumpDetail() { PumpDetailId = 3, DetailId = 3, MaterialId = 2, PumpId = 1 }, 
                new PumpDetail() { PumpDetailId = 4, DetailId = 4, MaterialId = 3, PumpId = 1 }, 
                new PumpDetail() { PumpDetailId = 5, DetailId = 5, MaterialId = 4, PumpId = 1 }, 
                new PumpDetail() { PumpDetailId = 6, DetailId = 6, MaterialId = 1, PumpId = 1 });
            #endregion

            #region File
            modelBuilder.Entity<File>().HasData(
                new File() { FilesId = 1, Name = "5422_big", OriginalName = "5422_big.jpg", Path = Paths.FilePathPumps, ExtensionId = 1, Created = DateTime.Now, SourceTypeId = 1, },
                new File() { FilesId = 2, Name = "poverxnostnyij-nasos-pn-900che-vixr", OriginalName = "poverxnostnyij-nasos-pn-900che-vixr.jpg", Path = Paths.FilePathPumps, ExtensionId = 1, Created = DateTime.Now, SourceTypeId = 1, });
            #endregion

            #region Pump file
            modelBuilder.Entity<PumpFile>().
                HasKey(f => new { f.FileId, f.PumpId });

            modelBuilder.Entity<PumpFile>().HasData(
                new PumpFile() { FileId = 1, PumpId = 1 },
                new PumpFile() { FileId = 2, PumpId = 1 });
            #endregion

        }

        public override void Dispose()
        {
            base.Dispose();
            //_logStream.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            //await _logStream.DisposeAsync();
        }
    }
}
