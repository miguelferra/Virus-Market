using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpeechLib;

public class CarritoCollider : MonoBehaviour
{
    public GameObject puntuacion;
    private int puntos = 0;
    public AudioSource sonidoCarrito;
	public AudioClip sonidoPapel;
	public GameObject jugador;
	public GameObject papel;
	public GameObject scriptMov;

	private SpVoice voice;
	public GameObject panel;
	public GameObject panelFinal;
	public GameObject panelGameover;
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
		if (objeto.gameObject.tag == "Papel")
		{
			Debug.Log("Toque Papel");
			objeto.gameObject.transform.parent = jugador.transform;
			sonidoCarrito.PlayOneShot(sonidoPapel);
			objeto.enabled = false;
			objeto.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			puntos++;
			puntuacion.GetComponent<Text>().text = puntos.ToString();
		}
		if (objeto.gameObject.tag == "Spawn")
		{
			Debug.Log("Toque Spawn");
			Instantiate(papel, new Vector3(objeto.gameObject.transform.position.x, objeto.gameObject.transform.position.y + 2, objeto.gameObject.transform.position.z), Quaternion.identity);
			objeto.gameObject.active = false;
		}
		if (objeto.gameObject.tag == "Inicio")
		{
			Debug.Log("Toque Inicio");
			voice.Speak("!!!Recolecta 10 rollos de papel antes de que te los ganen!!!" +
				"Acercate a los destellos amarillos para recolectarlos", SpeechVoiceSpeakFlags.SVSFlagsAsync);
			panel.gameObject.SetActive(true);
		}
		if (puntos == 10)
		{
			voice.Speak("Usted ha ganado apa", SpeechVoiceSpeakFlags.SVSFlagsAsync);
			panelFinal.gameObject.SetActive(true);
			scriptMov.active = false;
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
		}

	}
}
