using UnityEngine.SceneManagement;
using UnityEngine;

public class MonedasManager : MonoBehaviour
{
    public  TMPro.TMP_Text textoMonedas;
    private int monedas;
    private int totalMonedas;
    void Start()
    {
        monedas = 0;
        textoMonedas.text = monedas.ToString();
        totalMonedas = transform.childCount;
    }

    public void SumarMonedas()
    {
        monedas++;
        textoMonedas.text = monedas.ToString();
    }
}
