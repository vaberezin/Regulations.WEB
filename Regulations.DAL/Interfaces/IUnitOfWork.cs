using System;
using Regulations.DAL.Models;
using Regulations.DAL.Models.ViewModels;
using System.Collections.Generic;
using System.Text;

namespace Regulations.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Regulation> Regulations { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
