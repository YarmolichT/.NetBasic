using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class Node<T>
    {
        public T Data;
        public Node<T> Prev;
        public Node<T> Next;
        public Node(T value) => Data = value;   
    }

    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private Node<T> _head;
        public int Length { get; set; }

        public DoublyLinkedList()
        {
            _head = null;
            Length = 0;
        }

        public void Add(T e)
        {
            Node<T> newNode = new Node<T>(e);

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                var element = _head;

                for (int i = 0; i < Length; i++)
                {
                    if (i == Length - 1)
                    {
                        element.Next = newNode;
                        newNode.Prev = element;
                    }
                    element = element.Next;
                }
            }
            Length++;
        }

        public void AddAt(int index, T e)
        {
            Length++;
            var element = _head;
            Node<T> newNode = new Node<T>(e);

            if (index < 1)
            {
                newNode.Next = _head;
                newNode.Prev = null;
                _head = newNode;
            }
            else if (index == 1 && Length == 0)
            {
                newNode.Next = null;
                newNode.Prev = null;
                _head = newNode;
                return;
            }
            else if (index >= 1)
            {
                Node<T> temp = new Node<T>(e);
                temp = _head;

                for (int i = 0; i < index - 1; i++)
                {
                    if (temp != null)
                    {
                        temp = temp.Next;
                    }
                }
                if (temp != null)
                {
                    newNode.Next = temp.Next;
                    newNode.Prev = temp;
                    temp.Next = newNode;

                    if (newNode.Next != null)
                    {
                        newNode.Next.Prev = newNode;
                    }
                }
            }
        }

        public T ElementAt(int index)
        {
            var element = _head;

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
                element = element.Next;
            }
            return element.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(_head);
        }

        public void Remove(T item)
        {
            var element = _head;

            for (var i = 0; i <= Length - 1; i++)
            {
                if (element.Data.Equals(item) && i != 0)
                {
                    Node<T> elPrev = new Node<T>(element.Prev.Data);
                    elPrev.Next = element.Next;
                    element.Next = null;
                    element.Prev = null;
                    Length--;
                    break;
                }
                else if (_head.Data.Equals(item))
                {
                    _head = element.Next;
                    _head.Prev = null;
                    Length--;
                    break;
                }
                element = element.Next;
            }
        }

        public T RemoveAt(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            
            var element = _head;

            for (var i = 0; i <= index; i++)
            {
                if (index < 1 && index == i)
                {
                    _head = element;
                    _head.Prev = null;
                    Length--;
                    break;
                }
                else if (index >= 1 && index == i)
                {
                    var elPrev = element.Prev;
                    elPrev.Next = element.Next;

                    if (element.Next != null)
                    {
                        element.Next.Data = element.Prev.Data;
                    }

                    Length--;

                    break;
                }
                element = element.Next;
            }
            return element.Data;
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

            public T Current => _currentNode.Data;
            object IEnumerator.Current => _currentNode.Data;
            
            public void Dispose() { }

            public bool MoveNext()
            {
                _currentNode = _currentNode == null ? _head : _currentNode.Next;
                return _currentNode != null;
            }

            public void Reset()
            {
                _currentNode = _head;
            }
        }
    }
}
