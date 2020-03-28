using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicDirectory.Models;

namespace MusicDirectory.Controllers
{
    public class NewRecordController : Controller
    {
        private readonly ConnectionStringClass _csc;

        public NewRecordController(ConnectionStringClass csc)
        {
            _csc = csc;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MusClass mc)
        {
            _csc.Add(mc);
            _csc.SaveChanges();
            ViewBag.message = "Запись " + mc.FirstName + " успешно сохранена!";
            return View(mc);
        }
    }
}