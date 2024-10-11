
namespace WestCoast2;

public class Teacher : Participant, IParticipant, IManageable<Teacher>
{
    public static List<Teacher> teachers = new List<Teacher>();
    public string KnowledgeArea { get; set; } = "";
    public string CoursemanagerFor { get; set; } = "";

    public virtual void Register()
    {
        AddTeacher();
    }

    public virtual void ShowAll()
    {
        ListTeachers();
    }

    public static void AddTeacher()
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

            var teacher = new Teacher
            {
                Name = name!,
                LastName = lastName!,
                PersonalNumber = personalNumber!,
                Phone = phone!,
                KnowledgeArea = knowledgeArea!,
                CoursemanagerFor = courseManagerFor!
            };

            teachers.Add(teacher);
            Console.WriteLine("Lärare tillagd!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Aj aj aj, försök igen: {ex.Message}");
        }
    }

    public static void ListTeachers()
    {
        Console.WriteLine("Lärare:");
        foreach (var teacher in teachers)
        {
            Console.WriteLine(teacher.ToString());
        }
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Lärare: {Name} {LastName}, Kunskapsområde: {KnowledgeArea}, Kursansvarig: {CoursemanagerFor}, Telefonnummer: {Phone}";
    }
}
