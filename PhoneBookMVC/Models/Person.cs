using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookMVC.Models
{
    public class Person
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public int DetailId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
      
        public Category Category { get; set; }
       
        public Detail Detail { get; set; }
    }
}
