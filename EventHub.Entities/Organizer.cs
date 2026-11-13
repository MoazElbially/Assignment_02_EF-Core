using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Assignment_02_EF_Core.EventHub.Entities
{
    [Table("EventOrganizers")]
    internal class Organizer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        
        public string Name { get; set; }
        
        [MaxLength(150)]  
        public string? CompanyName { get; set; }

        public bool IsVerified { get; set; }


        public OrganizerProfile Profile { get; set; }

        public ICollection<Event> Events { get; set; }
            = new List<Event>();

    }
}
