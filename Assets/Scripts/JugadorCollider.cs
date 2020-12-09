using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpeechLib;
using UnityEngine.UI;

public class JugadorCollider : MonoBehaviour
{

    private SpVoice voice;
    public GameObject panel;
    public GameObject panelGameover;
    public GameObject jugador;
    

  

    // Start is called before the first frame update
    void Start()
    {
        voice = new SpVoice();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnTriggerEnter(Collider objeto)
    {

        if (objeto.gameObject.tag == "Inicio")
        {
            Debug.Log("Toque Inicio");
            voice.Speak("!!!Recolecta 10 rollos de papel antes de que te los ganen!!!" +
                "Acercate a los destellos amarillos para recolectarlos", SpeechVoiceSpeakFlags.SVSFlagsAsync);
            panel.gameObject.SetActive(true);
        }
        if (objeto.gameObject.tag == "Enemigo")
        {
            voice.Speak("Usted se ha infectado apa Quiere volver a jugar?", SpeechVoiceSpeakFlags.SVSFlagsAsync);
            panelGameover.gameObject.SetActive(true);
            jugador.active = false;
        }
    }
    
}
