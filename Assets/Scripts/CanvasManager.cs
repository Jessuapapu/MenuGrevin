using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject CanvasMenuOpciones;
    public GameObject CanvasMain;

    public void MostrarOptions()
    {
        CanvasMenuOpciones.SetActive(true);
        CanvasMain.SetActive(false);
    }

    public void OcultarOptions()
    {
        CanvasMenuOpciones.SetActive(false);
        CanvasMain.SetActive(true);
    }
}
