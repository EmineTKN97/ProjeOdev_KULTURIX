using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DistrictManager : IDistrictService
    {
        IDistrictDal _districtDal;

        public DistrictManager(IDistrictDal districtDal)
        {
            _districtDal = districtDal;
        }

        public async Task<IDataResult<List<District>>> GetAll()
        {
            return new SuccessDataResult<List<District>>(_districtDal.GetAll());
        }

        public async  Task<IDataResult<List<District>>> GetCityId(int CityId)
        {
            return new SuccessDataResult<List<District>>(_districtDal.GetCityId(CityId));
        }
    }
}
