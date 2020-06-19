using APBD_Test2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Test2.Services
{
    public interface IPetsDbService
    {
        List<Pet> GetPets(int year);

        bool AddPet(Pet pet);
    }
}