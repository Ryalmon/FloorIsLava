using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    //public int buttonsPressed = 0;

    void WinGame(){
        SceneManager.LoadScene("Win Screen");
    }

    public void ButtonRestart(){
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void LoadTitleScreen(){
        SceneManager.LoadScene("Title Screen");
    }
}
