using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tg.application.Repository
{
    public interface IUnitOfWork
    {
         Task Save(CancellationToken cancellationToken);
    }
}