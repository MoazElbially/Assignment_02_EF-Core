using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_02_EF_Core.EventHub.Entities
{
    internal class Badge
    {
        public int Id { get; set; }

        public string BadgeNumber { get; set; }

        public DateTime IssuedDate { get; set; }

        public BadgeTier Tier { get; set; }

        public int AttendeeId { get; set; }

        public Attendee Attendee { get; set; }

    }
}
