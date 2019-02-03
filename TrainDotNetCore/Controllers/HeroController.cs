using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainDotNetCore.Models;
using TrainDotNetCore.Services;

namespace TrainDotNetCore.Controllers
{
    [Route("api/hero")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService heroService;

        public HeroController(IHeroService heroServiceTemp)
        {
            this.heroService = heroServiceTemp;            
        }

        [HttpGet]
        public List<Hero> FindAllHeroService()
        {
            return heroService.FindAllHeroService();
        }

        [HttpGet("{id}")]
        public Hero FindAllHeroService(int id)
        {
            return heroService.FindHeroById(id);
        }

        [HttpPut]
        public IActionResult UpdateHero(Hero hero)
        {
            heroService.UpdateHero(hero);
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateHero(Hero hero)
        {
            heroService.CreateHero(hero);
            return CreatedAtAction(nameof(FindAllHeroService), new { id = hero.Id }, hero);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHero(int id)
        {
            heroService.DeleteHero(id);
            return Ok();
        }

        [HttpGet("FindHeroByName")]
        public List<Hero> FindHeroByName(string name)
        {
            return heroService.FindHeroByName(name);
        }
    }
}