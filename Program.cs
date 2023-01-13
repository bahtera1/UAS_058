using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_058
{
    class Node
    {

        public string JenisBarang;
        public string NamaBarang;
        public int HargaBarang;
        public int IDBarang;
        //point to the succeding node
        public Node next;
        public Node prev;
    }

    class DoubleLinkedList
    {
        Node START;
        //constructor

        public void addNode()
        {
            string jenis;
            string nama;
            int harga;
            int IDBarang;
            
            Console.WriteLine("\nMasukan Jenis Barang: ");
            jenis= (Console.ReadLine());

            Console.Write("\n Masukan Nama Barang: ");
            nama= Console.ReadLine();

            Console.Write("\n Masukan Harga Barang: ");
            harga = Convert.ToInt32(Console.ReadLine());

            Console.Write("\n Masukan ID Barang: ");
            IDBarang = Convert.ToInt32(Console.ReadLine());


            Node newNode = new Node();


            newNode.JenisBarang= jenis;
            newNode.NamaBarang = nama;
            newNode.HargaBarang = harga;
            newNode.IDBarang = IDBarang;

            //check if the list empty
            if(START==null )
            {
                if((START!=null) && (jenis!=START.JenisBarang)) 
                {
                    Console.WriteLine("\nBarang Duplikat tidak diterima");
                    return;
                }
                newNode.next = START;
                if(START!=null)
                    START.prev= newNode;
                newNode.next = null;
                START= newNode;
                return;
            }
            //if the node is to be inserted at between two node
            Node previous, current;
            for(current=previous=START;
                current!=null;
                previous=current, current=current.next)
            {
                if(jenis== current.JenisBarang)
                {
                    Console.WriteLine("\nDuplikat Barang Tidak diterima");
                    return;
                }
            }
            
            newNode.prev = current;
            newNode.prev = previous;

            //if the node is to be inserted at the end of the list
            if(current==null)
            {
                newNode.next = null;
                previous.next = newNode;
                return;
            }
            current.prev = newNode;
            current.next = newNode;
        }

        public bool Search(int rollNo, ref Node Previous, ref Node Current)
        {
            Previous = Current = START;
            while(Current!=null )
            {
                Previous= Current;
                Current= Current.next;
            }
            return(Current!=null);
        }


        public bool listEmpty()
        {
            if (START== null)
                return true;
            else
                return false;
        }

        


    }



    class Program
    {
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Tambah barang ke list");
                    Console.WriteLine("2. Cari Barang dari list (berdasarkan jenis barang)");
                    Console.WriteLine("3. Exit\n");
                    Console.WriteLine("Enter your choice (1-4): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        

                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.WriteLine("\nmasukan jenis barang: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.JenisBarang);
                                    Console.WriteLine("\nName: " + curr.NamaBarang);
                                }
                            }
                            break;
                        case '3':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check fot the values entered");
                }
            }
        }
    }
}

/*
 * 2. Harusnya menggunakan single linked list tapi saya menggunakan double linked list karena contoh project linked list saya error
 *      saya memilih algoritma linked list tersebut karena dari contoh project linked list ada fitur add, delete, view  search serta kita dapat memasukan 
 *      value lain ke dalam list tersebut
 *      misal jenis barang=gadged kita bisa menambahkan value lain seperti ID,Nama Dan Harga Barang Tersbut
 *      dan kita juga bisa mencari barang tersebut sesuai jenisnya
 *      
 * 
 * 3. Perbedaan Array dan Linked List yang paling terlihat adalah dari bentuknya
 *      linked list memiliki pointer sedangkan array tidak(hanya Value)
 *     
 * 4. Push dan Pop
 * 
 * 
 * 
 * 5. a.41,74
 *      16,53
 *      46,55
 *      63,70
 *      62,64
 *      
 *    b.inorder traversal
 *    
 *    cara bacanya cabang yang kiri dulu jika tidak ada atas lalu cabang kanan
 *    
 *     urutanya= traverse kiri  root  traverse kanan
 *      16 25 41 42 46 53 55 60 62 63 64 65 70 74
 *    
 *    

*/

































