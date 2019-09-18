using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FightingApi.Models;
using Newtonsoft.Json;


namespace FightingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttackController : ControllerBase
    {
        private static List<Attack> Attacks = new List<Attack>()
        {
            new Attack {
                Id = 1,
                Name = "Simple Attack",
                Damage = 5,
                ArmorPen = 0
            },
            new Attack {
                Id = 2,
                Name = "Skill-1",
                Damage = 15,
                ArmorPen = 5
            },
            new Attack {
                Id = 3,
                Name = "Skill-2",
                Damage = 20,
                ArmorPen = 10
            }
        };

        public Player P1 = PlayersController.Players[0];
        public Player P2 = PlayersController.Players[1];

        // POST api/Attack
        [HttpPost]
        public ActionResult<IEnumerable<Player>> Post([FromBody] int id)
        {

            //P1 Hits P2
            if (P2.HitPoint > 0 && P1.HitPoint > 0) // If P2 and P1 alive, hit P2
            {
                P2.HitPoint = P2.HitPoint - Attacks[id].Damage;
                P2.Armor = P2.Armor - Attacks[id].ArmorPen;
            }
            //P2 uses a random skill after P1's hit
            Random random = new Random();
            int num = random.Next(3); //Generate a random attack id
            if (P1.HitPoint > 0 && P2.HitPoint > 0) // If P1 and P2 alive, hit P1
            {
                P1.HitPoint = P1.HitPoint - Attacks[num].Damage;
                P1.Armor = P1.Armor - Attacks[num].ArmorPen;
            }

            //If any HP goes below 0, equalize to 0
            if (P1.HitPoint < 0) { P1.HitPoint = 0; }
            if (P2.HitPoint < 0) { P2.HitPoint = 0; }

            return PlayersController.Players;
        }

        // GET api/Attack/GameState
        [HttpGet("GameState")]
        public string Get()
        {
            string res = gameState(P1.HitPoint, P2.HitPoint);
            return res;
        }
        string gameState(int p1hp, int p2hp)
        {
            string result;
            if (p1hp <= 0) { result = "P2 Wins!"; }
            else if (p2hp <= 0) { result = "P1 Wins!"; }
            else { result = "Game is going on"; }
            return result;
        }


    }
}