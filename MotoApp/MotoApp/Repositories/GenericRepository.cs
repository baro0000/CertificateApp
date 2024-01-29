using MotoApp.Entities;

namespace MotoApp.Repositories
{
    public class GenericRepository<TEntity> 
        where TEntity : class, IEntity, new()
    {
        protected readonly List<TEntity> _items = new();

        public TEntity GetById(int id)
        {
            return _items.Single( item => item.Id == id);  
        }

        public void Add(TEntity item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void Remove(TEntity item)
        {
            _items.Remove(item);
        }

        public void Save()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
