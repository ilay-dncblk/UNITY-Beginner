using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class Kodlar : MonoBehaviour
{
    public TMP_Text isim, soyisim;
    public List<GameObject> paneller;
    public List<GameObject> sonucPanelleri;
    public GameObject sorularPaneli;
    private string isimSoyisim;
    private int panel = 0;
    private int puan = 0;
    public TMP_Dropdown soru1;
    public Slider soru3puan;
    public int soru2 = 0;
    public int soru3 = 0;
    public int soru4 = 0;
    public ToggleGroup soru5;
    public TMP_Text slidertxt;
    public void kullaniciBilgileri()
    {
        if (isim.text.Length <= 1)
        {
            return;
        }
        if (soyisim.text.Length <= 1)
        {
            return;
        }
        isimSoyisim = "Merhaba " + isim.text + " " + soyisim.text + ";\n";

        paneller[panel].SetActive(false);
        panel++;
        paneller[panel].SetActive(true);

    }
    public void devamButonu()
    {
        if (panel == paneller.Count - 2)
        {
            sorularPaneli.SetActive(false);
            Puanlama(Soru1Puan(soru1));
            Puanlama(soru2);
            Puanlama(Soru3puan(soru3puan));
            Puanlama(soru4);
            Puanlama(Soru5puan(soru5));
            sonucPaneliSecme();
        }

        paneller[panel].SetActive(false);
        panel++;
        paneller[panel].SetActive(true);

    }

    public void Puanlama(int kullaniciPuani)
    {
        puan += kullaniciPuani;
    }

    public void sonucPaneliSecme()
    {
        string temp;
        if (puan <= 8)
        {
            sonucPanelleri[0].SetActive(true);

            temp = sonucPanelleri[0].transform.GetChild(1).GetComponent<TMP_Text>().text;
            sonucPanelleri[0].transform.GetChild(1).GetComponent<TMP_Text>().text = isimSoyisim + temp;
            return;
        }
        if (puan <= 12)
        {
            sonucPanelleri[1].SetActive(true);

            temp = sonucPanelleri[0].transform.GetChild(1).GetComponent<TMP_Text>().text;
            sonucPanelleri[0].transform.GetChild(1).GetComponent<TMP_Text>().text = isimSoyisim + temp;
            return;
        }
        if (puan <= 16)
        {
            sonucPanelleri[2].SetActive(true);

            temp = sonucPanelleri[0].transform.GetChild(1).GetComponent<TMP_Text>().text;
            sonucPanelleri[0].transform.GetChild(1).GetComponent<TMP_Text>().text = isimSoyisim + temp;
            return;
        }
        if (puan <= 20)
        {
            sonucPanelleri[3].SetActive(true);

            temp = sonucPanelleri[0].transform.GetChild(1).GetComponent<TMP_Text>().text;
            sonucPanelleri[0].transform.GetChild(1).GetComponent<TMP_Text>().text = isimSoyisim + temp;
            return;
        }
    }

    public int Soru1Puan(TMP_Dropdown dropdown)
    {

        if ((dropdown.value == 1) || (dropdown.value == 2) || (dropdown.value == 3))
        {
            return 1;
        }
        if ((dropdown.value == 4) || (dropdown.value == 5) || (dropdown.value == 6))
        {
            return 2;
        }
        if ((dropdown.value == 7) || (dropdown.value == 8) || (dropdown.value == 9))
        {
            return 3;
        }
        if ((dropdown.value == 10) || (dropdown.value == 11) || (dropdown.value == 12))
        {
            return 4;
        }

        return 0;


    }

    public void Soru2puan(int s2puan)
    {
        soru2 = s2puan;
    }

    public int Soru3puan(Slider s3puan)
    {
        soru3 = (int)s3puan.value;
        return soru3;
    }
    public void Soru4puan(int s4puan)
    {
        soru4 = s4puan;
    }

    public int Soru5puan(ToggleGroup soru5)
    {
        int sayac = 1;
        foreach (Toggle toggle in soru5.gameObject.GetComponentsInChildren<Toggle>())
        {
            if (toggle.isOn)
            {
                return sayac;
            }
            sayac++;

            //if (toggle.name == "A")
            //{
            //    return 1;
            //}
            //if (toggle.name == "B")
            //{
            //    return 2;
            //}
            //if (toggle.name == "C")
            //{
            //    return 3;
            //}
            //if (toggle.name == "D")
            //{
            //    return 4;
            //}

        }
        return 0;
    }

    public void cikisButonu()
    {
        SceneManager.LoadScene(0);
    }

    public void slidertext()
    {
        slidertxt.text = soru3puan.value.ToString();
    }
}



