using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpeechLib;

public class CarritoCollider : MonoBehaviour
{
	
	private SpVoice voice;
	public GameObject jugador;

	//Papel
	public AudioClip sonidoPapel;
	public AudioSource sonidoCarrito;
	private int puntos = 0;
	public GameObject puntuacion;
	public GameObject panelFinal;
	public GameObject scriptMov;
	public GameObject fondoCarrito;
	public GameObject papel;


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

		if (objeto.gameObject.tag == "Spawn")
		{
			Debug.Log("Toque Spawn");
			Instantiate(papel, new Vector3(fondoCarrito.transform.position.x, objeto.gameObject.transform.position.y - 1.5f, fondoCarrito.transform.position.z), Quaternion.identity);

			objeto.gameObject.active = false;
		}

		if (objeto.gameObject.tag == "Papel")
		{
			Debug.Log("Toque Papel");
			objeto.gameObject.transform.parent = jugador.transform;
			objeto.enabled = false;
			sonidoCarrito.PlayOneShot(sonidoPapel);
			objeto.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			puntos++;
			puntuacion.GetComponent<Text>().text = puntos.ToString();
		}

		if (puntos == 10)
		{
			voice.Speak("Usted ha ganado apa", SpeechVoiceSpeakFlags.SVSFlagsAsync);
			panelFinal.gameObject.SetActive(true);
			scriptMov.active = false;

		}
	}

}
