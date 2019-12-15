using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Game.Controllers
{
    public class TeamController : Controller
    {

        private readonly DatabaseContext _context;

        public TeamController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Teams()
        {
            var results = from p in _context.Teams orderby p.Name select p;

            return View(results.ToList());
        }


        public IActionResult AddTeam()
        {
            IEnumerable<SelectListItem> teamLoc = _context.Teams.Select(loc => new SelectListItem
            {
                Value = loc.Location,
                Text = loc.Location
            });
            ViewData["teamLoc"] = teamLoc;
            return View();
        }

        [HttpPost]
        public IActionResult AddTeam(Teams team)
        {

            ModelState.Clear();
            if (ModelState.IsValid)
            {
                var ex_team = _context.Teams.FirstOrDefault(t => t.Name == team.Name);
                if (ex_team == null)
                {
                    _context.Teams.Add(team);
                    _context.SaveChanges();

                    ViewBag.UserMessage = "Team added successfully";
                    ModelState.Clear();
                }

                else
                {
                    ViewBag.USerMessage = "Team ALready exist";
                }


            }
            return View();
        }

        [HttpPost]
        public IActionResult DeleteTeam(int ID)
        {
            if (ModelState.IsValid)
            {
                var D_team = _context.Teams.FirstOrDefault(o => o.Id == ID);
                _context.Teams.Remove(D_team);
                _context.SaveChanges();
                ModelState.Clear();
            }

            return RedirectToAction("Teams");
        }

        public IActionResult DeleteTeam()
        {
            return View();
        }


        public IActionResult EditTeam(int ID)
        {
            var Edit_Team = from E_T in _context.Teams where E_T.Id == ID select E_T;

            foreach (var P in Edit_Team)
            {
                ViewBag.teamName = P.Name;
            }
            return View();
        }

        [HttpPost]
        public IActionResult EditTeam(Teams team)
        {
            Teams orginalTeam = _context.Find<Teams>(team.Id);

            orginalTeam.Name = team.Name;

            _context.Entry(orginalTeam).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Teams");
        }

    }
}