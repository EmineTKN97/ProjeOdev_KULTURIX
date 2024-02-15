using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfDistrictDal : EfEntityRepositoryBase<District, ProjeOdevContext>, IDistrictDal
    {
        private readonly ProjeOdevContext _context;

        public EfDistrictDal(ProjeOdevContext context)
        {
            _context = context;
        }
        public List<District> GetCityId(int cityId)
        {
            var districts = _context.Districts
       .Where(d => d.SehirId == cityId)
       .ToList();

            return districts;
        }
    }
}
