namespace Business.Requests.Car;

public class AddCarRequest
{ // Dto
    public string Name { get; set; }

    public AddCarRequest(string name)
    {
        Name = name;
    }
}
