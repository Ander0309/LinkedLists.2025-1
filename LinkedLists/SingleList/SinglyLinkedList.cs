namespace SingleList;

public class SinglyLinkedList<T> where T : IComparable<T>
{
    private SingleNode<T>? head;

    public SinglyLinkedList()
    {
        head = null;
    }

    public override string ToString()
    {
        var output = string.Empty;
        var currentNode = head;
        while (currentNode != null)
        {
            output += $"{currentNode.Data} -> ";
            currentNode = currentNode.Next;
        }
        output += "null";
        return output;
    }

    public void InsertAtBeginning(T data)
    {
        var newNode = new SingleNode<T>(data);
        newNode.Next = head;
        head = newNode;
    }

    public void InsertAtEnd(T data)
    {
        var newNode = new SingleNode<T>(data);
        if (head == null)
        {
            head = newNode;
            return;
        }

        var current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = newNode;
    }

    public bool Contains(T data)
    {
        var current = head;
        while (current != null)
        {
            if (current.Data!.Equals(data))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void Clear()
    {
        head = null;
    }

    public void Remove(T data)
    {
        if (head == null)
        {
            return;
        }

        if (head.Data!.Equals(data))
        {
            head = head.Next;
            return;
        }

        var current = head;
        while (current.Next != null && !current.Next.Data!.Equals(data))
        {
            current = current.Next;
        }
        if (current.Next != null)
        {
            current.Next = current.Next.Next;
        }
    }

    public void Reverse()
    {
        SingleNode<T> prev = null;
        SingleNode<T> current = head;
        SingleNode<T> next = null;
        while (current != null)
        {
            // Store the next node
            next = current.Next!;
            // Reverse the current node's pointer
            current.Next = prev;
            // Move the pointers one position ahead
            prev = current;
            current = next;
        }
        head = prev;
    }

    public void Orden(bool ascendente = true)
    {
        if (head == null || head.Next == null)
            return;

        bool swapped;
        do
        {
            swapped = false;
            var current = head;
            while (current.Next != null)
            {
                int comparacion = current.Data.CompareTo(current.Next.Data);
                bool debeIntercambiar = ascendente ? comparacion > 0 : comparacion < 0;

                if (debeIntercambiar)
                {
                    T temp = current.Data; // value actual node
                    current.Data = current.Next.Data;  // value next node
                    current.Next.Data = temp;  // change node values 
                    swapped = true;  // see new change
                }
                current = current.Next;  // advance to the next node
            }
        } while (swapped);
    }
}
