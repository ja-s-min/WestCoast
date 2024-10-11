
namespace WestCoast2;

public class Student : Participant, IParticipant, IManageable<Student>
{
    public static List<Student> students = new List<Student>();

    public void Register()
    {
        AddStudent();
    }

    public void ShowAll()
    {
        ListStudents();
    }

    public static void AddStudent()
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

            Console.Write("Ange adress: ");
            string? addressLine = Console.ReadLine();

            Console.Write("Ange postnummer: ");
            string? postalCode = Console.ReadLine();

            Console.Write("Ange stad: ");
            string? city = Console.ReadLine();

            Address address = new Address
            {
                AddressLine = addressLine!,
                PostalCode = postalCode!,
                City = city!
            };

            var student = new Student
            {
                Name = name!,
                LastName = lastName!,
                PersonalNumber = personalNumber!,
                Phone = phone!,
                Address = address
            };

            students.Add(student);
            Console.WriteLine("Student tillagd!");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Aj aj aj, försök igen: {ex.Message}");
        }
    }

    public static void ListStudents()
    {
        Console.WriteLine("Studenter:");
        foreach (var student in students)
        {
            Console.WriteLine(student.ToString());
        }
    }

    public void DisplayInfo()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Förnamn: {Name}, Efternamn: {LastName}, Personnummer: {PersonalNumber}, Telefonnummer: {Phone}, Adress: {Address}";
    }
}
