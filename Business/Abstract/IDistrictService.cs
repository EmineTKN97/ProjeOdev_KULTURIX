using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface IDistrictService
    {
        Task<IDataResult<List<District>>> GetAll();
        Task<IDataResult<List<District>>> GetCityId(int CityId);
    }
}
