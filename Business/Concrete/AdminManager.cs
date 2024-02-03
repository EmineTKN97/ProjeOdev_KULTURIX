using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;
      
        public AdminManager(IAdminDal admindal)
        {
            _adminDal = admindal;
        }

        public void Add(Admin admin)
        {
            _adminDal.Add(admin);
        }
        [SecuredOperation("ADMİN")]
        public async Task<IResult> ChangeAdminPassword(string currentPassword, string newPassword, Guid AdminID)
        {
          
            _adminDal.UpdateAdminPassword(currentPassword, newPassword, AdminID);
            return new Result(true, Messages.ChangeAdminPassword);
        }
        [SecuredOperation("ADMİN")]
        public async  Task<IResult> Delete(Guid İd)
        {
            _adminDal.Delete(İd);
            return new Result(true, Messages.AdminDeleted);
        }

        public async Task<IDataResult<Admin>> GetById(Guid Adminİd)
        {
            return new SuccessDataResult<Admin>(_adminDal.Get(a => a.Id == Adminİd), Messages.AdminListed);
        }

        public Admin GetByMail(string email)
        {
            return _adminDal.Get(a => a.Email == email);
        }
        public List<OperationClaim> GetClaims(Admin admin)
        {
            return _adminDal.GetClaims(admin);
        }
        [SecuredOperation("ADMİN")]
        public async Task<IResult> Update(Guid id, AdminDTO adminDto)
        {
            try
            {
                _adminDal.Update(id, adminDto);
                return new Result(true, Messages.AdminUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorResult(Messages.AdminNotUpdated);
            }
        }
    }
}
