using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GirişKodlar : MonoBehaviour
{
    public TMP_Text sahneler;
    public void cıkıs()
    {
        Application.Quit();
    }

    public void SahneDegis()
    {
        string sahneismi = sahneler.text;
        SceneManager.LoadScene(sahneismi); 
    }
}
