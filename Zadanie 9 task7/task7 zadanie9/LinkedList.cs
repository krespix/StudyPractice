using System;
using System.Collections;
using System.Collections.Generic;

namespace task7_zadanie9
{
    public class LinkedList : IEnumerable
    {
        public Point firstPoint;
        public Point lastPoint;
        public int Count;


        public LinkedList()
        {
        }

        public void Add (int count)
        {
            Point temp  = new Point(count);
            if (count == 1)
            {
                firstPoint = temp;
            }
            if (firstPoint == null)
            {
                Add(count - 1);
            }
            
            if (count != 1)
            {
                lastPoint.Next = temp;
            }

            lastPoint = temp;
            Count++;
        }

        public void Remove(params int[] data)
        {
            foreach (var item in data)
            {
                _remove(item, firstPoint);
            }
        }

        public void _remove(int data, Point current, Point previous = null)
        {
            if (current == null)
            {
                return;
            }
            
            if (current.Data.Equals(data))
            {
                
                if (previous != null)
                {
                    
                    previous.Next = current.Next;
                    
                    if (current.Next == null)
                        lastPoint = previous;
                }
                else
                {
                    firstPoint = firstPoint.Next;

                    if (firstPoint == null)
                        lastPoint = null;
                }
                Count--;
            }

            previous = current;
            current = current.Next;

            _remove(data, current, previous);
        }


        public bool _search(int data, Point startPoint, out int index, bool contains = false, int count = 0)
        {
            if (startPoint == null)
            {
                index = -1;
                return false;
            }

            count++;
            
            if (contains)
            {
                index = count ;
                return true;
            }
            
            if (startPoint.Data.Equals(data))
            {
                index = count ;
                return true;
            }

            if (startPoint.Data.Equals(data))
                contains = true;
            
            _search(data, startPoint.Next, out index, contains, count);

            if (index != -1)
            {
                return true;
            }
            return false;
        }
        
        public void Clear()
        {
            firstPoint = null;
            lastPoint = null;
            Count = 0;
        }
        
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            Point current = firstPoint;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}