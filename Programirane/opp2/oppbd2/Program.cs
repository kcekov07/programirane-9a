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
                            Console.WriteLine("Input student id for more info:");
                            if (int.TryParse(Console.ReadLine(), out int studentId))
                            {
                                ShowStudentDetails(studentId);
                            }
                            else
                            {
                                Console.WriteLine("Невалиден номер.");
                            }
                            break;
                        }
                    case 3:
                        {
                            AddNewStudent();
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
                student = db.Students.Include(s => s.Class).ToArray();
            }

            foreach (var s in student)
            {
                string data = s.GetInfo();
                Console.WriteLine(data);
                Console.WriteLine();
                Thread.Sleep(1000);
            }
        }
        private static void ShowStudentDetails(int studentId)
        {
            using (var db = new SchoolDBContext())
            {
                var selectedStudent = db.Students
                    .Where(s => s.Id == studentId)
                    .Select(s => new
                    {
                        FullName = s.FirstName + " " + s.SurName + " " + s.LastName,
                        s.Gsm,
                        s.Email,
                        s.Address,
                        s.Age,
                        Gender = s.Gender  ? "Male" : "Female",


                        
                        ClassInfo = new
                        {
                            s.Class.Grade,
                            s.Class.GradeLetter,
                            SpecialityName = s.Class.Speciality.Name
                        },
                        ClassTeacher = db.Teachers
                            .Where(t => t.ManagedClassId == s.ClassId)
                            .Select(t => t.FirstName + " " + t.LastName)
                            .FirstOrDefault()
                    })
                    .FirstOrDefault();

                if (selectedStudent != null)
                {
                    Console.WriteLine($"Info for {selectedStudent.FullName}:");
                    Console.WriteLine($"Gsm: {selectedStudent.Gsm}");
                    Console.WriteLine($"Email: {selectedStudent.Email}");
                    Console.WriteLine($"Adress: {selectedStudent.Address}");
                    Console.WriteLine($"Age: {selectedStudent.Age}");
                    Console.WriteLine($"Gender: {selectedStudent.Gender}");
                    Console.WriteLine($"Class: {selectedStudent.ClassInfo.Grade}{selectedStudent.ClassInfo.GradeLetter}");
                    Console.WriteLine($"Speciality: {selectedStudent.ClassInfo.SpecialityName}");
                    Console.WriteLine($"Class teacher: {selectedStudent.ClassTeacher}");
                }
                else
                {
                    Console.WriteLine("No student with this id");
                }
            }
        }
        private static void AddNewStudent()
        {
            // Въвеждане на нови данни за ученик
            Console.WriteLine("Input info for new student.");

            Console.Write("Name: ");
            string firstName = Console.ReadLine();

            Console.Write("SurName: ");
            string surName = Console.ReadLine();

            Console.Write("LastName: ");
            string lastName = Console.ReadLine();

            Console.Write("GSM: ");
            string gsm = Console.ReadLine();

            Console.Write("Email ");
            string email = Console.ReadLine();

            Console.Write("Adress: ");
            string address = Console.ReadLine();

            Console.Write("Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age < 8 || age > 20)
            {
                Console.WriteLine("Incorect age");
                return;
            }

            Console.Write("Gender (1 for Male, 0 for female): ");
            if (!int.TryParse(Console.ReadLine(), out int gender) || (gender != 1 && gender != 0))
            {
                Console.WriteLine("Incorect Gender");
                return;
            }

            // Извличане на списък с наличните класове за избор
            var classes = GetClassesList();
            Console.WriteLine("Choise class");
            foreach (var c in classes)
            {
                Console.WriteLine($"Id: {c.Id}, Class: {c.ClassName}");
            }

            Console.Write("Input classid");
            if (!int.TryParse(Console.ReadLine(), out int classId) || !classes.Any(c => c.Id == classId))
            {
                Console.WriteLine("Incorect classid");
                return;
            }

            // Добавяне на нов ученик към базата данни
            SaveStudentToDatabase(firstName, surName, lastName, gsm, email, address, age, gender == 1, classId);
            Console.WriteLine("Student added sucsesfuly");
        }

        // Метод за извличане на списъка с наличните класове от базата данни
        private static System.Collections.Generic.List<ClassModel> GetClassesList()
        {
            using (var db = new SchoolDBContext())
            {
                return db.Classes
                    .Select(c => new ClassModel
                    {
                        Id = c.Id,
                        ClassName = c.Grade + c.GradeLetter
                    })
                    .ToList();
            }
        }


        // Метод за запис на новия ученик в базата данни
        private static void SaveStudentToDatabase(string firstName, string surName, string lastName, string gsm, string email, string address, int age, bool gender, int classId)
        {
            using (var db = new SchoolDBContext())
            {
                var newStudent = new Student
                {
                    FirstName = firstName,
                    SurName = surName,
                    LastName = lastName,
                    Gsm= gsm,
                    Email = email,
                    Address = address,
                    Age = age,
                    Gender = gender,
                    ClassId = classId
                };

                db.Students.Add(newStudent);
                db.SaveChanges();
            }
        }

        // Спомагателен клас за съхранение на данни за класовете
        private class ClassModel
        {
            public int Id { get; set; }
            public string ClassName { get; set; }
        }
    }
}











