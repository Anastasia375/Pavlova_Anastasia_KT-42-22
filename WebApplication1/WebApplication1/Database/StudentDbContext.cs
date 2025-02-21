using Microsoft.EntityFrameworkCore

    namespace Pavlova_Anastasia_KT_42_22
{
    public class StudentDbcontext : DbContext
    {
        public StudentDbcontext(DbContextOptions<StudentDbcontext> options)
        {

        }
    }
}
