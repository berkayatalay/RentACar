using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Car;
using Business.Responses.Car;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CarManager : ICarService
{
    private readonly ICarDal _CarDal;
    private readonly CarBusinessRules _CarBusinessRules;
    private readonly IMapper _mapper;

    public CarManager(ICarDal CarDal, CarBusinessRules CarBusinessRules, IMapper mapper)
    {
        _CarDal = CarDal; //new InMemoryCarDal(); // Başka katmanların class'ları new'lenmez. Bu yüzden dependency injection kullanıyoruz.
        _CarBusinessRules = CarBusinessRules;
        _mapper = mapper;
    }

    public AddCarResponse Add(AddCarRequest request)
    {
        // İş Kuralları
        _CarBusinessRules.CheckIfCarNameNotExists(request.Name);
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction
        //Car CarToAdd = new(request.Name)
        Car CarToAdd = _mapper.Map<Car>(request); // Mapping

        _CarDal.Add(CarToAdd);

        AddCarResponse response = _mapper.Map<AddCarResponse>(CarToAdd);
        return response;
    }

    public GetCarListResponse GetList(GetCarListRequest request)
    {
        // İş Kuralları
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        IList<Car> CarList = _CarDal.GetList();
    
        // CarList.Items diye bir alan yok, bu yüzden mapping konfigurasyonu yapmamız gerekiyor.

        // Car -> CarListItemDto
        // IList<Car> -> GetCarListResponse

        GetCarListResponse response = _mapper.Map<GetCarListResponse>(CarList); // Mapping
        return response;
    }
}
