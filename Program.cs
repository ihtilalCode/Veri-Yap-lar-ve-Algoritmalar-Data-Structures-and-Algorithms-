using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Öğrenci_Kayıt_Uygulaması__Linked_List_
{
    class Program
    {
        static void Main(string[] args)
        {
            Liste ogrenciler = new Liste();  //tek yönlü doğrusal liste yapısı
            int numara;
            string ad, soyad, dersAdi;
            float vize, final;
                


            int secim = menu();
            while (secim !=0)
            {
                switch (secim)
                {
                    case 1:
                        Console.Write("numara : "); numara = int.Parse(Console.ReadLine()); //string değeri tam sayıya dönüştürme
                        Console.Write("Ad : "); ad = Console.ReadLine();
                        Console.Write("Soyad : "); soyad = Console.ReadLine();
                        Console.Write("Ders Adı : "); dersAdi = Console.ReadLine();
                        Console.Write("Vize : "); vize = float.Parse(Console.ReadLine()); //string değeri ondalık değere dönüştürme 3.23 gibi
                        Console.Write("Final : "); final = float.Parse(Console.ReadLine());
                        ogrenciler.ekle(numara, ad, soyad, dersAdi, vize, final);
                        break;

                    case 2:
                        Console.Write("numara : "); numara = int.Parse(Console.ReadLine()); //string değeri tam sayıya dönüştürme
                        ogrenciler.sil(numara);
                        break;

                    case 3:
                        Console.Clear();    
                        ogrenciler.yazdir();
                        break;

                    case 4:
                        Console.Clear();
                        ogrenciler.enBasariliOgrenci();
                        break;

                    case 0: break;

                    default:
                        Console.WriteLine("Hatalı seçim yaptınız!");
                        break;
                }

               
                secim = menu(); //her defasında menüyü yeniden çağırsın

            }


            Console.WriteLine("Program Kapatılıyor...");
        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("\n1- Öğrenci Ekle ");
            Console.WriteLine("2- Öğrenci Sil ");
            Console.WriteLine("3- Öğrencileri Yazdır ");
            Console.WriteLine("4- En Başarılı Öğrenciyi Göster");
            Console.WriteLine("0- Programı Kapat");
            Console.WriteLine("Seçiminiz: ");
            secim = int.Parse(Console.ReadLine());
            return secim;

        }
    }


    class Ogrenci  //Nodeumuz (düğüm)
    {
        public int numara;
        public string ad, soyad, dersAdi;
        public float vize, final, ortalama;
        public string durum;

        public Ogrenci next; //bir sonraki düğümü tutan gösterici

        public Ogrenci(int n, string a, string s, string d, float v, float f) //nesne özelliklerini de vermesi amacıyla consructor
        {
            this.numara = n; //.this şu anki  nesneyi referans almayı sağlar  
            this.ad = a;
            this.soyad = s;
            this.dersAdi = d;
            this.vize = v;
            this.final = f;

            this.ortalama = this.vize * 40 / 100 + this.final * 60 / 100;
            this.durum = this.ortalama < 50 ? "Kaldı" : "Geçti"; //koşul ? doğruysa_yapılacak : yanlışa_yapılacak; (if else kullanımının kısa hali diyebiliriz.)
            this.next = null; // bir düğüm varsa null gösterir, ekledikçe kendisini günceller

        }
    }

    class Liste //bu listenin içerisine öğrencileri kaydedeceğiz
    {
        Ogrenci head; //ilk yer tutan öğrenci head olur
        public Liste() //constructor
        {
            head = null;
        }


        public void ekle(int n, string a, string s, string d, float v, float f) //öğrenci ekleyecek fonksiyon
        {
            Ogrenci ogr = new Ogrenci(n, a, s, d, v, f); //nesnenin içine oluşturacağız öğrenciden alınan bilgileri

            if (head == null) //listede hiç eleman yoksa
            {
                head = ogr; //ilk eklenen öğrenci
                Console.WriteLine(n + " numaralı öğrenci listeye eklendi.");
            }
            else
            {
                ogr.next = head; //başa ekliyoruz
                head = ogr;  //headi tekrar güncelliyoruz
                Console.WriteLine(n + " numaralı öğrenci eklendi.");
            }
        }



        public void sil(int numara)
        {
            bool sonuc = false; //numarayla hiçbir öğrenci eşleşmediğinde kullanılacak

            if (head == null)
            {
                sonuc = true;
                Console.WriteLine("Listede kayıtlı öğrenci yok!");
            }
            else if (head.next == null && head.numara == numara) //tek eleman varsa listede
            {
                sonuc = true;
                head = null; //öğrenci silme işlemi
                Console.WriteLine(numara + " numaralı öğrenci silindi, listede hiç öğrenci kalmadı.");
            }
            else if (head.next != null && head.numara == numara) //çok eleman fakat baştaki silinmek istendiğinde
            {
                sonuc = true;
                head = head.next; //en baştaki siindi.
                Console.WriteLine(numara + " numaralı öğrenci silindi.");
            }
            else
            {
                Ogrenci temp = head; //geçici değişken oluşturduk
                Ogrenci temp2 = temp;

                while (temp.next != null) //son düğüme kadar git
                {
                    if (numara == temp.numara)
                    {
                        sonuc = true;
                        temp2.next = temp.next; //tempi aradan çıkartmış olduk
                        Console.WriteLine(numara + " numaralı öğrenci silindi.");
                    }

                    temp2 = temp; //temp geçerken bir önceki düğümünü temp2ye versin.
                    temp = temp.next; //ilerlemesi için

                }
                if (numara == temp.numara)
                {
                    sonuc = true;
                    temp2.next = temp.next; //tempi aradan çıkartmış olduk
                    Console.WriteLine(numara + " numaralı öğrenci silindi.");
                }

            }

            if (sonuc == false)
            {
                Console.WriteLine(numara + " numaralı öğrenci kaydı yok.");
            }
        }



        public void yazdir()
        {
            if (head == null)
            {
                Console.WriteLine("Listede kayıtlı öğrenci yok!");
            }
            else
            {
                Ogrenci temp = head;

                Console.WriteLine("Numara\tAd\tSoyad\tDersAdi\tOrtalama\tDurum\n"); // \t metin hizalama amcıyla kullandık.
                while (temp.next != null)
                {
                    Console.WriteLine(temp.numara + "\t" + temp.ad + "\t" + temp.soyad + "\t" + temp.dersAdi + "\t" + temp.ortalama + "\t" + temp.durum);
                    temp = temp.next;
                }

                Console.WriteLine(temp.numara + "\t" + temp.ad + "\t" + temp.soyad + "\t" + temp.dersAdi + "\t" + temp.ortalama + "\t" + temp.durum);
                //tail için
            }
        }



        public void enBasariliOgrenci()
        {
            if (head == null)
            {
                Console.WriteLine("Listede kayıtlı öğrenci yok!");
            }
            else
            {
                Ogrenci temp = head;
                Ogrenci yuksekOgr = head;
                float enYuksekOrtalama = head.ortalama; //en baştaki en yüksekse zaten yazar

                while (temp.next != null)
                {
                    if ( enYuksekOrtalama < temp.ortalama)
                    {
                        enYuksekOrtalama = temp.ortalama;
                        yuksekOgr = temp; //yüksek öğrenci
                    }

                    temp = temp.next;

                }

                if (enYuksekOrtalama < temp.ortalama) //en sondaki eleman için
                {
                    enYuksekOrtalama = temp.ortalama;
                    yuksekOgr = temp;
                }


                Console.WriteLine("En yüksek ortalamalı öğrenci bilgileri : ");
                Console.WriteLine("Numara\tAd\tSoyad\tDersAdi\tOrtalama\tDurum\n"); // \t metin hizalama amcıyla kullandık.

                Console.WriteLine(yuksekOgr.numara + "\t" + yuksekOgr.ad + "\t" + yuksekOgr.soyad + "\t" + yuksekOgr.dersAdi + "\t" + yuksekOgr.ortalama + "\t" + yuksekOgr.durum);

            }
        }


    }
}
    
