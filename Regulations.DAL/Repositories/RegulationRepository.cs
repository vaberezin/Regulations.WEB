using System;
using System.Collections.Generic;
using Regulations.DAL.Models;
using Regulations.DAL.Interfaces;
using Regulations.DAL.Models.ViewModels;
using Regulations.DAL.Repositories;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Regulations.DAL.Repositories
{

    public class RegulationRepository : IRepository<Regulation>
    {
        private RegulationContext db;

        public RegulationRepository(RegulationContext context)
        {
            this.db = context;
        }

        public IEnumerable<Regulation> GetAllItems()
        {
            return db.Regulations;
        }

        public Regulation Get(int id)
        {
            return db.Regulations.Find(id);
        }

        public void Create(Regulation reg)
        {
            db.Regulations.Add(reg);
        }

        public void Update(Regulation reg)
        {
            db.Entry(reg).State = EntityState.Modified;
        }

        public IEnumerable<Regulation> Find(Func<Regulation, Boolean> predicate)
        {
            return db.Regulations.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}
