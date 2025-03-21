using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Table__Özet_Tablo__Yapısı
{
     class Program
    {
        static void Main(string[] args)
        {
            int size;
            Console.Write("Hash Tablo Boyu : "); size = int.Parse(Console.ReadLine());

            Tablo hTablo = new Tablo(size); //tablo kaç bölümlü olacak
            int numara;  //numara-key
            string isim;
            int secim = menu();

            while (secim  != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.WriteLine("Numara : ");numara = int.Parse(Console.ReadLine());
                        Console.WriteLine("İsim : "); isim = Console.ReadLine();
                        hTablo.ekle(numara, isim); break;

                    case 2:
                        Console.WriteLine("Silinecek Kişi Numarası : "); numara = int.Parse(Console.ReadLine());
                        hTablo.sil(numara);
                        break;


                    case 3: hTablo.yazdir(); break;

                    case 4: hTablo.adetBul(); break;

                    case 5:
                        Console.WriteLine("Aranan Kişinin Numarası : "); numara = int.Parse(Console.ReadLine());
                        hTablo.kisiBul(numara);
                        break;

                    case 0: break;

                    default:
                        Console.WriteLine("Hatalı Seçim!");
                        break;
                }

                secim = menu();

            }

            Console.ReadKey();

        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("1- Ekle");
            Console.WriteLine("2- Sil");
            Console.WriteLine("3- Yazdır");
            Console.WriteLine("4- Kişi Sayısı");
            Console.WriteLine("5- Kişi Bul");
            Console.WriteLine("0- Kapat");
            Console.WriteLine("Seçiminiz : "); secim = int.Parse(Console.ReadLine());

            Console.Clear();
            return secim;
        }
    }


    class Node //DÜĞÜM YAPISI
    {
        public int key;
        public string isim;
        public Node next;
        public Node() //parametresiz, nextin null olması için
        {             
            this.next = null; //dizinin içinde gösterilecek olan boş düğüm
        }


        public Node(int key, string isim) //dizinin dışında bağlı liste olarak duracak olan düğüm
        {                                 //bağlı listelerde kullanılacak 
            this.key = key;
            this.isim = isim;
            this.next = null;
        }
    }


    class Tablo
    {
        int size;
        public Node [] dizi;   //int değil de node tipinde dizi
        public Tablo(int size)  //tablonun kaç sizelık olacağı kullanıcıdan alınsın
        {
            this.size = size;
            dizi = new Node[size]; //dizinin boyu tanımlanmış olur

            for (int i = 0; i < size; i++) //boş düğümler ekliyoruz  
            {
                dizi[i] = new Node(); //dizinin içerisine birer düğüm ekleriz
            }
        }

        public int indexUret(int key) //mod alma işlemi (size ve key farklı olduğunda)
        {
            return key % size; //çıkan sonuç hangi bölüme bağlanacağını gösterecek
        }


        public void ekle(int key, string isim) //ekle fonksiyonu
        {
            Node eleman = new Node(key,isim); //bağlı listede kullanmak için, parametreli düğüm

            int indis = indexUret(key);

            Node temp = dizi[indis];

            if (temp.next == null)
            {
                temp.next = eleman; //sonraki düğüm boşsa oraya elemanı ekle.
                Console.WriteLine("Sütunun ilk elemanı eklendi.");
            }
            else
            {
                while (temp.next != null)
                {
                    temp = temp.next; //sonraki null değilse ilerle
                }
                temp.next = eleman; //ilerlediğin yere elemanı ekle
                Console.WriteLine(key + " eklendi. ");
            }
        }


        public void sil( int key)
        {
            bool sonuc = false;

            int indis = indexUret(key); //aranan veri
            Node temp = dizi[indis];  //indis değerini tutan geçici düğüm 

            if(temp.next == null)  //eleman yoksa
            {
                Console.WriteLine(key + " numaralı kayıt yok!");
                sonuc = true;
            }
            else if (temp.next.next == null && temp.next.key == key) //tek elemanlıysa
            {
                temp.next = null;
                Console.WriteLine(key + " numaralı kişi silindi");
                sonuc = true;
            }
            else
            {
                Node temp2 = temp;
                while (temp.next != null) //aradan eleman silme 
                {
                    temp2 = temp;
                    temp = temp.next;

                    if (temp.key == key)
                    {
                        temp2.next = temp.next; //aradan tempi çıkartıyoruz
                        Console.WriteLine(key + " numaralı kişi silindi.");
                        sonuc = true;
                    }
                }

                if (!sonuc)
                {
                    Console.WriteLine(key + " numaralı kişi bulunamadı.");
                }
            }
        }

        public void yazdir()
        {
            for (int i = 0;i < size;i++) //her bölüme uğrayacak
            {
                Node temp = dizi[i];  //dizinin i. değerini alacak geçici değişken oluşturduk
                Console.Write("Dizi [{0}] -->  " , i);

                while (temp.next != null)
                {
                    temp = temp.next; //bölümün bağlı listelerini gezecek

                    Console.Write( temp.key + " " + temp.isim + " -> "); //her biri birer düğüm
                }
                Console.WriteLine();
            }
        }


        public void adetBul()
        {
            int sayac = 0;
            for (int i = 0; i < size; i++) //her bölüme uğrayacak 
            {
                Node temp = dizi[i];  //dizinin i. değerini alacak geçici değişken oluşturduk
                Console.WriteLine();

                while (temp.next != null)  //içeride olduğu sürece dönecek
                {
                    temp = temp.next; //bölümün bağlı listelerini gezecek
                    sayac++; // döndükçe arttıracak
                }
                Console.WriteLine();
            }

            if (sayac == 0)
            {
                Console.WriteLine("Tabloda kayıtlı veri yok.");
            }
            else
                Console.WriteLine("Tabloda kayıtlı kişi sayısı : " + sayac); 
        }


        public void kisiBul(int key)
        {
            bool sonuc = false;
            for (int i = 0; i < size; i++) //her bölüme uğrayacak
            {
                Node temp = dizi[i];  //dizinin i. değerini alacak geçici değişken oluşturduk
             
                while (temp.next != null)
                {
                    temp = temp.next;
                    if (key == temp.key)
                    {
                        Console.Write(temp.key + " numaralı kişi bilgileri : " + temp.isim); //her biri birer düğüm
                        sonuc = true;
                    }

                }
                Console.WriteLine();
            }

            if (!sonuc) 
            {
                Console.WriteLine(key + " numaralı kişi bulunamadı!");
            }
        }
        
           
            
    } 
}

