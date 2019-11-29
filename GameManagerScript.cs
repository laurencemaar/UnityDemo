﻿using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public TMP_Text tmpGameOver;
    public TMP_Text tmpPlayAgain;
    public GameObject goGameOver;


    // Start is called before the first frame update
    void Start()
    {
        goGameOver.SetActive(false);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            Debug.Log(":: END GAME ::");
            gameHasEnded = true;

            // Restart Game
            //Invoke("RestartGame", restartDelay);

            PlayerScript ps = FindObjectOfType<PlayerScript>();
            if (ps)
            {
                ps.playerDead = true;
            }

            PlayerControl_TwinStick pc = GameObject.Find("Player").GetComponent<PlayerControl_TwinStick>();
            if (pc)
            {
                pc.playerDead = true;
            }


            FindObjectOfType<Score>().GameOver = true;

            tmpGameOver.SetText("GAME OVER!");
            tmpPlayAgain.SetText("PLAY AGAIN");
            goGameOver.SetActive(true);

            //GetComponent<AudioSource>().Play();
            GameObject.Find("Audio/Background").GetComponent<AudioSource>().Stop();
            GameObject.Find("Audio/Crash").GetComponent<AudioSource>().Play();

        }
    }

    public void RestartGame()
    {
        //SceneManager.LoadScene("Menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        gameHasEnded = false;
    }
}