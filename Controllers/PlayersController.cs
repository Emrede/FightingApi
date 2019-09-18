using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FightingApi.Models;

namespace FightingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        public static List<Player> Players = new List<Player>()
        {
            new Player {
                Id = 1,
                Name = "P1",
                HitPoint = 100,
                Armor = 100
            },
            new Player {
                Id = 2,
                Name = "Sub-Zero",
                HitPoint = 100,
                Armor = 100
            },
        };

        // GET api/players
        [HttpGet]
        public ActionResult<IEnumerable<Player>> Get()
        {
            return Players;
        }

        // GET api/players/5
        [HttpGet("{id}")]
        public ActionResult<Player> Get(int id)
        {
            Player player = Players.Single(p => p.Id == id);
            return player;
        }
        [HttpGet("NewGame")]
        public ActionResult<IEnumerable<Player>> Post()
        {
            Players = new List<Player>(){
            new Player {
                Id = 1,
                Name = "P1",
                HitPoint = 100,
                Armor = 100
            },
            new Player {
                Id = 2,
                Name = "Sub-Zero",
                HitPoint = 100,
                Armor = 100
            },
        };
            return Players;
        }

        // POST api/players
        [HttpPost]
        public ActionResult<IEnumerable<Player>> Post([FromBody] Player newPlayer)
        {
            Players.Add(newPlayer);
            return Players;
        }

        // PUT api/players/5
        [HttpPut("{id}")]
        public ActionResult<IEnumerable<Player>> Put(int id, [FromBody] int newHitPoint)
        {
            Player player = Players.Single(p => p.Id == id);
            player.HitPoint = newHitPoint;
            return Players;
        }

        // DELETE api/players/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Player player = Players.Single(p => p.Id == id);
            Players.Remove(player);

        }
        // public List<Player> getPlayerList()
        // {
        //     return Players;
        // }
    }

}
