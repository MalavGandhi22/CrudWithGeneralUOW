using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UOWGeneral.Models;

namespace UOWGeneral.Controllers
{
    //public class PersonController : Controller
    //{
    //    private PersonContaxt db = new PersonContaxt();

    //    //
    //    // GET: /Person/

    //    public ActionResult Index()
    //    {
    //        return View(db.Persons.ToList());
    //    }

    //    //
    //    // GET: /Person/Details/5

    //    public ActionResult Details(int id = 0)
    //    {
    //        Person person = db.Persons.Find(id);
    //        if (person == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(person);
    //    }

    //    //
    //    // GET: /Person/Create

    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    //
    //    // POST: /Person/Create

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create(Person person)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Persons.Add(person);
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }

    //        return View(person);
    //    }

    //    //
    //    // GET: /Person/Edit/5

    //    public ActionResult Edit(int id = 0)
    //    {
    //        Person person = db.Persons.Find(id);
    //        if (person == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(person);
    //    }

    //    //
    //    // POST: /Person/Edit/5

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit(Person person)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(person).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        return View(person);
    //    }

    //    //
    //    // GET: /Person/Delete/5

    //    public ActionResult Delete(int id = 0)
    //    {
    //        Person person = db.Persons.Find(id);
    //        if (person == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(person);
    //    }

    //    //
    //    // POST: /Person/Delete/5

    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        Person person = db.Persons.Find(id);
    //        db.Persons.Remove(person);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        db.Dispose();
    //        base.Dispose(disposing);
    //    }
    //}

    public class PersonController : Controller
    {
        private GenericUnitOfWork uow = null;
        //
        // GET: /Persons/

        public PersonController()
        {
            uow = new GenericUnitOfWork();
        }

        public PersonController(GenericUnitOfWork uow_)
        {
            this.uow = uow_;
        }

        public ActionResult Index()
        {
            return View(uow.Repository<Person>().GetAll().ToList());
        }

        //
        // GET: /Persons/Details/5

        public ActionResult Details(int id = 0)
        {
            Person Person = uow.Repository<Person>().Get(c => c.ID == id);
            if (Person == null)
            {
                return HttpNotFound();
            }
            return View(Person);
        }

        //
        // GET: /Persons/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Persons/Create

        [HttpPost]
        public ActionResult Create(Person Person)
        {
            if (ModelState.IsValid)
            {
                uow.Repository<Person>().Add(Person);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Person);
        }

        //
        // GET: /Persons/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Person Person = uow.Repository<Person>().Get(c => c.ID == id);
            if (Person == null)
            {
                return HttpNotFound();
            }
            return View(Person);
        }

        //
        // POST: /Persons/Edit/5

        [HttpPost]
        public ActionResult Edit(Person Person)
        {
            if (ModelState.IsValid)
            {
                uow.Repository<Person>().Update(Person);
                uow.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Person);
        }

        //
        // GET: /Persons/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Person Person = uow.Repository<Person>().Get(c => c.ID == id);
            if (Person == null)
            {
                return HttpNotFound();
            }
            return View(Person);
        }

        //
        // POST: /Persons/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Person Person = uow.Repository<Person>().Get(c => c.ID == id);
            uow.Repository<Person>().Delete(Person);
            uow.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}