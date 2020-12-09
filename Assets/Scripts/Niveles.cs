using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Niveles : MonoBehaviour
{


    public Button[] lvlButtons;
    public GameObject[] estrellasNivel1;
    public GameObject[] estrellasNivel2;
    public GameObject[] estrellasNivel3;
    public GameObject[] estrellasNivel4;
    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
        switch (PlayerPrefs.GetInt("nivel1"))
        {
            case 1:
                for (int i = 0; i < estrellasNivel1.Length - 4; i++)
                {
                    estrellasNivel1[i].active = true;
                }
                break;
            case 2:
                for (int i = 0; i < estrellasNivel1.Length -3; i++)
                {
                    estrellasNivel1[i].active = true;
                }
                break;
            case 3:
                for (int i = 0; i < estrellasNivel1.Length -2; i++)
                {
                    estrellasNivel1[i].active = true;
                }
                break;
            case 4:
                for (int i = 0; i < estrellasNivel1.Length -1; i++)
                {
                    estrellasNivel1[i].active = true;
                }
                break;
            case 5:
                for (int i = 0; i < estrellasNivel1.Length; i++)
                {
                    estrellasNivel1[i].active = true;
                }
                break;
        }
        switch (PlayerPrefs.GetInt("nivel2"))
        {
            case 1:
                for (int i = 0; i < estrellasNivel2.Length - 4; i++)
                {
                    estrellasNivel2[i].active = true;
                }
                break;
            case 2:
                for (int i = 0; i < estrellasNivel2.Length - 3; i++)
                {
                    estrellasNivel2[i].active = true;
                }
                break;
            case 3:
                for (int i = 0; i < estrellasNivel2.Length - 2; i++)
                {
                    estrellasNivel2[i].active = true;
                }
                break;
            case 4:
                for (int i = 0; i < estrellasNivel2.Length - 1; i++)
                {
                    estrellasNivel2[i].active = true;
                }
                break;
            case 5:
                for (int i = 0; i < estrellasNivel2.Length; i++)
                {
                    estrellasNivel2[i].active = true;
                }
                break;
        }
        switch (PlayerPrefs.GetInt("nivel3"))
        {
            case 1:
                for (int i = 0; i < estrellasNivel3.Length - 4; i++)
                {
                    estrellasNivel3[i].active = true;
                }
                break;
            case 2:
                for (int i = 0; i < estrellasNivel3.Length - 3; i++)
                {
                    estrellasNivel3[i].active = true;
                }
                break;
            case 3:
                for (int i = 0; i < estrellasNivel3.Length - 2; i++)
                {
                    estrellasNivel3[i].active = true;
                }
                break;
            case 4:
                for (int i = 0; i < estrellasNivel3.Length - 1; i++)
                {
                    estrellasNivel3[i].active = true;
                }
                break;
            case 5:
                for (int i = 0; i < estrellasNivel3.Length; i++)
                {
                    estrellasNivel3[i].active = true;
                }
                break;
        }
        switch (PlayerPrefs.GetInt("nivel4"))
        {
            case 1:
                for (int i = 0; i < estrellasNivel4.Length - 4; i++)
                {
                    estrellasNivel4[i].active = true;
                }
                break;
            case 2:
                for (int i = 0; i < estrellasNivel4.Length - 3; i++)
                {
                    estrellasNivel4[i].active = true;
                }
                break;
            case 3:
                for (int i = 0; i < estrellasNivel4.Length - 2; i++)
                {
                    estrellasNivel4[i].active = true;
                }
                break;
            case 4:
                for (int i = 0; i < estrellasNivel4.Length - 1; i++)
                {
                    estrellasNivel4[i].active = true;
                }
                break;
            case 5:
                for (int i = 0; i < estrellasNivel4.Length; i++)
                {
                    estrellasNivel4[i].active = true;
                }
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
