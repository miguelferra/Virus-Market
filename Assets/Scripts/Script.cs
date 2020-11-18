using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Librerias
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CargarNivel(string NombreNivel){
        SceneManager.LoadScene(NombreNivel);
    }

    public void Salir(){
        Application.Quit();
        Debug.Log("Saliste del juego");
    }
}
