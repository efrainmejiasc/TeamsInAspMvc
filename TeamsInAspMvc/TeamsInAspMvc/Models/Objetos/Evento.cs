using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamsInAspMvc.Models.Objetos
{
    public class Evento
    {
        public string subject { get; set; }

        public Body body { get; set; }

        public Start start { get; set; }

        public End end { get; set; }

        public Location location { get; set; }

        public List<Attendee> attendees { get; set; }

        public Guid transactionId { get; set; }

        public class Body
        {
            public string contentType { get; set; } //HTML
            public string content { get; set; } // cadena -> dscripcion
        }

        public class Start
        {
            public DateTime dateTime { get; set; }
            public string timeZone { get; set; }
        }

        public class End
        {
            public DateTime dateTime { get; set; }
            public string timeZone { get; set; }
        }

        public class Location
        {
            public string displayName { get; set; } // sitio o Url
        }

        public class EmailAddress
        {
            public string address { get; set; }
            public string name { get; set; }
        }

        public class Attendee
        {
            public EmailAddress emailAddress { get; set; }
            public string type { get; set; }
        }

    }
}