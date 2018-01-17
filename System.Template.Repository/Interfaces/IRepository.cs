using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.Repository.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task Add(TEntity entity);
        Task Update(TEntity newEntity);
        Task Delete(TEntity entity);
        Task<IEnumerable<TEntity>> SelectAll();
        Task<TEntity> SelectByID(int entityId);
    }
}
