using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Game.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Game.Controllers
{
    public class GameController : Controller
    {
        private readonly DatabaseContext _context;

        public GameController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Games()
        {
            var res = from g in _context.Games select g;
            List<GameVM> gameVM = new List<GameVM>();

            foreach (var item in res)
            {
                Teams teamA = _context.Teams.FirstOrDefault(o => o.Id == item.teamA);
                Teams teamB = _context.Teams.FirstOrDefault(o => o.Id == item.teamB);
                Games StartTime = _context.Games.FirstOrDefault(o => o.startTime == item.startTime);
                Games EndTime = _context.Games.FirstOrDefault(o => o.endTime == item.endTime);
                Games Score = _context.Games.FirstOrDefault(o => o.score == item.score);
                Games gameID = _context.Games.FirstOrDefault(o => o.Id == item.Id);

                gameVM.Add(new GameVM
                {
                    ID = gameID.Id,
                    TeamAName = teamA.Name,
                    TeamBName = teamB.Name,
                    StartTime = StartTime.startTime,
                    EndTime = EndTime.endTime,
                    Score = Score.score
                });
            }


            return View(gameVM);
        }


        public IActionResult AddGame()
        {
            IEnumerable<SelectListItem> teamA = _context.Teams.Select(teamA => new SelectListItem
            {
                Value = teamA.Id.ToString(),
                Text = teamA.Name
            });
            ViewData["teamA"] = teamA;

            IEnumerable<SelectListItem> teamB = _context.Teams.Select(teamB => new SelectListItem
            {
                Value = teamB.Id.ToString(),
                Text = teamB.Name
            });
            ViewData["teamB"] = teamB;
            return View();
        }

        [HttpPost]
        public IActionResult AddGame(Games game)
        {
            var gameres = from g in _context.Games select g;
            foreach (var item in gameres)
            {
                //ModelState.Clear();
                if (ModelState.IsValid)
                {
                    var oldGame = _context.Games.Find(game.Id);
                    var exGame = _context.Games.FirstOrDefault(i =>
                    (i.teamA == item.teamA && i.teamB == item.teamB && item.startTime == item.startTime && i.endTime == i.endTime) ||
                    (i.teamA == item.teamB && i.teamB == item.teamA && item.startTime == item.startTime && i.endTime == i.endTime));

                    if (exGame != oldGame)
                    {
                        _context.Games.Add(game);
                        ViewBag.UserMessage = "game created";

                    }
                    else
                    {
                        ViewBag.UserMessage = "Game already exist";
                    }
                }
            }

            _context.SaveChanges();
            return View();
        }



        public IActionResult EditGame(int ID)
        {
            //Getting all players from the database
            var Edit_Game = from E_G in _context.Games where E_G.Id == ID select E_G;

            //looping through every single player from the database and adding them to the empty list created above
            foreach (var P in Edit_Game)
            {
                ViewBag.GameScore = P.score;
            }

            //returns all the data
            return View();

        }

        [HttpPost]
        public IActionResult EditGame(Games game)
        {
            Games originalGame = _context.Games.Find(game.Id);

            originalGame.score = game.score;

            _context.Entry(originalGame).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Games");
        }

    }
}