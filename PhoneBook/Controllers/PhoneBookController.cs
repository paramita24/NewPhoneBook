using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class PhoneBookController : Controller
    {
        // GET: PhoneBook
        public ActionResult Index()
        {
            PhoneBookDBHandler dbhandle = new PhoneBookDBHandler();
            ModelState.Clear();
            return View(dbhandle.GetDetails());
        }

        // GET: PhoneBook/Details/5
        [HttpPost]
        public ActionResult Index(string entryname)
        {
            PhoneBookDBHandler dbhandle = new PhoneBookDBHandler();
            ModelState.Clear();
            return View(dbhandle.GetDetailsByName(entryname));
        }

        // GET: PhoneBook/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneBook/Create
        [HttpPost]
        public ActionResult Create(PhoneBookModel phonebookmodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PhoneBookDBHandler pndb = new PhoneBookDBHandler();
                    if (pndb.AddPhoneBookEntry(phonebookmodel))
                    {
                        ViewBag.Message = "Phone Book Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: PhoneBook/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhoneBook/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
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

        // GET: PhoneBook/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PhoneBook/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
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
    }
}
