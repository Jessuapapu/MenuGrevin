using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CambioDeEscena(string EscenaSeleccionada)
    {
        SceneManager.LoadScene(EscenaSeleccionada);
    }

    public void BotonSalir()
    {
        Application.Quit();
        Debug.Log("Aqui Cierra el juego");
    }

   
}
