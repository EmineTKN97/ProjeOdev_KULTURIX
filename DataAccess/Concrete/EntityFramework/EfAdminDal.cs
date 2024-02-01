using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAdminDal : EfEntityRepositoryBase<Admin, ProjeOdevContext>, IAdminDal
    {
        public List<OperationClaim> GetClaims(Admin admin)
        {
            using (var context = new ProjeOdevContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join adminOperationClaim in context.AdminOperationClaims
                                 on operationClaim.Id equals adminOperationClaim.OperationClaimsId
                             where adminOperationClaim.AdminId == admin.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
