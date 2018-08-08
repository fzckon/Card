using Microsoft.EntityFrameworkCore;
using System;

namespace EF.Core
{
    public class ContextFactory
    {
        public virtual T Create<T>()
            where T : DbContext
        {
            var context = Activator.CreateInstance<T>();
            return context;
        }
    }
}
