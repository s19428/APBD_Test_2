using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Test2.Models
{
    public class Volunteer_Pet
    {
        public int IdVolunteer { get; set; }
        public int IdPet { get; set; }
        public DateTime DateAccepted { get; set; }

        // Navigation fields

        public virtual Pet Pet { get; set; }
        public virtual Volunteer Volunteer { get; set; }
    }
}
