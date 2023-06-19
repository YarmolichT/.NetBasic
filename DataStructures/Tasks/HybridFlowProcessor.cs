using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        public DoublyLinkedList<T> Processor;

        public HybridFlowProcessor()
        {
            Processor = new DoublyLinkedList<T>();
        }

        public T Dequeue()
        {
            if (Processor.Length == 0)
            {
                throw new InvalidOperationException();
            }
            return Processor.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            Processor.Add(item);
        }

        public T Pop()
        {
            if (Processor.Length == 0)
            {
                throw new InvalidOperationException();
            }
            return Processor.RemoveAt(Processor.Length - 1);
        }

        public void Push(T item)
        {
            Processor.Add(item);
        }
    }
}
