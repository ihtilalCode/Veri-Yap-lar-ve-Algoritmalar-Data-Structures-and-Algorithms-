using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack__Yığın__Yapısı //first in last out, last in first out
{
    class Program
    {
        static void Main(string[] args)
        {
            StackYapisi stc = new StackYapisi();
            int sayi;

            int secim = menu(); //menü fonksiyonunu çağıracak
            while (secim != 0)
            {
                switch (secim) 
                {
                    case 1:
                        Console.WriteLine("Sayı : "); sayi = int.Parse(Console.ReadLine()); 
                        stc.push(sayi); 
                        break;

                    case 2:
                        sayi = stc.pop(); 

                        if (sayi != -1)
                        {
                            Console.WriteLine("Çıkan Sayı : " + sayi);
                        }
                        else
                        {
                            Console.WriteLine("Stack boştur!");
                        }
                        break;

                    case 3:  Console.Clear();
                        stc.print(); break;

                    case 4: 
                        stc.topPrint(); break;

                    case 0: break;

                    default:
                        Console.WriteLine("Hatalı seçim!");
                        break;  

                }

                secim = menu();

            }

            Console.WriteLine("Programı sonlandırdınız...");

        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("1- Push (Ekle)");
            Console.WriteLine("2- Pop (Çıkar)");
            Console.WriteLine("3- Print (Yazdır)");
            Console.WriteLine("4- Top (En Üst)");
            Console.WriteLine("0- Exit");
            secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }


    class Node //düğüm
    {
        public int data; //düğümde bir data bir gösterici var
        public Node next;
        public Node(int data) //düğümün girilecek datası
        {
            this.data = data;
            next = null;
        }
    }

    class StackYapisi
    {
        Node top;

        public StackYapisi()
        {
            top = null; //en üstteki düğüm top
        } 


        public void push(int data) //stack içerisine ekleme işlemi yapacak alınan datayı
        {
            Node eleman = new Node(data); //yeni eleman türettik
            if (top == null) //stack boştur
            {
                top = eleman;
                Console.WriteLine("Stack yapısı oluşturuldu, ilk eleman stacke girdi.");
            }
            else 
            {
                eleman.next = top; //top aşağı kaydı
                top = eleman;   //yeni top, eklenen eleman oldu
                Console.WriteLine("Eleman eklendi.");    
            } 
        }


        public int pop() //stack içerisindeki değeri çıkartacak
        {
            if (top == null)
            {
                Console.WriteLine("Stack boş!");
                return -1;
            }
            else
            {
                int sayi = top.data;
                top = top.next; //bir aşağı kaydırarak sildik.
                Console.WriteLine(sayi + " stackten çıkarıldı.");
                return sayi;  //tuttuğumuz sayıya geri döndürme amaçlı
            }
        }


        public void print()
        {
            if (top == null)
            {
                Console.WriteLine("Stack boş!");
            }
            else 
            {
                Node temp = top; //en üstten başlatıyoruz
                Console.Clear();

                while (temp != null) //sonraki null olana kadar yazmaya devam edecek
                {
                    Console.WriteLine(temp.data);
                    temp = temp.next; 
                }
            }
        }


        public void topPrint() 
        {
            if (top == null)
            {
                Console.WriteLine("Stack boş!");
            }
            else
            {
                Console.WriteLine(top.data); //en üstteki datayı yazacak  
            }
        }       
    }
}
