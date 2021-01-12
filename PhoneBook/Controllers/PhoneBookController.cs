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
        //[HttpPost]
        //public ActionResult Index(string EntryName)
        //{
        //    PhoneBookDBHandler dbhandle = new PhoneBookDBHandler();
        //    ModelState.Clear();
        //    return View(dbhandle.GetDetailsByName(EntryName));
        //}
        [HttpPost]
        public ActionResult Index(string rboption,string EntryName, string PhoneNumber)
        {
            PhoneBookDBHandler dbhandle = new PhoneBookDBHandler();
            ModelState.Clear();

            if (rboption == "EntryName")
            {
                return View(dbhandle.GetDetailsByName(EntryName));
            }
            else if (rboption == "PhoneNumber")
            {
                return View(dbhandle.GetDetailsByPhoneNumber(PhoneNumber));
            }
            else
            {
                return View(dbhandle.GetDetails());
            }
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
                PhoneBookDBHandler pndb = new PhoneBookDBHandler();
                ModelState.Clear();
                if (pndb.GetDetailsByPhoneNumber(phonebookmodel.PhoneNumber).Count() != 0)
                {
                    TempData["Error"] = "Phone number is already available";
                }
                else
                {
                    if (ModelState.IsValid)
                    {

                        if (pndb.AddPhoneBookEntry(phonebookmodel))
                        {
                            TempData["Success"] = "Phone Book Details Added Successfully";
                            ModelState.Clear();
                        }

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
