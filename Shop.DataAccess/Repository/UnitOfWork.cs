using Shop.DataAccess.Data;
using Shop.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IUserLoginRepository UserLogin { get; private set; }

        public IPhotoRepository Photo { get; private set; }
        public IContentRepository Content { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            UserLogin = new UserLoginRepository(_db);
            Photo = new PhotoRepository(_db);
            Content = new ContentRepository(_db);

        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
