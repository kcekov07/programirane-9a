using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using oppbd2.Models;
using System.Globalization;

namespace oppbd2
{
    internal class Program
    {


        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("=========================================");
                Console.WriteLine("Hello,what do you want to do? \n1)List all students and their class  \n2)Check student \n3)Add new student \n4)End");
                Console.WriteLine("=========================================");
                int choise = int.Parse(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        {
                            ListAllMembersInfoData();
                            break;
                        }
                    case 2:
                        {
                            CheckStudent();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Members account balances management was not yet implemented");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Members account balances management was not yet implemented");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choise option number!");
                        }
                        break;
                }
            }
        }


        private static void ListAllMembersInfoData()
        {
            Console.WriteLine("Listing All Students and their class");
            Student[] student = null;

            using (var db = new SchoolDBContext())
            {
                student= db.Students.Include(s => s.Class).ToArray();
            }

            foreach (var s in student)
            {
                string data = s.GetInfo();
                Console.WriteLine(data);
                Console.WriteLine();
                Thread.Sleep(1000);
            }
        }

        private static void CheckStudent()
        {

           

            using (var db = new SchoolDBContext())
            {
                
            }


            Console.WriteLine("\nВъведете номер на ученик за повече информация:");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                var selectedStudent = db.Students
                    .Where(s => s.Id == studentId)
                    .Select(s => new
                    {
                        s.FirstName,
                        s.SurName,
                        s.LastName,
                        s.GSM,
                        s.Email,
                        s.Address,
                        s.Age,
                        Gender = s.Gender == 1 ? "Male" : "Female",
                        ClassInfo = new
                        {
                            s.Class.Grade,
                            s.Class.GradeLetter,
                            SpecialityName = s.Class.Speciality.Name
                        },
                        ClassTeacher = db.Teachers
                            .Where(t => t.ManagedClassID == s.ClassID)
                            .Select(t => t.FirstName + " " + t.LastName)
                            .FirstOrDefault()
                    })
                    .FirstOrDefault();

                if (selectedStudent != null)
                {
                    Console.WriteLine($"\nИнформация за {selectedStudent.FirstName} {selectedStudent.SurName} {selectedStudent.LastName}:");
                    Console.WriteLine($"Телефон: {selectedStudent.GSM}");
                    Console.WriteLine($"Имейл: {selectedStudent.Email}");
                    Console.WriteLine($"Адрес: {selectedStudent.Address}");
                    Console.WriteLine($"Възраст: {selectedStudent.Age}");
                    Console.WriteLine($"Пол: {selectedStudent.Gender}");
                    Console.WriteLine($"Клас: {selectedStudent.ClassInfo.Grade}{selectedStudent.ClassInfo.GradeLetter}");
                    Console.WriteLine($"Специалност: {selectedStudent.ClassInfo.SpecialityName}");
                    Console.WriteLine($"Класен ръководител: {selectedStudent.ClassTeacher}");
                }
                else
                {
                    Console.WriteLine("Няма намерен ученик с този номер.");
                }
            }
            else
            {
                Console.WriteLine("Невалиден номер.");
            }
        }


    }

}

