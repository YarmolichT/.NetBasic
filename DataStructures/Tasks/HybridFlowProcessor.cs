using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        public DoublyLinkedList<T> processor;

        public HybridFlowProcessor()
        {
            processor = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            if (processor.Length == 0)
            {
                throw new InvalidOperationException();
            }
            return processor.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            processor.Add(item);
        }

        public T Pop()
        {
            if (processor.Length == 0)
            {
                throw new InvalidOperationException();
            }
            return processor.RemoveAt(processor.Length - 1);
        }

        public void Push(T item)
        {
            processor.Add(item);
        }
    }
}
