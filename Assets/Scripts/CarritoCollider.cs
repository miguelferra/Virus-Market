using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SpeechLib;
using UnityEngine.SceneManagement;
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

	public GameObject panel;

	//Reloj
	float theTime = 0;
	float speed = 1f;
	bool isTiming = false;
	public Text textoTimer;
	public GameObject panelTimer;

	//Puntuacion
	public GameObject estrella1, estrella2, estrella3, estrella4, estrella5;
	public Text textoFinal;

	int nextScene;

	// Start is called before the first frame update
	void Start()
    {
		voice = new SpVoice();
		nextScene = (SceneManager.GetActiveScene().buildIndex + 1);
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

            if (nextScene > PlayerPrefs.GetInt("levelAt"))
            {
				PlayerPrefs.SetInt("levelAt", nextScene);
            }

			string nivelActual;
			int tiempo5 = 30;
			int tiempo4 = 45;
			int tiempo2 = 60;
			int tiempo1 = 110;

			if (PlayerPrefs.GetInt("levelAt") == 3) {
				nivelActual = "nivel1";
				tiempo5 = 30;
				tiempo4 = 45;
				tiempo2 = 60;
				tiempo1 = 110;

			}
            else if(PlayerPrefs.GetInt("levelAt") == 4)
            {
				tiempo5 = 40;
				tiempo4 = 55;
				tiempo2 = 70;
				tiempo1 = 120;
				nivelActual = "nivel2";
			}else if (PlayerPrefs.GetInt("levelAt") == 5)
            {
				nivelActual = "nivel3";
				tiempo5 = 45;
				tiempo4 = 60;
				tiempo2 = 75;
				tiempo1 = 125;
			}
            else
            {
				tiempo5 = 45;
				tiempo4 = 60;
				tiempo2 = 75;
				tiempo1 = 125;
				nivelActual = "nivel4";
			}

			if (theTime <= tiempo5)
			{
				textoFinal.text = "Todo bien en casa?";
				estrella1.active = true;
				estrella2.active = true;
				estrella3.active = true;
				estrella4.active = true;
				estrella5.active = true;
				PlayerPrefs.SetInt(nivelActual, 5);
				//Debug.Log("Perfecto");
			}
			else if (theTime > tiempo5 & theTime <= tiempo4)
			{
				textoFinal.text = "Un buen trabajo";
				estrella1.active = true;
				estrella2.active = true;
				estrella3.active = true;
				estrella4.active = true;
				PlayerPrefs.SetInt(nivelActual, 4);
				//Debug.Log("Perfecto");
			}
			else if (theTime > tiempo4 & theTime <= tiempo2)
			{
				textoFinal.text = "Bien hecho";
				estrella1.active = true;
				estrella2.active = true;
				estrella3.active = true;
				PlayerPrefs.SetInt(nivelActual, 3);
			}
			else if (theTime > tiempo2 & theTime <= tiempo1)
			{
				textoFinal.text = "Se puede mejorar";
				estrella1.active = true;
				estrella2.active = true;
				PlayerPrefs.SetInt(nivelActual, 2);
			}
			else
			{
				textoFinal.text = "Ese papel se ve un poco viejo";
				estrella1.active = true;
				PlayerPrefs.SetInt(nivelActual, 1);
			}
			scriptMov.active = false;

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
