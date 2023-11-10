using Shop.DataAccess.Data;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repository
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public ApplicationDbContext _db;
        public PhotoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Photo obj)
        {
            var objFromDb = _db.Photos.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.PhotoUrl = obj.PhotoUrl;
            }
        }
    }
}
