using System;
using System.Collections.Generic;

namespace PetShop.Models
{
    public class Owners
    {
        public Owners()
        {
            PetOwnersNavigation = new HashSet<PetOwners>();
        }
        public int OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }

        public ICollection<PetOwners> PetOwnersNavigation { get; set; }
    }
}
