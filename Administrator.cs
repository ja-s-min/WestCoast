
namespace WestCoast2;

public class Administrator : EducationManager, IParticipant, IManageable<Administrator>
{
    public static List<Administrator> administrators = new List<Administrator>();

    public override void Register()
    {
        AddAdministrator();
    }

    public override void ShowAll()
    {
        ListAdministrators();
    }

    public static void AddAdministrator()
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

            Console.Write("Kursansvarig för: ");
            string? courseManagerFor = Console.ReadLine();

            Console.Write("Ange anställningsdatum åååmmdd: ");
            DateTime employmentDate = DateTime.Parse(Console.ReadLine()!);

            var admin = new Administrator
            {
                Name = name!,
                LastName = lastName!,
                PersonalNumber = personalNumber!,
                Phone = phone!,
                KnowledgeArea = knowledgeArea!,
                CoursemanagerFor = courseManagerFor!,
                DateofEmployment = employmentDate
            };

            administrators.Add(admin);
            Console.WriteLine("Administratör tillagd!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"AJ aj aj, testa igen: {ex.Message}");
        }
    }

    public static void ListAdministrators()
    {
        Console.WriteLine("Administratörer:");
        foreach (var admin in administrators)
        {
            Console.WriteLine(admin.ToString());
        }
    }

    public override void DisplayInfo()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Administratör: {Name} {LastName}, Kunskapsområde: {KnowledgeArea}, Kursansvarig för: {CoursemanagerFor}, " +
               $"Telefonnummer: {Phone}, Anställd sedan: {DateofEmployment.ToShortDateString()}";
    }
}
