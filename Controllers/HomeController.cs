using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Game.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Game.Controllers
{
    public class HomeController : Controller
    {

        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {

            _context = context;
        }

        public IActionResult Index()
        {
            var res = from g in _context.Games where g.startTime > DateTime.Now select g;
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

        



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

