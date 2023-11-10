using Shop.DataAccess.Data;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Shop.DataAccess.Repository
{
    public class ContentRepository : Repository<Content>, IContentRepository
    {
        public ApplicationDbContext _db;
        public ContentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        void IContentRepository.Update(Content obj)
        {
            var objFromDb = _db.Contents.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Content_1 = obj.Content_1;
                objFromDb.Content_2 = obj.Content_2;
                objFromDb.Content_3 = obj.Content_3;
            }
        }
    }
}
