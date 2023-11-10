using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repository.IRepository
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        void Update(Photo obj);

    }
}
