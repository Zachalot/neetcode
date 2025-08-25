using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList
{
    public class LinkedList
    {

        public Node tail; // points to the last element in the linked list (i.e. pointing backwards) contains null value
        public Node head; // points to the first element in the linked list, OR point to tail if list is empty.
        public int size = 0;

        public LinkedList()
        {

            tail = new Node();
            head = new Node(-1, tail);
            tail.nextNode = head;
        }

        public int Get(int index)
        {

            if (index >= size)
            {
                return -1;
            }
            else if (index < 0)
            {
                return -1;
            }
            
            Node current = new Node();
            current.nextNode = head.nextNode;

            for (int i = 0; i < index; ++i)
            {
                current.nextNode = current.nextNode.nextNode;
            }
            return current.nextNode.value;
        }

        public void InsertHead(int value)
        {

            Node newNode = new Node(value, head.nextNode); // TODO: Doesnt newNode go out of scope and get nuked after this method completes?
            head.nextNode = newNode;
            ++size;

            if (tail.nextNode == head)
            {
                tail.nextNode = newNode;
            }

        }

        public void InsertTail(int value)
        {

            Node newNode = new Node(value, tail);
            tail.nextNode.nextNode = newNode;
            tail.nextNode = newNode;
            ++size;

        }

        public bool Remove(int index)
        {

            if (index < 0 || index >= size)
            {
                return false;
            }

            Node nodePtr = new Node();
            nodePtr.nextNode = head;

            for (int i = 0; i < index; ++i)
            {
                nodePtr.nextNode = nodePtr.nextNode.nextNode;
            }
            nodePtr.nextNode.nextNode = nodePtr.nextNode.nextNode.nextNode;

            if (nodePtr.nextNode.nextNode == tail) // if we delete the one right before the tail, we need to update the tail pointer
            {
                tail.nextNode = nodePtr.nextNode;
            }

            --size;
            return true;
        }

        public List<int> GetValues()
        {

            Node nodePtr = new Node();
            nodePtr.nextNode = head.nextNode;

            List<int> list = new List<int>();

            // while(nodePtr.nextNode != tail)
            // {
            //     list.Add(nodePtr.nextNode.value);
            //     nodePtr.nextNode = nodePtr.nextNode.nextNode;
            // }
            for (int i = 0; i < size; ++i)
            {
                list.Add(nodePtr.nextNode.value);
                nodePtr.nextNode = nodePtr.nextNode.nextNode;
            }

            return list;
        }
    }

}
