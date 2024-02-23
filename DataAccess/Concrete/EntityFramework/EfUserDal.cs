using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstarct;
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
    public class EfUserDal : EfEntityRepositoryBase<User, ProjeOdevContext>, IUserDal
    {
        private readonly ProjeOdevContext _context;

        public EfUserDal(ProjeOdevContext context)
        {
            _context = context;
        }
        public void Delete(Guid id)
        {
            var userToDelete = _context.Users.FirstOrDefault(u =>  u.Id == id);

            if (userToDelete != null)
            {
                userToDelete.Status = true;
                _context.Users.Update(userToDelete);
                _context.SaveChanges();
            }
        }

        public UserDTO GetById(Guid userId)
        {
            var user = _context.Users
                              .Where(u => u.Id == userId)
                              .Select(u => new UserDTO
                              {
                                  BirthDate = u.BirthDate,
                                  ImagePath = u.ImagePath,
                                  Name = u.Name,
                                  SurName = u.SurName,
                                  Email = u.Email,
                                  MediaId = u.Medias.FirstOrDefault().MediaId
                              })
                              .FirstOrDefault(); 

            return user;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            
                var result = from operationClaim in _context.OperationClaims
                             join userOperationClaim in _context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimsId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            
        }

        public void Update(Guid id, UserDTO userdto)
        {
            var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id);

            if (userToUpdate != null && userToUpdate.Status == false)
            {
                userToUpdate.Email = userdto.Email;
                userToUpdate.SurName= userdto.SurName;
                userToUpdate.Name = userdto.Name;
                userToUpdate.CreateDate = DateTime.Now;
                userToUpdate.BirthDate = userdto.BirthDate;
                _context.Entry(userToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("User bulunamadı veya güncellenemedi.");
            }
        }

        public void UpdatePassword(string currentPassword, string newPassword, Guid userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId && u.Status == false);

            if (user != null)
            {
                if (HashingHelper.VerifyPasswordHash(currentPassword, user.PasswordHash, user.PasswordSalt))
                {
                    byte[] newPasswordHash, newPasswordSalt;
                    HashingHelper.CreatePasswordHash(newPassword, out newPasswordHash, out newPasswordSalt);
                    user.PasswordHash = newPasswordHash;
                    user.PasswordSalt = newPasswordSalt;

                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Mevcut şifre geçerli değil.");
                }
            }
            else
            {
                throw new Exception("Kullanıcı bulunamadı veya şifre değiştirme izni yok.");
            }
        }
    }
}

   
    

