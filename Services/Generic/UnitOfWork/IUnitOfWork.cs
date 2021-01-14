using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fri2Ends.Identity.Services.Generic.UnitOfWork
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext 
    {
    }
}
