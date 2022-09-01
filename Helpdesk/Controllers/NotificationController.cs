﻿using Helpdesk.Data;
using Helpdesk.Interfaces;
using Helpdesk.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helpdesk.Controllers
{
    [Authorize]
    [Authorize(Roles = "Administrator")]
    public class NotificationController : Controller
    {
        private readonly ApplicationDbContext _db;


        private readonly INotificationControllerService service;


        public NotificationController(INotificationControllerService service, ApplicationDbContext db)
        {
            this.service = service;
            this._db = db;
        }
      

        public IActionResult Index() => View(service.GetAllNotifications());

        public IActionResult Create()
        {

            return View();
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Notification obj)
        {

            if (ModelState.IsValid)
            {
                service.Create2(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
