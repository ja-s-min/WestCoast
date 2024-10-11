using System.Text.Json;
using Microsoft.VisualBasic;

namespace WestCoast2;

class Program
{
    static void Main()
    {
        bool running = true;
        string filePath = "courses.json"; 

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Välkommen till WestCoast Education, välj ett av följande: ");
            Console.WriteLine("1. Lägg till en kurs");
            Console.WriteLine("2. Visa alla kurser");
            Console.WriteLine("3. Lägg till en student");
            Console.WriteLine("4. Visa alla studenter");
            Console.WriteLine("5. Lägg till en lärare");
            Console.WriteLine("6. Visa alla lärare");
            Console.WriteLine("7. Lägg till en utbildningsansvarig");
            Console.WriteLine("8. Visa alla utbildningsansvariga");
            Console.WriteLine("9. Lägg till en administratör");
            Console.WriteLine("10. Visa alla administratörer");
            Console.WriteLine("11. Spara kurser till en JSON-fil");
            Console.WriteLine("12. Läs in kurser från en JSON-fil");
            Console.WriteLine("13. Avsluta");

            string choice = Console.ReadLine()!;

            try
            {
                switch (choice)
                {
                    case "1":
                        Course.AddCourse();
                        break;
                    case "2":
                        Course.ListCourses();
                        break;
                    case "3":
                        ManageEntity(new Student());
                        break;
                    case "4":
                        Student.ListStudents();
                        break;
                    case "5":
                        ManageEntity(new Teacher());
                        break;
                    case "6":
                        Teacher.ListTeachers();
                        break;
                    case "7":
                        ManageEntity<EducationManager>(new EducationManager());
                        break;
                    case "8":
                        EducationManager.ListEducationManagers();
                        break;
                    case "9":
                        ManageEntity<Administrator>(new Administrator());
                        break;
                    case "10":
                        Administrator.ListAdministrators();
                        break;
                    case "11":
                        Course.SaveCoursesToFile(filePath);
                        break;
                    case "12":
                        Course.LoadCoursesFromFile(filePath);
                        break;
                    case "13":
                        running = false;
                        break;
                        default:
                        throw new ArgumentException("Det gick ju inte så bra, försök igen.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Aj aj aj, testa igen. : {ex.Message}");
            }

            Console.WriteLine("Tryck på enter för att gå vidare");
            Console.ReadKey();
        }
    }

    static void ManageEntity<T>(IManageable<T> entity) where T : class
{
    entity.Register();
    entity.ShowAll();
}
}

