using Core.Entities;

namespace Entities.Concrete;

public class Car : Entity<int>
{
    public int Id { get; set; }
    public int ColorId { get; set; }
    public int ModelId { get; set; }
    public string CarState { get; set; }
    public string Name { get; set; }
    public short Year { get; set; }
    public int DailyPrice { get; set; }
    public int Kilometer { get; set; }
    public int ModelYear { get; set; }
    public int Plate { get; set; }

    public Brand? Brand { get; set; } = null;
}
