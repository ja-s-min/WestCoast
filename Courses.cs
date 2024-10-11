using System.Text.Json;


namespace WestCoast2;

public class Course
{
     public static List<Course> courses = new List<Course>();

        public int CourseNumber { get; set; }
        public string CourseName { get; set; } = "";
        public int DurationInWeeks { get; private set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool DistanceCourse { get; set; }

        public Course() {}

        public static void AddCourse()
        {
            try
            {
                Console.Write("Ange kursnummer: ");
                int courseNumber = int.Parse(Console.ReadLine()!);

                Console.Write("Ange kursnamn: ");
                string? courseName = Console.ReadLine();

                Console.Write("Ange kursstart åååå-mm-dd: ");
                DateTime startDate = DateTime.Parse(Console.ReadLine()!);

                Console.Write("Ange kursslut åååå-mm-dd: ");
                DateTime endDate = DateTime.Parse(Console.ReadLine()!);

                Console.Write("Är det en distanskurs? (ja/nej): ");
                bool isDistanceCourse = Console.ReadLine()?.ToLower() == "ja";

                var course = new Course
                {
                    CourseNumber = courseNumber,
                    CourseName = courseName!,
                    StartDate = startDate,
                    EndDate = endDate,
                    DistanceCourse = isDistanceCourse
                };

                course.DurationInWeeks = CalculateDurationInWeeks(startDate, endDate);

                courses.Add(course);
                Console.WriteLine("Kurs tillagd!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"AJ aj aj, testa igen. : {ex.Message}");
            }
        }

         private static int CalculateDurationInWeeks(DateTime startDate, DateTime endDate)
    {
        
        var duration = (endDate - startDate).TotalDays / 7;
        return (int)Math.Ceiling(duration);
    }

        public static void ListCourses()
        {
            Console.WriteLine("Kurser:");
            foreach (var course in courses)
            {
                Console.WriteLine(course.ToString());
            }
        }

         public static void SaveCoursesToFile(string filePath)
    {
        try
        {
            var json = JsonSerializer.Serialize(courses, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            Console.WriteLine("Kursen är nu sparad!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Något gick snett när de skulle sparas, testa igen. : {ex.Message}");
        }
    }

    public static void LoadCoursesFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                courses = JsonSerializer.Deserialize<List<Course>>(json) ?? new List<Course>();
                Console.WriteLine("Kika under filen Courses.cs, där finner du json filen. :)");
            }
            else
            {
                Console.WriteLine("Filen finns inte, ingen data laddades in.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Något gick snett, testa igen. : {ex.Message}");
        }
    }

        public override string ToString()
        {
            return $"Kursnamn: {CourseName}, Kursnummer: {CourseNumber}, Kurslängd: {DurationInWeeks} veckor, " +
                   $"Kursstart: {StartDate.ToShortDateString()}, Kursslut: {EndDate.ToShortDateString()}, Distanskurs: {DistanceCourse}";
        }
    }
