﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class PersonController : Controller
    {

        public ActionResult wf()
        {
            var service = new workflow();
            string pid = service.test();
            return Content(pid);
        }

        // GET: Person
        public ActionResult Index()
        {
            var db = new DatabaseEntities();
            var data = db.Person.ToList();
            return View(data);
        }

        public ActionResult IndexPhone()
        {
            var db = new DatabaseEntities();
            var data = db.Person.Where(m=>m.Phone=="789").ToList();
            return View(data);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            var db = new DatabaseEntities();
            var data = db.Person.ToList();
            var model = data.Where(m => m.Id == id).First();
            return View(model);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person model)
        {
            try
            {
                var db = new DatabaseEntities();
                db.Person.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            var db = new DatabaseEntities();
            var data = db.Person.ToList();
            var model = data.Where(m => m.Id == id).First();
            return View(model);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(Person editmodel)
        {
            try
            {
                // TODO: Add update logic here
                var db = new DatabaseEntities();
                var model=db.Person.Where(m => m.Id == editmodel.Id).First();

                model.Name = editmodel.Name;
                model.Phone = editmodel.Phone;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            var db = new DatabaseEntities();
            var data = db.Person.ToList();
            var model = data.Where(m => m.Id == id).First();
            return View(model);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(Person delmodel)
        {
            try
            {
                var db = new DatabaseEntities();
                var model = db.Person.Where(m => m.Id == delmodel.Id).First();

                db.Person.Remove(model);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
