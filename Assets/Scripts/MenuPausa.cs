using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;
    public GameObject MenuOpciones;
    public bool Pausa = false;
    // Start is called before the first frame updatez   

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Pausa == false)
            {
                menuPausa.SetActive(true);
                Time.timeScale = 0;
                Pausa = true;
                Cursor.visible = true;  
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                menuPausa.SetActive(false);
                Time.timeScale = 1;
                Pausa = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
    public void MenuOpcionesMusica(){
        MenuOpciones.SetActive(true);
        menuPausa.SetActive(false);
    }
    public void volverMenuPausa(){
        MenuOpciones.SetActive(false);
        menuPausa.SetActive(true);
    }
    public void Reanudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        Pausa = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
