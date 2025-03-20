using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Çift_yönlü_listeler
{
    class Program
    {
        static void Main(string[] args)
        {
            Liste cydaListe = new Liste();//Çift yönlü dairesel liste oluşurduk.
            int sayi, indis;

            int secim = menu();

            while ( secim !=0)
            {
                switch (secim)
                {
                    case 1: Console.Write("Sayı : "); sayi = int.Parse(Console.ReadLine());
                        cydaListe.basaEkle(sayi);
                        cydaListe.yazdir();
                        break;

                    case 2: Console.Write("Sayı : "); sayi = int.Parse(Console.ReadLine());
                        cydaListe.sonaEkle(sayi);
                        cydaListe.yazdir();
                        break;

                    case 3:
                        Console.Write("İndis: "); indis = int.Parse(Console.ReadLine());
                        Console.Write("Sayı: "); sayi = int.Parse(Console.ReadLine());
                        cydaListe.arayaEkle(indis, sayi);
                        cydaListe.yazdir();
                         break;

                    case 4: cydaListe.bastanSil();
                        cydaListe.yazdir();
                        break;

                    case 5: cydaListe.sondanSil();
                        cydaListe.yazdir();
                        break;

                    case 6:
                        Console.Write("İndis: "); indis = int.Parse(Console.ReadLine());
                        cydaListe.aradanSil(indis);
                        cydaListe.yazdir();
                        break;

                    case 7: cydaListe.terstenYazdir();
                        break;

                    case 0: break;

                    default:
                        Console.WriteLine("Hatalı seçim yaptınız.");
                        break;
                    
                }


                secim = menu();
                
                Console.Clear();    

            }

            Console.WriteLine("Program kapatıldı.");



            Console.ReadKey();
        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("\n\n1.Başa Ekle");
            Console.WriteLine("2.Sona Ekle");
            Console.WriteLine("3.Araya Ekle");
            Console.WriteLine("4.Baştan Sil");
            Console.WriteLine("5.Sondan Sil");
            Console.WriteLine("6.Aradan Sil");
            Console.WriteLine("7.Tersten Yazdır");
            Console.WriteLine("0.Programı Kapat");
            Console.Write("Seçiminiz: ");
            secim = int.Parse(Console.ReadLine());
            return secim;

        }
    }

    class Node // Düğüm için sınıf oluşturuyoruz.
    {
        public int data;
        public Node next;
        public Node prev;

        public Node(int data) // Her düğümde data ve iki gösterge olmalı.
        {
            this.data = data;
            this.next = null;
            this.prev = null;

        }
    }
    class Liste
    {
        Node head;
        Node tail;

        public Liste() //Liste oluşturuyoruz.
        {
            this.head = null;
            this.tail = null;
        }

        public void basaEkle(int data) // Datayı kullanıcıdan alıyoruz.
        {
            Node eleman = new Node(data); //Eklenecek düğüm.


            if (head == null)
            {
                eleman.next = eleman; //Dairesel olmasını sağlıyoruz.
                eleman.prev = eleman;

                head = tail = eleman;

                Console.WriteLine("Liste yapısı oluşturuldu, ilk eleman eklendi.");
            }
            else
            {
                eleman.next = head; // Head önüne eleman ekledik.
                head.prev = eleman; //Karşılıklı bağladık.

                head = eleman;   //head güncelledik.

                head.prev = tail;
                tail.next = head; //Artık tail yeni headi gösterecek.

                Console.WriteLine("Başa eleman eklendi.");
            }
        }



        public void sonaEkle(int data) // Datayı kullanıcıdan alıyoruz.
        {
            Node eleman = new Node(data); //Eklenecek düğüm.


            if (head == null)
            {
                eleman.next = eleman; //Dairesel olmasını sağlıyoruz.
                eleman.prev = eleman;

                head = tail = eleman;

                Console.WriteLine("Liste yapısı oluşturuldu, ilk eleman eklendi.");
            }
            else
            {
                tail.next = eleman; //tailden sonrasına eleman ekledik.
                eleman.prev = tail; //Dairesel yapıdan dolayı

                tail = eleman; //taili güncelledik.

                tail.next = head; //Güncel bağları oluşturduk.
                head.prev = tail;

                Console.WriteLine("Sona eleman eklendi.");
            }
        }



        public void arayaEkle(int indis, int data) // Artık indis işin içine girdi.Datayı kullanıcıdan alıyoruz.
        {
            Node eleman = new Node(data); //Eklenecek düğüm.


            if (head == null && indis == 0) //Eleman yoksa ve 0. indis eklenecekse. .
            {
                eleman.next = eleman; //Dairesel olmasını sağlıyoruz.
                eleman.prev = eleman; 

                head = tail = eleman;

                Console.WriteLine("Liste yapısı oluşturuldu, ilk eleman eklendi.");
            }
            else if (head != null && indis == 0) // Eleman varsa ve 0. indis eklenmek isteniyorsa.
            {
                basaEkle(data);
            }
            else
            {
               int i = 0; 
                Node temp = head;
                Node temp2 = temp;

                while (temp != tail)
                {

                    if (i == indis)
                    {
                        temp2.next = eleman; //temp2nin ardına elemanı ekledik.
                        eleman.prev = temp2;

                        eleman.next = temp; //Diğer taraftaki düğüm ile de bağlanısını kurduk.
                        temp.prev = eleman;

                        Console.WriteLine("Araya eleman eklendi.");
                        i++;
                        break;
                    }

                    temp2 = temp; //hem temp2 hem de temp bir diğer tarafa kaydırdık.
                    temp = temp.next; 
                    i++; //indislerini bir artırdık.

                }
                if (i == indis)  //Tailin bir öncesine de eleman eklemeyi hesaba kattık.
                {
                    temp2.next = eleman; //tailin öncesine elemanı ekledik.
                    eleman.prev = temp2;

                    eleman.next = temp; //Diğer taraftaki düğüm ile de bağlanısını kurduk.
                    temp.prev = eleman;

                    Console.WriteLine("Araya eleman eklendi.");
                    
                }
            }
        }


        public void yazdir()
        {
            if (head == null)
                Console.WriteLine("Liste boş.");

            else
            {
                Node temp = head; //Geçici değişken oluşturduk.
                Console.Write("Baş --> ");

                while (temp != tail)
                {
                    Console.Write(temp.data + " -> " );
                    temp = temp.next;   
                }
                Console.Write(temp.data + " son.");
            }
        }


        public void terstenYazdir()
        {
            if (head == null)
                Console.WriteLine("Liste boş.");

            else
            {
                Node temp = tail; //Geçici değişken oluşturduk.
                Console.Write("Son --> ");

                while (temp != head)
                {
                    Console.Write(temp.data + " -> ");
                    temp = temp.prev;
                }
                Console.Write(temp.data + " baş.");
            }
        }



        public void bastanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
            }
            else if (head.next ==head)//Tek bir düğüm varsa listede
            {
                head = tail = null; //Düğümü sildik.
                Console.WriteLine("Eleman silindi, listede eleman kalmadı.");
            }
            else
            {
                head = head.next; //headi bir sonrakine kaydırıyoruz.
                head.prev = tail; //Bağları yeniden oluşuruyoruz.
                tail.next = head;

                Console.WriteLine("Baştan eleman silindi.");
            }
        }



        public void sondanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
            }
            else if (head.next == head)//Tek bir düğüm varsa listede
            {
                head = tail = null; //Düğümü sildik.
                Console.WriteLine("Eleman silindi, listede eleman kalmadı.");
            }
            else
            {
                tail = tail.prev; //taili önceki düğüme kaydırdık.
                tail.next = head; //Bağları güncelledik.
                head.prev = tail;

                Console.WriteLine("Sondan eleman silindi.");
            }
        }



        public void aradanSil(int indis)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
            }
            else if (head.next == head && indis==0)//Listedeki tek eleman silinmek isteniyor.
            {
                head = tail = null; //Düğümü sildik.
                Console.WriteLine("Eleman silindi, listede eleman kalmadı.");
            }
            else if (head.next != head && indis == 0)//Birden çok eleman var baştaki silinmek isteniyor.
            {
                bastanSil();
            }
            else
            {
                Node temp = head;
                Node temp2 = temp;
                int i = 0;

                while (temp != tail)
                {
                    if (i == indis) //indis değerini temp tutuyor.
                    {
                        temp2.next = temp.next; //Aradaki tempi çıkartmış olduk.
                        temp.next.prev = temp2; //silinecek düğümün nextini bir sonraki düğümün previne bağladık.
                                                //ortadaki düğüm boşa çıkarılmış oldu.
                        Console.WriteLine("Aradan eleman silindi.");
                        i++;    
                        break;
                    }

                    temp2 = temp; 
                    temp = temp.next;
                    i++;    
                }
                if (i == indis) //tail için
                {
                    sondanSil();
                }

            }
        }



    }
}
