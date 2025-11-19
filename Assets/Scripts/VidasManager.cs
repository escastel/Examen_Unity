using UnityEngine;
using UnityEngine.SceneManagement;

public class VidasManager : MonoBehaviour
{
    public TMPro.TMP_Text textoVidas;
    private int vidas;
    void Start()
    {
        vidas = 2;
        textoVidas.text = vidas.ToString();
    }

    void Update()
    {
        if (vidas <= 0)
        {
           UnityEngine.SceneManagement.SceneManager.LoadScene("Derrota");
        }
    }

    public void RestarVidas()
    {
        vidas--;
        textoVidas.text = vidas.ToString();
        SceneManager.LoadScene("Nivel");
    }
}
