using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Xml.Linq;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>, IEnumerable<T>
    {
        public DoubleNode<T> head;
        public DoubleNode<T> tail;
        public int Length { get; private set; } = 0;
        public DoublyLinkedList()
        {
            head = tail = null;
            this.Length = 0;
        }
        
        public void Add(T e)
        {
            DoubleNode<T> newNode = new DoubleNode<T>(e);

            if (tail == null)
            {
                head = newNode;
            }
            else
            {
                tail.next = newNode;
                newNode.prev = tail;
            }
            tail = newNode;
            Length++;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > Length)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            if (index == Length)
            {
                Add(e);
                return;
            }

            DoubleNode<T> newNode = new DoubleNode<T>(e);
            DoubleNode<T> current = head;
            int i = 0;

            while (i < index)
            {
                current = current.next;
                i++;
            }

            if (current.prev == null)
            {
                head = newNode;
            }
            else
            {
                current.prev.next = newNode;
                newNode.prev = current.next;
            }

            newNode.prev = current;
            current.next = newNode;

            Length++;
        }

        public T ElementAt(int index)
        {
            DoubleNode<T> current = head;
            int i = 0;

            if (index < 0 || index >= Length || head == null)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            while (i < index)
            {
                current = current.next;
                i++;
            }
            return current.data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new DoublyLinkedListEnumerator<T>(head);
        }

        public void Remove(T item)
        {
            DoubleNode<T> current = head;
            DoubleNode<T> next;
            
            while (current  != null)
            {
                next = current.next;
                if(current.data.Equals(item))
                {
                    deleteNode(current);
                    break;
                }
                current = next;
            }
        }

        public T RemoveAt(int index)
        {
            DoubleNode<T> current = head;
            T deletedData;
            int i = 0;

            if (index < 0 || index >= Length || head == null)
            {
                throw new IndexOutOfRangeException("Index out of range");
            }

            while (i < index)
            {
                current = current.next;
                i++;
            }
            deletedData = current.data;
            deleteNode(current);
            return deletedData;
        }

        public void deleteNode(DoubleNode<T> del)
        {
            if(head == del)
            {
                head = del.next;
            }

            if(del.next != null)
            {
                del.next.prev = del.prev;
            }

            if(del.prev != null)
            {
                del.prev.next = del.next;
            }
            del = null;
            Length--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class DoubleNode<T>
    {
        public T data { get; private set; }
        public DoubleNode<T> next { get; set; }
        public DoubleNode<T> prev { get; set; }

        public DoubleNode(T data)
        {
            this.data = data;
            next = prev = null;
        }
    }
    public class DoublyLinkedListEnumerator<T> : IEnumerator<T>
    {
        private DoubleNode<T> current;

        public DoublyLinkedListEnumerator(DoubleNode<T> head)
        {
            current = new DoubleNode<T>(default(T))
            {
                next = head
            };
        }

        public T Current
        {
            get
            {
                return current.data;
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            current = current.next;
            return (current != null);
        }

        public void Reset()
        {
            current = null;
        }

        public void Dispose()
        {
            // Do nothing
        }
    }
}
