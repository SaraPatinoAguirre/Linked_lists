using System;
using System.Collections.Generic;

public class DoubleList<T> where T : IComparable<T>
{
    private Node<T> head;
    private Node<T> tail;

    public DoubleList()
    {
        head = null;
        tail = null;
    }

    public bool IsEmpty()
    {
        return head == null;
    }

    public void Add(T value)
    {
        Node<T> newNode = new Node<T>(value);

        if (IsEmpty())
        {
            head = newNode;
            tail = newNode;
            return;
        }

        if (value.CompareTo(head.Value) < 0)
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
            return;
        }

        Node<T> current = head;
        while (current.Next != null && current.Next.Value.CompareTo(value) <= 0)
        {
            current = current.Next;
        }

        if (current.Next == null)
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
        else
        {
            newNode.Next = current.Next;
            newNode.Previous = current;
            current.Next.Previous = newNode;
            current.Next = newNode;
        }
    }

// 2 Show forward
    public void ShowForward()
    {
        if (IsEmpty())
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        Node<T> current = head;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }

    // 3 Show backward
    public void ShowBackward()
    {
        if (IsEmpty())
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        Node<T> current = tail;
        while (current != null)
        {
            Console.Write(current.Value + " ");
            current = current.Previous;
        }
        Console.WriteLine();
    }

    // 4 Change to descendent order
    public void ToDescendentOrder()
    {
        if (IsEmpty() || head == tail) return;

        Node<T> current = head;
        Node<T> temp = null;

        while (current != null)
        {
            temp = current.Previous;
            current.Previous = current.Next;
            current.Next = temp;
            current = current.Previous;
        }

        temp = head;
        head = tail;
        tail = temp;
    }

    // Count frequencies
    private Dictionary<T, int> GetFrequencies()
    {
        Dictionary<T, int> counts = new Dictionary<T, int>();
        Node<T> current = head;

        while (current != null)
        {
            if (counts.ContainsKey(current.Value))
            {
                counts[current.Value]++;
            }
            else
            {
                counts[current.Value] = 1;
            }
            current = current.Next;
        }
        return counts;
    }

    // 5 Show modes
    public void ShowModes()
    {
        if (IsEmpty())
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        var counts = GetFrequencies();
        int maxCount = 0;

        foreach (var pair in counts)
        {
            if (pair.Value > maxCount) maxCount = pair.Value;
        }

        List<T> modes = new List<T>();
        foreach (var pair in counts)
        {
            if (pair.Value == maxCount) modes.Add(pair.Key);
        }

        if (modes.Count == 1)
        {
            Console.WriteLine("The mode is: " + modes[0]);
        }
        else
        {
            Console.WriteLine("The modes are: " + string.Join(" and ", modes));
        }
    }

    // 6 Show graph
    public void ShowGraph()
    {
        if (IsEmpty())
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        var counts = GetFrequencies();
        foreach (var pair in counts)
        {
            string stars = new string('*', pair.Value);
            Console.WriteLine($"{pair.Key} {stars}");
        }
    }

    // 7 Exist
    public bool Exists(T value)
    {
        Node<T> current = head;
        while (current != null)
        {
            if (current.Value.Equals(value)) return true;
            current = current.Next;
        }
        return false;
    }

    // 8. Delete occurrence
    public bool DeleteOne(T value)
    {
        Node<T> current = head;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                if (current == head)
                {
                    head = head.Next;
                    if (head != null) head.Previous = null;
                    else tail = null;
                }
                else if (current == tail)
                {
                    tail = tail.Previous;
                    tail.Next = null;
                }
                else
                {
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;
                }
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    // 9. Delete all occurrences
    public void DeleteAll(T value)
    {
        bool deleted = DeleteOne(value);
        while (deleted)
        {
            deleted = DeleteOne(value);
        }
    }
}