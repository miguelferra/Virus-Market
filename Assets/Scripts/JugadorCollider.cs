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
    public GameObject panelTimer;

    //Reloj
    float theTime = 0;
    float speed = 1f;
    bool isTiming = false;
    public Text textoTimer;

    // Start is called before the first frame update
    void Start()
    {
        voice = new SpVoice();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTiming)
        {
            theTime += Time.deltaTime * speed;
            string segundos = (theTime % 60).ToString("00");
            string minutos = Mathf.Floor((theTime % 3600) / 60).ToString("00");
            textoTimer.text = minutos + ":" + segundos;
        }

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
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Inicio")
        {
            panel.gameObject.SetActive(false);
            col.gameObject.active = false;
            panelTimer.active = true;
            isTiming = true;
        }
    }
}
