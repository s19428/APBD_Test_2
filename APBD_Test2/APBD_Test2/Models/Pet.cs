using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Test2.Models
{
    public class Pet
    {
        public int IdPet { get; set; }
        public int IdBreedType { get; set; }
        public string Name { get; set; }
        public int IsMale { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime ApproximateDateOfBirth { get; set; }
        public DateTime? DateAdopted { get; set; }

        //

        public virtual ICollection<Volunteer_Pet> Volunteer_Pets { get; set; }
        public virtual BreedType BreedType { get; set; }
    }
}
