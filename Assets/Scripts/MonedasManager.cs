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

    void Update()
    {
        if (monedas >= totalMonedas)
        {
            Debug.Log("¡Has recogido todas las monedas!");
        }
    }
}
