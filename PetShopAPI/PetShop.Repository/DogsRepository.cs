using Microsoft.EntityFrameworkCore;
using PetShop.Models;
using PetShop.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Repository
{
    public class DogsRepository : IDogsRepository
    {
        private readonly PetShopDbContext _context;
        public DogsRepository(PetShopDbContext context)
        {
            _context = context;
        }
        public bool AddNewPet(Pets pet)
        {
            _context.Pets.Add(pet);
            return _context.SaveChanges() > 0;
        }
        public bool UpdatePet(Pets pet)
        {
            _context.Pets.Update(pet);
            return _context.SaveChanges() > 0;
        }
        public bool DeletePet(Pets pet)
        {
            _context.Pets.Remove(pet);
            return _context.SaveChanges() > 0;
        }
        public IEnumerable<Pets> GetPets(Func<Pets, bool> whereCondition, params string[] includeExpression)
        {
            var expression = _context.Pets.AsQueryable();
            if (includeExpression.Any())
            {
                foreach (var item in includeExpression)
                {
                    expression = expression.Include(item);
                }
            }

            return expression.Where(whereCondition);
        }
    }
}
