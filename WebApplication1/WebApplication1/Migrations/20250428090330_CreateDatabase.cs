using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pavlova_Anastasia_KT_42_22.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicDegree",
                columns: table => new
                {
                    academic_degree_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи ученой степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_academic_degree_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Наименование ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academic_degree_academic_degree_id", x => x.academic_degree_id);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи дисциплины")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_вiscipline_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Наименование дисциплины")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_disciplinep_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "JobPosition",
                columns: table => new
                {
                    job_position_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи ученой должности преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_academic_degree_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Наименование должности")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_job_position_job_position_id", x => x.job_position_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_department",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи кафедры")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_department_name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Наименование кафедры"),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_department_id", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teacher",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_teacher_firstname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    c_teacher_lastname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    c_teacher_middlename = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Отчество"),
                    AcademicDegreeId = table.Column<int>(type: "int", nullable: false),
                    JobPositionId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teacher_teacher_id", x => x.teacher_id);
                    table.ForeignKey(
                        name: "fk_f_academic_degree_id",
                        column: x => x.AcademicDegreeId,
                        principalTable: "AcademicDegree",
                        principalColumn: "academic_degree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_department_id",
                        column: x => x.DepartmentId,
                        principalTable: "cd_department",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_job_position_id",
                        column: x => x.JobPositionId,
                        principalTable: "JobPosition",
                        principalColumn: "job_position_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_work_load",
                columns: table => new
                {
                    work_load_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи рабочей программы")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    DisciplineId = table.Column<int>(type: "int", nullable: false),
                    c_hours = table.Column<int>(type: "int", nullable: false, comment: "количество часов")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_work_load_work_load_id", x => x.work_load_id);
                    table.ForeignKey(
                        name: "fk_f_discipline_id",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_teacher_id",
                        column: x => x.TeacherId,
                        principalTable: "cd_teacher",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_department_fk_f_teacher_id",
                table: "cd_department",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_department_TeacherId",
                table: "cd_department",
                column: "TeacherId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_f_academic_degree_id",
                table: "cd_teacher",
                column: "AcademicDegreeId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_f_department_id",
                table: "cd_teacher",
                column: "AcademicDegreeId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_teacher_fk_f_job_position_id",
                table: "cd_teacher",
                column: "AcademicDegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_DepartmentId",
                table: "cd_teacher",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_teacher_JobPositionId",
                table: "cd_teacher",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_work_load_fk_f_discipline_id",
                table: "cd_work_load",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_work_load_fk_f_teacher_id",
                table: "cd_work_load",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_work_load_DisciplineId",
                table: "cd_work_load",
                column: "DisciplineId");

            migrationBuilder.AddForeignKey(
                name: "fk_leader_id",
                table: "cd_department",
                column: "TeacherId",
                principalTable: "cd_teacher",
                principalColumn: "teacher_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_leader_id",
                table: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_work_load");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "cd_teacher");

            migrationBuilder.DropTable(
                name: "AcademicDegree");

            migrationBuilder.DropTable(
                name: "cd_department");

            migrationBuilder.DropTable(
                name: "JobPosition");
        }
    }
}
