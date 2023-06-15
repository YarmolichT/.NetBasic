using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class Node<T>
    {
        public T data;
        public Node<T> prev;
        public Node<T> next;
        public Node(T value) => data = value;   
    }

    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> head;
        public int Length { get; set; }

        public DoublyLinkedList()
        {
            head = null;
            Length = 0;
        }

        public void Add(T e)
        {
            Node<T> new_node = new Node<T>(e);

            if (head == null)
            {
                head = new_node;
            }
            else
            {
                var element = head;

                for (int i = 0; i < Length; i++)
                {
                    if (i == Length - 1)
                    {
                        element.next = new_node;
                        new_node.prev = element;
                    }
                    element = element.next;
                }
            }
            Length++;
        }

        public void AddAt(int index, T e)
        {
            Length++;
            var element = head;
            Node<T> new_node = new Node<T>(e);

            if (index < 1)
            {
                new_node.next = head;
                new_node.prev = null;
                head = new_node;
            }
            else if (index == 1 && Length == 0)
            {
                new_node.next = null;
                new_node.prev = null;
                head = new_node;
                return;
            }
            else if (index >= 1)
            {
                Node<T> temp = new Node<T>(e);
                temp = head;

                for (int i = 0; i < index - 1; i++)
                {
                    if (temp != null)
                    {
                        temp = temp.next;
                    }
                }
                if (temp != null)
                {
                    new_node.next = temp.next;
                    new_node.prev = temp;
                    temp.next = new_node;
                    if (new_node.next != null)
                    new_node.next.prev = new_node;
                }
            }
        }

        public T ElementAt(int index)
        {
            var element = head;

            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            for (var i = 0; i <= Length; i++)
            {

                if (index == i)
                {
                    break;
                }
                element = element.next;
            }
            return element.data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(head);
        }

        public void Remove(T item)
        {
            var element = head;

            for (var i = 0; i <= Length - 1; i++)
            {
                if (element.data.Equals(item) && i != 0)
                {
                    Node<T> elPrev = new Node<T>(element.prev.data);
                    elPrev.next = element.next;
                    element.next = null;
                    element.prev = null;
                    Length--;
                    break;
                }
                else if (head.data.Equals(item))
                {
                    head = element.next;
                    head.prev = null;
                    Length--;
                    break;
                }
                element = element.next;
            }
        }

        public T RemoveAt(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            
            var element = head;

            for (var i = 0; i <= index; i++)
            {
                if (index < 1 && index == i)
                {
                    head = element;
                    head.prev = null;
                    Length--;
                    break;
                }
                else if (index >= 1 && index == i)
                {
                    var elPrev = element.prev;
                    elPrev.next = element.next;

                    if (element.next != null)
                    {
                        element.next.data = element.prev.data;
                    }
                    Length--;
                    break;
                }
                element = element.next;
            }
            return element.data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class MyEnumerator<T> : IEnumerator<T>
        {
            private Node<T> _head;
            private Node<T> _currentNode;

            internal MyEnumerator(Node<T> head)
            {
                _head = head;
            }

            public T Current => _currentNode.data;
            object IEnumerator.Current => _currentNode.data;
            
            public void Dispose() { }

            public bool MoveNext()
            {
                _currentNode = _currentNode == null ? _head : _currentNode.next;
                return _currentNode != null;
            }

            public void Reset()
            {
                _currentNode = _head;
            }
        }
    }
}
