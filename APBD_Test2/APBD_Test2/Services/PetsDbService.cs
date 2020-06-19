using APBD_Test2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Test2.Services
{
    public class PetsDbService : IPetsDbService
    {
        PetsDbContext context;

        public PetsDbService(PetsDbContext _context)
        {
            context = _context;
        }

        public List<Pet> GetPets(int year)
        {
            Pet petToFind = new Pet();
            return context.Pets.Where(p => p.DateRegistered.Year >= year).OrderBy(p => p.DateRegistered).ToList();
        }

        public bool AddPet(Pet pet)
        {
            if (context.Pets.Where(p => p.IdPet == pet.IdPet).ToList().Count() > 0)
                return false;

            context.Pets.Add(pet);
            return true;
        }
    }
}