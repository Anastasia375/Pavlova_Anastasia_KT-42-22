using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


using Pavlova_Anastasia_KT_42_22.Database.Helpers;
using Pavlova_Anastasia_KT_42_22.Models;

namespace Pavlova_Anastasia_KT_42_22.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_discipline";
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            //Задаем первичный ключ
            builder
            .HasKey(p => p.DisciplineId)
                .HasName($"pk_{TableName}_disciplinep_id");

            //Для целочисленного первичного ключа задаем автогенерацию
            builder.Property(p => p.DisciplineId)
                .ValueGeneratedOnAdd();

            //Расписываем, как будут называться колонки в БД, а также их обязательность
            builder.Property(p => p.DisciplineId)
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор записи дисциплины");

            builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnName("c_вiscipline_name")
            .HasColumnType(ColumnType.String).HasMaxLength(100)
            .HasComment("Наименование дисциплины");
        }
    }
}
