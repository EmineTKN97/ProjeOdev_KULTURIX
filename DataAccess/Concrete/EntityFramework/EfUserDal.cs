using Core.DataAccess.EntityFramework;
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
    public class EfUserDal : EfEntityRepositoryBase<User, ProjeOdevContext>, IUserDal
    {
        private readonly ProjeOdevContext _context;

        public EfUserDal(ProjeOdevContext context)
        {
            _context = context;
        }

        public void Add( UserDTO userdto)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = userdto.Name,
                SurName = userdto.SurName,
                Email = userdto.Email,
                BirtDate = userdto.BirthDate,
                Password = userdto.Password,
                ImagePath =  "wwwroot\\Uploads\\StaticContent\\default.jpg",
                CreateDate = DateTime.Now,

            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.Id == id);

            if (userToDelete != null)
            {
                userToDelete.Status = true;
                _context.Users.Update(userToDelete);
                _context.SaveChanges();
            }
        }

       
        public List<UserDTO> GetAllUsers()
        {
            var userDetails = (from u in _context.Users
                               join m in _context.Medias on u.Id equals m.UserId
                               where u.Status == false && m.Status == false
                               group new { u, m } by u.Id into groupedUsers
                               select new UserDTO
                               {
                                   Id = groupedUsers.Key,
                                   Name = groupedUsers.First().u.Name,
                                   SurName = groupedUsers.First().u.SurName,
                                   Email = groupedUsers.First().u.Email,
                                   Password = groupedUsers.First().u.Password,
                                   BirthDate = groupedUsers.First().u.BirtDate,
                                   İmagePath = groupedUsers.First().m.ImagePath,
                               })
                   .ToList();

            return userDetails;

        }

        public void Update(Guid id, UserDTO userDto)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Id == id);

            if (existingUser != null && existingUser.Status == false)
            {
                existingUser.Name = userDto.Name;
                existingUser.SurName = userDto.SurName;
                existingUser.Email = userDto.Email; 
                existingUser.Password = userDto.Password;
                existingUser.BirtDate = userDto.BirthDate;
                existingUser.ImagePath = userDto.İmagePath;
                existingUser.CreateDate = DateTime.Now;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Kullanıcı güncellenemedi");
            }
        }
    }
}
