using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainDotNetCore.Models;

namespace TrainDotNetCore.Services
{
    public class HeroService : IHeroService
    {
        private readonly DotNetCoreContext context;
        public HeroService()
        {
            this.context = new DotNetCoreContext();
        }

        public void CreateHero(Hero hero)
        {
            this.context.Add(hero).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            this.context.SaveChanges();
        }

        public void DeleteHero(int id)
        {
            Hero hero = this.context.Hero.Where(x => x.Id == id).FirstOrDefault();
            this.context.Entry(hero).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            this.context.SaveChanges();            
        }

        public List<Dictionary<string, object>> FindAllHeroService()
        {
            try
            {
                List<Dictionary<string,object>> data = new List<Dictionary<string,object>>();
                List<Hero> heroes = this.context.Hero.ToList();
                for(int x = 0; x < heroes.Count(); x++)
                {
                    Dictionary<string, object> temp = new Dictionary<string, object>();
                    temp.Add("id", heroes[x].Id);
                    temp.Add("name", heroes[x].Name);
                    temp.Add("index", x + 1);
                    data.Add(temp);
                }
                return data;
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Hero FindHeroById(int id)
        {
            try
            {
                return this.context.Hero.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Hero> FindHeroByName(string name)
        {
            return this.context.Hero.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public void UpdateHero(Hero hero)
        {
            this.context.Entry(hero).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            this.context.SaveChanges();
        }


    }
}
