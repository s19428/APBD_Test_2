using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Test2.Models
{
    public class Volunteer
    {
        public int IdVolounteer { get; set; }
        public int? IdSupervisor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime StartingDate { get; set; }

        // Navigation fields

        //public virtual Volunteer Volunteer { get; set; }

        public virtual ICollection<Volunteer> Volunteers { get; set; }
        public virtual Volunteer Supervisor { get; set; }

        public virtual ICollection<Volunteer_Pet> Volunteer_Pets { get; set; }
    }
}