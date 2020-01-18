using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dynamic_List
{
    public class Dynamic_List_Class<T>
    {
        private class ListNode
        {
            public T Element { get; set; }
            public ListNode NextNode { get; set; }
            public ListNode(T element)
            {
                Element = element;
                NextNode = null;
            }

            public ListNode(T element, ListNode prevNode)
            {
                Element = element;
                prevNode.NextNode = this;
            }

        }

        /// <summary>
        /// points to the start of the list
        /// </summary>
        private ListNode head;
        /// <summary>
        /// points to the end of the list
        /// </summary>
        private ListNode tail;
        /// <summary>
        /// counts the numbers of elements in the list
        /// </summary>
        private int count;

        /// <summary>
        /// constructor that initializes an empty DynamicList
        /// </summary>
        public Dynamic_List_Class()
        {
            head = null;
            tail = null;
            count = 0;
        }

        /// <summary>
        /// add element at the end of the list
        /// </summary>
        /// <param name="item">the element to be added</param>

        public void Add(T info)
        {
            if (this.head == null)
            {
                this.head = new ListNode(info);
                this.tail = head;
            }
            else
            {
                ListNode newItemOfTheList = new ListNode(info, tail);
                this.tail = newItemOfTheList;
            }

            count++;
        }


        public T RemoveAt(int index)
        {
            if (index >= count || index < 0)
                throw new ArgumentOutOfRangeException("Invalid index: " + index);

            //Find the element at the specific index
            int currentIndex = 0;
            ListNode currentNode = this.head;
            ListNode prevNode = null;

            while (currentIndex < index)
            {
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            //Remove the found element from the list of nodes
            RemoveListNode(currentNode, prevNode);

            //Return the removev element
            return currentNode.Element;
        }

        /// <summary>
        /// Remove the specified node from the list of node
        /// </summary>
        /// <param name="node">the node for removal</param>
        /// <param name="prevNode">the predecessor of node</param>
        private void RemoveListNode(ListNode node, ListNode prevNode)
        {
            count--;
            if (count == 0)
            {
                // the list becomes empty -> remove head and tail
                this.head = null;
                this.tail = null;
            }
            else if (prevNode == null)
            {
                //the head node was removed --> update the head
                this.head = node.NextNode;
            }
            else
            {
                //redirect the pointers to skip the removed node
                prevNode.NextNode = node.NextNode;
            }

            if (object.ReferenceEquals(this.tail, node))
                this.tail = prevNode;
        }

        /// <summary>
        /// removes the specified item and return its index
        /// </summary>
        /// <param name="item">the item for removal</param>
        /// <returns>the index of the element or -1 if it does not exist</returns>
        public int Remove(T item)
        {
            // find the element containing the searched item

            int currentIndex = 0;
            ListNode currentNode = this.head;
            ListNode prevNode = null;

            while (currentNode != null)
            {
                if (object.Equals(currentNode.Element, item))
                    break;

                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;

            }

            if (currentNode != null)
            {
                // the element is found in the list -> remove it
                RemoveListNode(currentNode, prevNode);
                return currentIndex;
            }
            else
            {
                //the element is not found in the list -> return -1
                return -1;
            }

        }

        /// <summary>
        /// searches for given element in the list
        /// </summary>
        /// <param name="item">the item to be searched</param>
        /// <returns>
        /// the index of the first occurrence of the element 
        /// in the list or -1 whe it is not found
        /// </returns>
        public int IndexOf(T item)
        {
            int index = 0;
            ListNode currentNode = this.head;

            while (currentNode != null)
            {
                if (object.Equals(currentNode.Element, item))
                {
                    return index;
                }
                currentNode = currentNode.NextNode;
                index++;
            }
            return -1;
        }


        /// <summary>
        /// checks if the specified element exists in the list
        /// </summary>
        /// <param name="item">the item to be checked</param>
        /// <returns>true if the element exist or false otherwise</returns>
        public bool Cotains(T item)
        {
            int index = IndexOf(item);
            bool found = (index != -1);

            return found;
        }

        /// <summary>
        /// gets or sets the element at the specified position
        /// </summary>
        /// <param name="index">the position of the element [0....count-1]</param>
        /// <returns>the items at the specified index</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// when an invalid index is specified
        /// </exception>
        public T this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                    throw new ArgumentException("invalid index " + index);

                ListNode currentNode = this.head;
                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }
                return currentNode.Element;
            }

            set
            {
                if (index >= count || index < 0)
                    throw new ArgumentOutOfRangeException("invalid index " + index);

                ListNode currentNode = this.head;
                for (int i = 0; i < index; i++)
                    currentNode = currentNode.NextNode;

                currentNode.Element = value;
            }
        }


        /// <summary>
        /// gets the count of elements in the list
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }

        }
    }
}
