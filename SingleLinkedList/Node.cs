using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedList
{
    public class Node
    {

        public int value;
        public Node nextNode;

        public Node()
        {
            value = -11;
            nextNode = null;
        }

        public Node(int inputVal)
        {
            this.value = inputVal;
        }

        public Node(int inputVal, Node next)
        {
            this.value = inputVal;
            nextNode = next;
        }
    }
}
