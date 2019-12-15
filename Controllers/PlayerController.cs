using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Game.Controllers
{
    public class PlayerController : Controller
    {
        private readonly DatabaseContext _context;

        public PlayerController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult Players()
        {
            //Getting all players from the database
            var PlayersInDataBase = from ListOfPlayers in _context.Players orderby ListOfPlayers.Name select ListOfPlayers;

            //creating an empty list to fill it with players from the database
            List<PlayerVM> playerVM = new List<PlayerVM>();


            var ListOfTeams = from Teams in _context.Teams orderby Teams.Id select Teams;

            //looping through every single player from the database and adding them to the empty list created above
            foreach (var P in PlayersInDataBase)
            {

                playerVM.Add(new PlayerVM
                {
                    playerID = P.Id,
                    playerAge = P.Age,
                    playerHeight = P.Height,
                    playerName = P.Name,
                    playerSpeed = P.Speed,
                    playerWeight = P.Weight,
                    teamName = ListOfTeams.FirstOrDefault(t => t.Id == P.TeamsId)?.Name,
                    teamLocation = ListOfTeams.FirstOrDefault(t => t.Id == P.TeamsId)?.Location,
                });
            }

            //returns all the data
            return View(playerVM);
        }


        public IActionResult AddPlayer()
        {
            IEnumerable<SelectListItem> teamsList = _context.Teams.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name
            });

            ViewData["teamsList"] = teamsList;
            return View();
        }


        [HttpPost]
        public IActionResult AddPlayer(Players player)
        {

            //ModelState.Clear();
            if (ModelState.IsValid)
            {
                _context.Players.Add(player);

                _context.SaveChanges();

                ViewBag.UserMessage = "Player added successfully";
                ModelState.Clear();
            }
            return View();
        }

        [HttpPost]
        public IActionResult DeletePlayer(int ID)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {

                var D_player = _context.Players.FirstOrDefault(o => o.Id == ID);

                _context.Players.Remove(D_player);
                _context.SaveChanges();

                ModelState.Clear();
            }

            return RedirectToAction("Players");
        }

        public IActionResult DeletePlayer()
        {
            return View();
        }


        public IActionResult EditPlayer(int ID)
        {
            //Getting all players from the database
            var Edit_player = from E_P in _context.Players where E_P.Id == ID select E_P;





            //looping through every single player from the database and adding them to the empty list created above
            foreach (var P in Edit_player)
            {
                ViewBag.playerHeight = P.Height;
                ViewBag.playerSpeed = P.Speed;
                ViewBag.playerWeight = P.Weight;
                ViewBag.PlayerName = P.Name;
            }

            //returns all the data
            return View();
        }

        [HttpPost]
        public IActionResult EditPlayer(Players player)
        {
            Players orginalPlayer = _context.Find<Players>(player.Id);

            orginalPlayer.Height = player.Height;
            orginalPlayer.Weight = player.Weight;
            orginalPlayer.Speed = player.Speed;

            _context.Entry(orginalPlayer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Players");
        }


    }
}