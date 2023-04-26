using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var student = new Student();
            student.FirstName = "Aleksandr";
            student.LastName = "Derivolkov";
            student.Age = 16;
            student.KlassRank = 9;

            var gr1 = new Grade()
            {
                Name = "Mathematika",
                Value= 5.73,
                Teachername = "Chervenkova",
                ImportanceFactor= 100
            };

            Grade gr2 = new Grade();
            gr2.Name = "Bulgarski Ezik";
            gr2.Value = 4.49;
            gr2.Teachername = "Yaneva";
            gr2.ImportanceFactor = 78;

            Grade gr3 = new Grade("Biology", "Matev", 6.00, 60);

            student.AddGrade(gr1);

        }
    }
    public class Student
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }=true;
        public int KlassRank { get; set; }
        public List<Grade> GradeBook { get; set; } = new List<Grade>();

        public void AddGrade(Grade grade)
        {
            if (grade.Value > 6 || grade.Value < 2)
            {
                Console.WriteLine("Sorry your grade is not valid it has to be between 2-6");
                return;
            }
            GradeBook.Add(grade);
        }
    }

    public class Grade
    {
        public Grade()
        {

        }
        public Grade(string name,string teachername,double value,int importanceFactor)
        {
            Name = name;
            Teachername = teachername;
            Value = value;
            ImportanceFactor = importanceFactor;
        }

        public string Name { get; set; }
        public string Teachername { get; set; }
        public double Value { get; set; }
        public int ImportanceFactor { get; set; }
        public DateTime CreateData { get; set; }
    }


}
