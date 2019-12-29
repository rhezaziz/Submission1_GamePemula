using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public BallController ball;

    public void playGame(){
        SceneManager.LoadScene("SampleScene");

    }
    public void mainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void ulang(){
        //FindObjectOfType<BallController>().UlangGame(ball);
        Application.LoadLevel(Application.loadedLevel);
    }
}
