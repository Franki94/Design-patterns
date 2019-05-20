using System;
using System.Collections.Generic;

namespace PetShop.Models
{
    public class Pets
    {
        public Pets()
        {
            PetOwnersNavigation = new HashSet<PetOwners>();
        }
        public int PetId { get; set; }
        public string Name { get; set; }
        public string FamilyLasName { get; set; }
        public string Raise { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PetType { get; set; }
        public double Size { get; set; }

        public virtual PetTypes PetTypeNavigation { get; set; }
        public virtual ICollection<PetOwners> PetOwnersNavigation { get; set; }
    }
}
