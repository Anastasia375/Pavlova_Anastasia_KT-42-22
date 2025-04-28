namespace Pavlova_Anastasia_KT_42_22.Models
{
    public class WorkLoad
    {
        public int WorkLoadId { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public int Hours { get; set; } 
    }
}
