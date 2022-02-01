using Infra.Context;
using Infra.interfaces;

namespace Infra
{
    public class DefaultInfra : IDefaultInfra
    {
        private readonly DataContext _context;
        public DefaultInfra(DataContext context)
        {
            _context = context; 
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}