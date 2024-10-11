namespace WestCoast2;

public class Participant
{
    public string Name { get; set; } = "";
    public string LastName { get; set; } = "";
    public string PersonalNumber { get; set; } = "";
    public Address Address { get; set; } = new Address();
    public string Phone { get; set; } = "";

}
