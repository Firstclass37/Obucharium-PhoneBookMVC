using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhoneBookMVC.Models
{
    public class DbManager
    {
        private PersonDb db = new PersonDb();

        public IEnumerable<Person> People
        {
            get { return db.People.Include("Category").Include("Detail"); }
        }
        public IEnumerable<Detail> Details
        {
            get { return db.Details; }
        }
        public IEnumerable<Category> Categories
        {
            get { return db.Categories; }
        }

        public Category GetCategory(int id)
        {
            return db.Categories.First(c => c.Id == id);
        }

        public void SaveCategory(Category category)
        {
            if (category == null)
            {
                return;
            }
            if (category.Id == 0)
            {
                db.Categories.Add(category);
            }
            else
            {
                   
                db.Entry(category).State = EntityState.Modified;
            }
            db.SaveChanges();
        }
        public void RemoveCategory(Category category)
        {
            if (category != null)
            {
                var tempPersons = db.People.Where(p=>p.CategoryId == category.Id).ToList();
                foreach (var p in tempPersons)
                {
                    RemovePerson(p);
                }
                db.Categories.Remove(category);
                db.SaveChanges();
            }
        }
        public void RemoveCategory(int id)
        {
            var target = db.Categories.Find(id);
            if (target != null)
            {
                RemoveCategory(target);
            }
        }

        public Person GetPerson(int id)
        {
            return db.People.Include("Category").Include("Detail").First(p=>p.Id==id);
        }
        public void SavePerson(Person person)
        {
            if (person == null)
            {
                return;
            }
            if (person.Id == 0)
            {
                db.People.Add(person);
            }
            else
            {
                var targetPerson = db.People.Find(person.Id);
                if (targetPerson != null)
                {
                    targetPerson.CategoryId = person.CategoryId;
                    targetPerson.Name = person.Name;
                    targetPerson.Surname = person.Surname;
                    targetPerson.PhoneNumber = person.PhoneNumber;

                    if (targetPerson.DetailId != 0 )
                    {
                        var targetDetails = db.Details.Find(targetPerson.DetailId);
                        if (targetDetails != null)
                        {
                            targetDetails.Address1 = person.Detail.Address1;
                            targetDetails.Address2 = person.Detail.Address2;
                            targetDetails.LastName = person.Detail.LastName;
                            targetDetails.BirthDateTime = person.Detail.BirthDateTime;
                            targetDetails.Email = person.Detail.Email;
                        }
                    }
                    else if(person.Detail != null)
                    {
                        var tempDetail = person.Detail;
                        tempDetail.PersonId = targetPerson.Id;
                        db.Details.Add(tempDetail);
                    }
                }             
            }
            db.SaveChanges();
        }
        public void RemovePerson(Person person)
        {
            if (person == null)
            {
                return;
            }
            if (person.DetailId != 0)
            {
                var tempDetail = db.Details.Find(person.DetailId);
                if (tempDetail != null)
                {
                    db.Details.Remove(tempDetail);
                }
            }
            db.People.Remove(person);
            db.SaveChanges();
        }
        public void RemovePerson(int id)
        {
            var person = db.People.Find(id);
            if (person != null)
            {
                RemovePerson(person);
            }
        }
        

    }
}