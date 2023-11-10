using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IUserLoginRepository UserLogin { get; }
        IPhotoRepository Photo { get; }
        IContentRepository Content { get; }
        void Save();
    }
}
