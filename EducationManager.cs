
namespace WestCoast2;

public class EducationManager : Teacher, IParticipant, IManageable<EducationManager>
{
    public static List<EducationManager> educationManagers = new List<EducationManager>();
    public DateTime DateofEmployment { get; set; }

    public override void Register()
    {
        AddEducationManager();
    }

    public override void ShowAll()
    {
        ListEducationManagers();
    }

    public static void AddEducationManager()
    {
        try
        {
            Console.Write("Ange förnamn: ");
            string? name = Console.ReadLine();

            Console.Write("Ange efternamn: ");
            string? lastName = Console.ReadLine();

            Console.Write("Ange personnummer: ");
            string? personalNumber = Console.ReadLine();

            Console.Write("Ange telefonnummer: ");
            string? phone = Console.ReadLine();

            Console.Write("Ange kunskapsområde: ");
            string? knowledgeArea = Console.ReadLine();

            Console.Write("kursansvarig för: ");
            string? courseManagerFor = Console.ReadLine();

            Console.Write("Ange anställningsdatum åååå-mm-dd: ");
            DateTime employmentDate = DateTime.Parse(Console.ReadLine()!);

            var manager = new EducationManager
            {
                Name = name!,
                LastName = lastName!,
                PersonalNumber = personalNumber!,
                Phone = phone!,
                KnowledgeArea = knowledgeArea!,
                CoursemanagerFor = courseManagerFor!,
                DateofEmployment = employmentDate
            };

            educationManagers.Add(manager);
            Console.WriteLine("Utbildningsansvarig tillagd!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"OJ oj oj, testa igen: {ex.Message}");
        }
    }

    public static void ListEducationManagers()
    {
        Console.WriteLine("Utbildningsansvariga:");
        foreach (var manager in educationManagers)
        {
            Console.WriteLine(manager.ToString());
        }
    }

    public override void DisplayInfo()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Utbildningsansvarig: {Name} {LastName}, Kunskapsområde: {KnowledgeArea}, Kursansvarig för: {CoursemanagerFor}, " +
               $"Telefonnummer: {Phone}, Anställd sedan: {DateofEmployment.ToShortDateString()}";
    }
}
