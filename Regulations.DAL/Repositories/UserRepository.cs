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

    public class UserRepository : IRepository<User>
    {
        private RegulationContext db;

        public UserRepository(RegulationContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAllItems()
        {
            return db.Users;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Create(User book)
        {
            db.Users.Add(book);
        }

        public void Update(User book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<User> Find(Func<User, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
}


