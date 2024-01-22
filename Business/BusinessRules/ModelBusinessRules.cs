using Core.CrossCuttingConcerns.Exceptions;
using DataAccess.Abstract;

namespace Business.BusinessRules;

public class ModelBusinessRules
{
    private readonly IModelDal _ModelDal;

    public ModelBusinessRules(IModelDal ModelDal)
    {
        _ModelDal = ModelDal;
    }

    public void CheckIfModelNameNotExists(string ModelName)
    {
        bool isExists = _ModelDal.GetList().Any(b => b.Name == ModelName);
        if (isExists)
        {
            throw new BusinessException("Model already exists.");
        }
    }

    public void CheckIfModelNameBiggerThanTwoChar(string ModelName)
    {
        if (ModelName.Length < 2)
        {
            throw new BusinessException("Model name lenght must be bigger than two character.");
        }
    }
}
