using System;

namespace data_structures
{
    public class LinkedList
    {
        public Node Head { get; private set; }
        
        public LinkedList()
        {
            Head = null;
        }

        public Node Traverse(Func<Node, bool> predicate)
        {
            var current = Head;
            Node last = null;
            while (current != null)
            {
                var found = predicate(current);
                last = current;
                current = current.Next;
                if (found) break;
            }
            return last;
        }

        public void Traverse(Action<string> act)
        {
            var current = Head;
            while (current != null)
            {
                act(current.Val.ToString());
                current = current.Next;
            }
        }

        public void InsertAt(Node node, int val)
        {
            var newNode = new Node(val) {Next = node.Next};
            node.Next = newNode;
        }

        public Node Append(int val)
        {
            var newNode = new Node(val);
            if (Head == null)
            {
                Head = newNode;
            }
            else
            {
                var last = Traverse(n => n.Next == null);
                last.Next = newNode;
            }
            return newNode;
        }

        public void Remove(Node node)
        {
            if (Head.Equals(node))
            {
                Head = Head.Next;
            }
            else
            {
                var last = Head;
                var current = Head.Next;
                while (current != null)
                {
                    if (node.Equals(current)) break;
                    last = current;
                    current = current.Next;
                }
                last.Next = current.Next;
            }
        }
    }

    public class Node
    {
        public Node Next { get; set; }
        public int Val { get; }
        
        public Node(int value)
        {
            Val = value;
        }

        protected bool Equals(Node other)
        {
            return Val == other.Val;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node) obj);
        }

        public override int GetHashCode()
        {
            return Val;
        }
    }
}