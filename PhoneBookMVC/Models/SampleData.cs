using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PhoneBookMVC.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<PersonDb>
    {
        protected override void Seed(PersonDb context)
        {
            context.Categories.Add(new Category() {Name = "Job"});
            context.Categories.Add(new Category() { Name = "Family" });
            context.Categories.Add(new Category() { Name = "Friend" });
            base.Seed(context);
        }
    }
}