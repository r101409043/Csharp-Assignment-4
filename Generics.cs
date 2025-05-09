namespace CSharp_Assignment_4;

public class Generics
{
    class MyStack<T>
    {
        private List<T> items = new List<T>();

        public int Count()
        {
            return items.Count;
        }

        public void Push(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            T last = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return last;
        }
    }

    class MyList<T>
    {
        private List<T> items = new List<T>();

        public void Add(T element)
        {
            items.Add(element);
        }

        public T Remove(int index)
        {
            T removed = items[index];
            items.RemoveAt(index);
            return removed;
        }

        public bool Contains(T element)
        {
            return items.Contains(element);
        }

        public void Clear()
        {
            items.Clear();
        }

        public void InsertAt(T element, int index)
        {
            items.Insert(index, element);
        }

        public void DeleteAt(int index)
        {
            items.RemoveAt(index);
        }

        public T Find(int index)
        {
            return items[index];
        }
    }

    class GenericRepository<T> : IRepository<T> where T : Entity
    {
        private List<T> items = new List<T>();
        private bool isSaved = false;

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public void Save()
        {
            isSaved = true;
        }

        public IEnumerable<T> GetAll()
        {
            return items;
        }

        public T GetById(int id)
        {
            foreach (T item in items)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }
    }

    class Entity
    {
        public int Id { get; set; }
    }

    interface IRepository<T> where T : Entity
    {
        void Add(T item);
        void Remove(T item);
        void Save();
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
