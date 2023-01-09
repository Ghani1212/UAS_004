using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_004
{
    class Node
    {
        public int nim;
        public string name;
        public int kelas;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addNote() 
        {
            int nim;
            string name;
            int kelas;
            Console.Write("\nmasukkan nim murid: ");
            nim = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama murid: ");
            name = Console.ReadLine();
            Console.Write("\nmasukkan kelas murid: ");
            kelas = Convert.ToInt32(Console.ReadLine());
            Node newnode = new Node();
            newnode.nim = nim;
            newnode.name = name;
            newnode.kelas = kelas;
            
            if (START == null || (nim <= START.nim))
            {
                if ((START != null) && (nim == START.nim))
                {
                    Console.WriteLine();
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (nim >= current.nim))
            {
                if (nim == current.nim)
                {
                    Console.WriteLine();
                    return;
                }
                previous.next = current;
                previous.next = newnode;

            }
            newnode.next = current;
            previous.next = newnode;
        }
        
        public bool Search(int nim,ref Node Previous, ref Node current)
        {
            Previous = START;
            current = START;
            while ((current != null) && (nim != current.nim))
            {
                Previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }
        public void Traverse()
        {
            if (Listempty())
                Console.WriteLine("\nThe records in the list are: ");

            else
            {
                Console.WriteLine("\nThe records in the list are: ");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.nim + " " + currentNode.name + "\n" + currentNode.kelas + " ");
                Console.WriteLine();
            }
        }
        public bool Listempty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMENU");
                    Console.WriteLine("1. menambahkan data murid ");
                    Console.WriteLine("2. melihat data murid ");
                    Console.WriteLine("3. mencari data murid");
                    Console.WriteLine("4. EXIT");
                    Console.Write("\nEnter yout choice (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;

                        case '2':
                            {
                                obj.Traverse();
                            }
                            break;

                        case '3':
                            {
                                if (obj.Listempty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nEnter the nim of the " +
                                    "the student  whole record is to be searched:");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord not found.");
                                else
                                {
                                    Console.WriteLine("\nRecord not found");
                                    Console.WriteLine("\n nim : " + current.nim);
                                    Console.WriteLine("\n nama : " + current.name); 
                                    Console.WriteLine("\n kelas : " + current.kelas);
                                }

                            }
                            break;

                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                                break;
                            }
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("\nCheck for the value ");
                }
            }
        }
    }
}




//2. Single Linked List
//3. Data who can be stored and removed only from one end of the stack
//4. Rear, Front
//5. a. terdapat 5 kedalaman dalam struktur
//   b. Preorder Traversal (50, 48, 30, 20, 15, 25, 32, 31, 35, 70, 65, 67, 66 69, 90, 98, 94, 99 )