﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_Test2.Models
{
    public class BreedType
    {
        public int IdBreedType { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        //

        public virtual ICollection<Pet> Pets { get; set; }
    }
}