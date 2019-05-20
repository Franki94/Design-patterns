using System.Collections.Generic;

namespace PetShop.Models
{
    public class PetTypes
    {
        public PetTypes()
        {
            PetsNavigation = new HashSet<Pets>();
        }
        public int PetType { get; set; }
        public string Description { get; set; }

        public ICollection<Pets> PetsNavigation { get; set; }
    }
}
