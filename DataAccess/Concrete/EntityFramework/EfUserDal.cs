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

        public void Add(string fileName, UserDTO userdto)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Name = userdto.Name,
                SurName = userdto.SurName,
                Email = userdto.Email,
                BirtDate = userdto.BirthDate,
                Password = userdto.Password,
                ImagePath = fileName,
                CreateDate = DateTime.Now,

            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
