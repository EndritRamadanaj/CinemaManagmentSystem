﻿using CinemaManagementSystem.Data;
using CinemaManagementSystem.Data.Services;
using CinemaManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;
        public ActorsController(IActorsService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }

        //Get:ACtors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("FullName, ProfilePictureURL, Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            _service.Add(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        public IActionResult Details(int id)
        {
            var actorDetails = _service.GetById(id);

            if (actorDetails == null) return View("NotFound");

            return View(actorDetails);
        }

        //Get:ACtors/Edit/1
        public IActionResult Edit(int id)
        {
            var actorDetails = _service.GetById(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, FullName, ProfilePictureURL, Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            _service.Update(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get:ACtors/Delete/1
        public IActionResult Delete(int id)
        {
            var actorDetails = _service.GetById(id);

            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var actorDetails = _service.GetById(id);

            if (actorDetails == null) return View("NotFound");

            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
