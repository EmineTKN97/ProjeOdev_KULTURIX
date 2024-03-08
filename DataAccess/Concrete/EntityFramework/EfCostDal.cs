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
    public class EfCostDal : EfEntityRepositoryBase<Cost, ProjeOdevContext>, ICostDal
    {
        private readonly ProjeOdevContext _context;
        public EfCostDal(ProjeOdevContext context)
        {
            _context = context;
        }
        public void AddTicket( CostDTO costDTO)
        {
              var ticket = new Cost
                {
                    Price = costDTO.Price,
                    Id = Guid.NewGuid(),

                };
                _context.Costs.Add(ticket);
                _context.SaveChanges();

            
        }

        public CostDTO GetById(Guid costId)
        {
            var costDetails = (from c in _context.Costs
                               where c.Id == costId 
                               select new CostDTO
                               {
                                   Id = c.Id,
                                   Price = c.Price, 
                               }).FirstOrDefault();

            return costDetails;
        }

        public void UpdateTicket(Guid ıd, CostDTO costDTO) 
        {
            var costToUpdate = _context.Costs.FirstOrDefault(c => c.Id == ıd);

            if (costToUpdate != null)
            {
                costToUpdate.Price = costDTO.Price;
                costToUpdate.Id= costDTO.Id;
                _context.Entry(costToUpdate).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Güncellenemedi.");
            }

        }
       
    }
}
