using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Concrete.Context.Configurations;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFOperationClaimDal : EfEntityRepositoryBase<OperationClaim, ProjeOdevContext>, IOperationClaimDal
    {
        
       
    }
}

