using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainDotNetCore.Models;

namespace TrainDotNetCore.Services
{
    public interface IHeroService
    {
        List<Hero> FindAllHeroService();
        Hero FindHeroById(int id);
        void UpdateHero(Hero hero);
        void CreateHero(Hero hero);
        void DeleteHero(int id);
        List<Hero> FindHeroByName(string name);
    }
}
