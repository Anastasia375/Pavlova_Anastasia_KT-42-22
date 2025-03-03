using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pavlova_Anastasia_KT_42_22.Database.Helpers;
using Pavlova_Anastasia_KT_42_22.Models;
namespace Pavlova_Anastasia_KT_42_22.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");

            //Для целочисленного первичного ключа задаем автогенерацию
            builder.Property(p => p.StudentId)
                .ValueGeneratedOnAdd();

            //Расписываем, как будут называться колонки в БД, а также их обязательность
            builder.Property(p = p => p.StudentId)
                .HasColumnName("student_id")
                .HasComment("Идентификатор записи студента");

            builder.Property(p => p.FirstName)
            .IsRequired()
            .HasColumnName("c_student_firstname")
            .HasColumnType(ColumnType.String).HasMaxLength(100)
            .HasComment("Имя студента");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия студента");

            builder.Property(p => p.MiddleName)
                .HasColumnName("c_student_middlename")
                .HasComment("Отчество");

            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("fk_f_group_id");

            //Добавляем явную автоподгрузку связанной сущности
            builder.Navigation(p => p.Group)
                .AutoInclude();
                
        }
    }
    public void class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "cd_group";
        public void Configure(IEntityTypeBuilder<Group> builder)
        {
            //Задаем первичный ключ
            builder
            .HasKey(p => p.GroupId)
                .HasName($"pk_{TableName}_group_id");

            //Для целочисленного первичного ключа задаем автогенерацию
            builder.Property(p => p.GroupId)
                .ValueGeneratedOnAdd();

            //Расписываем, как будут называться колонки в БД, а также их обязательность
            builder.Property(p = p => p.GroupId)
                .HasColumnName("group_id")
                .HasComment("Идентификатор записи группы");

            builder.Property(p => p.GroupName)
            .IsRequired()
            .HasColumnName("c_student_groupname")
            .HasColumnType(ColumnType.String).HasMaxLength(100)
            .HasComment("Наименование группы");
        }
    }
}
