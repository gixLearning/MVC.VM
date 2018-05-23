using MVC.MV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.MV.Controllers
{
    public class PeopleController : Controller {
        // GET: People
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Index(string searchtext = null) {
            var peps = people
                        .OrderBy(p => p.Name)
                        .Where(p => searchtext == null || p.Name.StartsWith(searchtext, StringComparison.InvariantCultureIgnoreCase))
                        .Select(p => p);

            var model = new PersonViewModel { People = peps };

            return View(model);
        }

        // GET: People/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: People/Create
        public ActionResult Create() {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        public ActionResult Create(Person person) {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid) {
                    people.Add(
                        new Person {
                            Name = person.Name,
                            Phonenumber = person.Phonenumber,
                            City = person.City
                        });
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: People/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: People/Delete/5
        public ActionResult Delete(string id) {
            Person match = people.Find(p => p.Name == id);
            if(match != null && people.Contains(match)) {
                people.Remove(match);
            }
            return RedirectToAction("Index");
        }

        // POST: People/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private static List<Person> people = new List<Person>() {
            new Person {
                Name = "Mordark The Grim",
                Phonenumber = 050123456,
                City = "Tristram"
            },
            new Person {
                Name = "Carl Sagan",
                Phonenumber = 050234567,
                City = "Mordor"
            },
            new Person {
                Name = "Jon Snow",
                Phonenumber = 050345678,
                City = "Castle Black"
            },
            new Person {
                Name = "Dovahkiin Loudmouth",
                Phonenumber = 050456789,
                City = "Whiterun"
            },
            new Person {
                Name = "Johan Johansson",
                Phonenumber = 050567890,
                City = "Stockholm"
            }
        };
    }
}
