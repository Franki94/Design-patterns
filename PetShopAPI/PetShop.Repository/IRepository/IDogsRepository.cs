using PetShop.Models;
using System;
using System.Collections.Generic;

namespace PetShop.Repository.IRepository
{
    public interface IDogsRepository
    {
        IEnumerable<Pets> GetPets(Func<Pets, bool> whereCondition, params string[] includeExpression);
    }
}
