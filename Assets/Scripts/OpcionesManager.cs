using UnityEngine;
using UnityEngine.SceneManagement;

public class OpcionesManager : MonoBehaviour
{
    public void ReiniciarNivel()
    {
        SceneManager.LoadScene("Nivel");
    }

    public void Salir()
    {
        Application.Quit();
    }
    
}
