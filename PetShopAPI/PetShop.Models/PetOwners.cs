using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Models
{
    public class PetOwners
    {
        public int PetId { get; set; }
        public int OwnerId { get; set; }

        public Pets PetNavigation { get; set; }
        public Owners OwnerNavigation { get; set; }
    }
}
