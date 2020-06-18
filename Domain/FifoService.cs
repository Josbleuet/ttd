using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class FifoService<T>
    {
        private Queue<T> queue;

        public FifoService()
        {
            queue = new Queue<T>();
        }

        public bool IsEmpty()
        {
            return !queue.Any();
        }

        public void Enqueue(T item)
        {
            queue.Enqueue(item);
        }

        public T Dequeue()
        {
            return queue.Dequeue();
        }
    }
}