using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{

    void bolenleriBul(int ilksayi, int ikincisayi)
    {
        List<int>tamListe = new List<int>();

        for (int i = ilksayi; i <= ikincisayi; i++)
        {
            tamListe.Add(i);
        }

        //Lambda ile ikiye bölünen t degiskelerinin hepsini FindAll hazır fonksiyonu ile bulup listeye ekler.
        List<int> ikiyeBölümListesi = tamListe.FindAll(t => t % 2 ==0);  
        List<int> üceBölümListesi = tamListe.FindAll(t => t % 3 == 0);
        List<int> dördeBölümListesi = tamListe.FindAll(t => t % 4 == 0);
        List<int> beseBölümListesi = tamListe.FindAll(t => t % 5 == 0);

        //Listedeki bütün sayıların arasına, string kütüphanesinin Join hazır fonksiyonu ile - işareti ekler
        print("Tam Liste: " + string.Join("-", tamListe));
        print("Ikiye Bölünenler: "+string.Join("-",ikiyeBölümListesi));
        print("Üce Bölünenler: " + string.Join("-",üceBölümListesi));
        print("Dörde Bölünenler: " + string.Join("-",dördeBölümListesi));
        print("Bese Bölünenler: " + string.Join("-",beseBölümListesi));
       
    }


    void Start()
    {
        bolenleriBul(6, 78);
    }

}