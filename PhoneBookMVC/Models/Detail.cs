using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneBookMVC.Models
{
    public class Detail
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string SecondPhone { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDateTime { get; set; }

    }
}