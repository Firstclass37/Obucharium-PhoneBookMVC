using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PhoneBookMVC.Models
{
    public  class PersonDb:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Detail> Details { get; set; }
    }
}