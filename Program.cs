using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ağaç__Tree__Veri_Yapısı_ve_Ağaç_Üzerinde_Dolaşma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("AĞAÇ VERİ YAPISI");

            Tree bst = new Tree(); //BST= binary search tree (ikili arama ağacı)
                                   //ağaç yapısının nesnesini oluşturduk
            bst.root = bst.insert( bst.root, 10);
            bst.root = bst.insert(bst.root, 5);
            bst.root = bst.insert(bst.root, 15);
            bst.root = bst.insert(bst.root, 20);
            bst.root = bst.insert(bst.root, 3);
            bst.root = bst.insert(bst.root, 12);
            bst.root = bst.insert(bst.root, 8);


            //yazılan fonksiyona göre bst.root olarak girdiğimiz sayıları dizecek.
            Console.WriteLine("preOrder : ");
            bst.preOrder(bst.root);  

            Console.WriteLine();

            Console.WriteLine("inOrder : ");
            bst.inOrder(bst.root);

            Console.WriteLine();

            Console.WriteLine("postOrder : ");
            bst.postOrder(bst.root);

            Console.WriteLine();

            Console.ReadKey();
        }                          
    }


    class Node
    {
        public int data; //ikili ağaç yapısı 2 göstergesi olacak
        public Node left;
        public Node right;


        public Node (int data)  //ağaca düğüm ekleyeceği zaman düğüm eklemek zorunda
        {
            this.data = data;  //düğüm yapısı oluşturduk
            left = null;
            right = null;   
        }
    }

    class Tree //düğüm sınıfından nesne oluşturunca ağaç yapısına ekleyecek 
    { 
        public Node root; //ilk düğüm = root (kök) tanımlıyoruz
        public Tree()
        {
            root = null;
        }

        public Node newNode(int data) 
        {
            root = new Node (data);   //rootu oluşturup geri döndürecek
            return root;
        }


        public Node insert (Node root, int data) //ekleme
        {
            Node eleman = new Node (data);  //parametre olarak girilen data 

            if (root != null) 
            {
                if (data < root.data) //değer kökten küçükse sola
                {
                    root.left = insert(root.left, data);
                }
                else
                {
                    root.right = insert(root.right, data); //büyükse sağa ekle 
                }
            }
            else
            {
                root = newNode (data); //newNode fonksiyonunu çağırdık.
            }

            return root;
           
        }


        public void preOrder(Node root) //önce kök okunacak (preOrder)
        {
            if(root != null)
            {
                Console.Write(root.data + "  "); //önce kök okunur
                preOrder(root.left);         //sonra sol tarafa geçilir
                preOrder (root.right);      //sol bitince sağ tarafa geçilir
            }
        }
        // kök-sol-sağ

        public void inOrder(Node root)  //kökler ortada okunur, önce sol alttan başlanır
        {
            if (root != null)
            {
                inOrder(root.left);  //önce sol
                Console.Write(root.data + "  "); //sonra kök oku
                inOrder(root.right); //sonra sağa geç
            }
        }
        //sol-kök-sağ


        public void postOrder(Node root) //köke en son uğranır
        {
            if (root != null)
            {
                postOrder(root.left); //önce sol
                postOrder(root.right);  //sonra sağ
                Console.Write(root.data + "  "); //en son kök okunur
            }
        }
        //sol-sağ-kök
    } 
}
