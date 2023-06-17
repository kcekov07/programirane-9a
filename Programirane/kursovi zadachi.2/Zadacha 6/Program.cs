using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_6
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputParts = input.Split(new string[] { " : " }, StringSplitOptions.None);
                string courseName = inputParts[0];
                string studentName = inputParts[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }

                courses[courseName].Add(studentName);
            }

            var sortedCourses = courses.OrderByDescending(c => c.Value.Count);

            foreach (var course in sortedCourses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                var sortedStudents = course.Value.OrderBy(s => s);

                foreach (var student in sortedStudents)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
            Console.ReadLine();
        }
    }
}
