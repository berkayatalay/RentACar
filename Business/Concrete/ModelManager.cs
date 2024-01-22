using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Model;
using Business.Responses.Model;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class ModelManager : IModelService
{
    private readonly IModelDal _ModelDal;
    private readonly ModelBusinessRules _ModelBusinessRules;
    private readonly IMapper _mapper;

    public ModelManager(IModelDal ModelDal, ModelBusinessRules ModelBusinessRules, IMapper mapper)
    {
        _ModelDal = ModelDal; //new InMemoryModelDal(); // Başka katmanların class'ları new'lenmez. Bu yüzden dependency injection kullanıyoruz.
        _ModelBusinessRules = ModelBusinessRules;
        _mapper = mapper;
    }

    public AddModelResponse Add(AddModelRequest request)
    {
        // İş Kuralları
        _ModelBusinessRules.CheckIfModelNameNotExists(request.Name);
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction
        //Model ModelToAdd = new(request.Name)
        Model ModelToAdd = _mapper.Map<Model>(request); // Mapping

        _ModelDal.Add(ModelToAdd);

        AddModelResponse response = _mapper.Map<AddModelResponse>(ModelToAdd);
        return response;
    }

    public GetModelListResponse GetList(GetModelListRequest request)
    {
        // İş Kuralları
        // Validation
        // Yetki kontrolü
        // Cache
        // Transaction

        IList<Model> ModelList = _ModelDal.GetList();
    
        // ModelList.Items diye bir alan yok, bu yüzden mapping konfigurasyonu yapmamız gerekiyor.

        // Model -> ModelListItemDto
        // IList<Model> -> GetModelListResponse

        GetModelListResponse response = _mapper.Map<GetModelListResponse>(ModelList); // Mapping
        return response;
    }
}
