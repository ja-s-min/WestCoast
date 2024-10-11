
namespace WestCoast2;

public interface IParticipant
{
    string Name { get; set; }
    string LastName { get; set; }
    string PersonalNumber { get; set; }
    string Phone { get; set; }

    void DisplayInfo();
}
