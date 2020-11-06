using Regulations.DAL.Interfaces;
using Regulations.DAL.Models;
using Regulations.DAL.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Regulations.DAL.Repositories
{
    class EFUnitOfWork : IUnitOfWork
    {
        private RegulationContext db;
        private UserRepository userRepository;
        private RegulationRepository regulationRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new RegulationContext(connectionString); //need to correct
        }
        public IRepository<Regulation> Regulations
        {
            get
            {
                if (regulationRepository == null)
                    regulationRepository = new RegulationRepository(db);
                return regulationRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
   
