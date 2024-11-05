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
                Console.WriteLine("Hello,what do you want to do? \n1)List all students and their class  \n2)Check student \n3)Add new student \n4)List all classes \n5)Create new class \n6)List all speciality \n7)Create new speciality \n8)List all teacher and their class \n9)Add new teacher \n10)End");
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
                                Console.WriteLine("Incorect number.");
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
                            ListAllClasses();

                            break;
                        }
                    case 5:
                        {
                            AddClass();
                            break;
                        }
                    case 6:
                        {
                            ListSpecialities();
                            break;
                        }
                    case 7:
                        {
                            AddSpeciality();
                            break;
                        }
                    case 8:
                        {
                            ListAllTeachersWithClasses();

                            break;
                        }
                    case 9:
                        {
                            AddTeacher();
                            break;
                        }
                    case 10:
                        {
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
            Console.WriteLine("Listing all students and their class");
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

            
            SaveStudentToDatabase(firstName, surName, lastName, gsm, email, address, age, gender == 1, classId);
            Console.WriteLine("Student added sucsesfuly");
        }

        
        private static System.Collections.Generic.List<ClassModel> GetClassesList()
        {
            using (var db = new SchoolDBContext())
            {
                return db.Classes
                    .Select(c => new ClassModel
                    {
                        Id = c.Id,
                        ClassName = c.Grade.ToString() + c.GradeLetter
                    })
                    .ToList();
            }
        }


        
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

       
        private class ClassModel
        {
            public int Id { get; set; }
            public string ClassName { get; set; }
        }
        private static void ListAllTeachersWithClasses()
        {
            var teachersWithClasses = GetTeachersWithClasses();

            Console.WriteLine("Listing all teacher and their class");
            foreach (var teacher in teachersWithClasses)
            {
                Console.WriteLine($" {teacher.TeacherName}-{teacher.ManagedClass}");
            }
        }

        
        private static List<TeacherWithClassModel> GetTeachersWithClasses()
        {
            using (var db = new SchoolDBContext())
            {
                return db.Teachers
                    .Select(t => new TeacherWithClassModel
                    {
                        TeacherName = t.FirstName + " " + t.LastName,
                        
                        ManagedClass = t.ManagedClassId != null
                            ? db.Classes.Where(c => c.Id == t.ManagedClassId)
                                        .Select(c => c.Grade.ToString() + c.GradeLetter)
                                        .FirstOrDefault()
                            : "Without class"
                    })
                    .ToList();
            }
        }
        private class TeacherWithClassModel
        {
            public string TeacherName { get; set; }
            public string ManagedClass { get; set; }
        }

        private static void AddTeacher()
        {
            using (var db = new SchoolDBContext())
            {
                Console.WriteLine("Enter info for new teacher");

               
                Console.Write("Name: ");
                string firstName = Console.ReadLine();

                Console.Write("LastName: ");
                string lastName = Console.ReadLine();

                Console.Write("Gender (1 for Male, 0 for female): ");
                bool gender = Console.ReadLine() == "1";

                Console.Write("Email: ");
                string email = Console.ReadLine();

                Console.Write("Subject: ");
                string subjects = Console.ReadLine();

               
                var classes = GetClassesList();
                Console.WriteLine("Choise class:");
                foreach (var cls in classes)
                {
                    Console.WriteLine($"ID: {cls.Id}, Class: {cls.ClassName}");
                }

               
                Console.Write("Choise classid (input Enter, if no class): ");
                string classIdInput = Console.ReadLine();
                int? managedClassId = string.IsNullOrWhiteSpace(classIdInput) ? (int?)null : int.Parse(classIdInput);

                
                var newTeacher = new Teacher
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = gender,
                    Email = email,
                    Subjects = subjects,
                    ManagedClassId = managedClassId
                };

                
                db.Teachers.Add(newTeacher);
                db.SaveChanges();

                Console.WriteLine("New teacher added sucsefuly");
            }
        }

        private static void AddClass()
        {
            using (var db = new SchoolDBContext())
            {
                Console.WriteLine("Input info for new class");

                
                int grade;
                while (true)
                {
                    Console.Write("Grade(1-12): ");
                    if (int.TryParse(Console.ReadLine(), out grade) && grade >= 1 && grade <= 12)
                        break;
                    else
                        Console.WriteLine("Invalid Grade. Please,input number between 1 and 12.");
                }

                
                Console.Write("GradeLetter (A, B, C ....): ");
                string gradeLetter = Console.ReadLine().ToUpper();

                
                var specialities = GetSpecialitiesList();
                Console.WriteLine("availble speciality");
                foreach (var speciality in specialities)
                {
                    Console.WriteLine($"Id: {speciality.Id}, speciality: {speciality.Name}");
                }

                
                int specialityId;
                while (true)
                {
                    Console.Write("Select Id of speciality: ");
                    if (int.TryParse(Console.ReadLine(), out specialityId) &&
                        specialities.Any(s => s.Id == specialityId))
                        break;
                    else
                        Console.WriteLine("Invalid value.Please,input corect Id of speciality.");
                }

                
                var newClass = new Class
                {
                    Grade = grade,
                    GradeLetter = gradeLetter,
                    SpecialityId = specialityId
                };

            
                db.Classes.Add(newClass);
                db.SaveChanges();

                Console.WriteLine("New class is sucsesfuly added");
            }
        }
        private static List<SpecialityModel> GetSpecialitiesList()
        {
            using (var db = new SchoolDBContext())
            {
                return db.Specialites
                    .Select(s => new SpecialityModel
                    {
                        Id = s.Id,
                        Name = s.Name
                    })
                    .ToList();
            }
        }

       
        private class SpecialityModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private static void ListAllClasses()
        {
            using (var db = new SchoolDBContext())
            {
                var classes = db.Classes
                    .Select(c => new
                    {
                        ClassId = c.Id,
                        Grade = c.Grade,
                        GradeLetter = c.GradeLetter,
                        SpecialityName = c.Speciality.Name
                    })
                    .ToList();

                Console.WriteLine("Listing all classes:");
                foreach (var cls in classes)
                {
                    Console.WriteLine($"Id: {cls.ClassId}, Grade: {cls.Grade}{cls.GradeLetter}, Speciality: {cls.SpecialityName}");
                }
            }
        }

        private static void ListSpecialities()
        {
            using (var db = new SchoolDBContext())
            {
                var specialities = db.Specialites
                    .Select(s => new
                    {
                        s.Id,
                        s.Name,
                        s.Description,
                        s.GraduatesTitle,
                        s.StartGrade,
                        s.EndGrade
                    })
                    .ToList();

                Console.WriteLine("Listing all specialities:");
                foreach (var speciality in specialities)
                {
                    Console.WriteLine($"Id: {speciality.Id}");
                    Console.WriteLine($"Name: {speciality.Name}");
                    Console.WriteLine($"Description: {speciality.Description}");
                    Console.WriteLine($"GraduatesTitle: {speciality.GraduatesTitle}");
                    Console.WriteLine($"StartGrade: {speciality.StartGrade}");
                    Console.WriteLine($"EndGrade: {speciality.EndGrade}");
                    Console.WriteLine(new string('-', 30)); 
                }
            }
        }
        private static void AddSpeciality()
        {
            using (var db = new SchoolDBContext())
            {
                Console.WriteLine("Input info for new speciality");

                
                Console.Write("Name of speciality: ");
                string name = Console.ReadLine();

                
                Console.Write("Description: ");
                string description = Console.ReadLine();

               
                Console.Write("GraduatesTitle: ");
                string graduatesTitle = Console.ReadLine();

                int startGrade;
                while (true)
                {
                    Console.Write("StartGrade (1-12): ");
                    if (int.TryParse(Console.ReadLine(), out startGrade) && startGrade >= 1 && startGrade <= 12)
                        break;
                    else
                        Console.WriteLine("Incoret value.Please,select number between 1 и 12.");
                }

                
                int endGrade;
                while (true)
                {
                    Console.Write("Крайна степен (1-12): ");
                    if (int.TryParse(Console.ReadLine(), out endGrade) && endGrade >= 1 && endGrade <= 12 && endGrade >= startGrade)
                        break;
                    else
                        Console.WriteLine("Incoret value.Please,select number between 1 и 12,which is greater than or equal to the intial power.");
                }

                var newSpeciality = new Specialite
                {
                    Name = name,
                    Description = description,
                    GraduatesTitle = graduatesTitle,
                    StartGrade = startGrade,
                    EndGrade = endGrade
                };

                db.Specialites.Add(newSpeciality);
                db.SaveChanges();

                Console.WriteLine("New speciality is sucsesfuly added");
            }
        }
    }
}

    












