using Core.DataAccess.EntityFramework;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAdminDal : EfEntityRepositoryBase<Admin, ProjeOdevContext>, IAdminDal
    {

        private readonly ProjeOdevContext _context;
        public EfAdminDal(ProjeOdevContext context)
        {
            _context = context;
        }
        public void Delete(Guid id)
        {
            var adminToDelete = _context.Admins.FirstOrDefault(a => a.Id == id);

            if (adminToDelete != null)
            {
                adminToDelete.Status = true;
                _context.Admins.Update(adminToDelete);
                _context.SaveChanges();
            }
        }

        public List<OperationClaim> GetClaims(Admin admin)
        {
          
                var result = from operationClaim in _context.OperationClaims
                             join adminOperationClaim in _context.AdminOperationClaims
                                 on operationClaim.Id equals adminOperationClaim.OperationClaimsId
                             where adminOperationClaim.AdminId == admin.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

        }

        public void Update(Guid id, AdminDTO adminDto)
        {
            var adminToUpdate = _context.Admins.FirstOrDefault(u => u.Id == id);

            if (adminToUpdate != null && adminToUpdate.Status == false)
            {
                adminToUpdate.Email = adminDto.Email;
                adminToUpdate.FirstName = adminDto.FirstName;
                adminToUpdate.LastName = adminDto.LastName;
                _context.Entry(adminToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception(" Güncelleme işlemi başarısız.");
            }
        }

        public void UpdateAdminPassword(string currentPassword, string newPassword, Guid adminID)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.Id == adminID && a.Status == false);

            if (admin != null)
            {
                byte[] newPasswordHash, newPasswordSalt;
                HashingHelper.CreatePasswordHash(newPassword, out newPasswordHash, out newPasswordSalt);
                admin.PasswordHash = newPasswordHash;
                admin.PasswordSalt = newPasswordSalt;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Şifre Değiştirilemedi.");
            }
        }
    }
}
