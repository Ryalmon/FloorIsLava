using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int buttonsPressed = 0;

    void Update(){
        if(buttonsPressed > 4){
            Debug.Log("all buttons pressed.");
            EndGame();
        }
    }
    void BeginGame(){
        buttonsPressed = 0;

    }
    void EndGame(){

    }

    public void ButtonRestart(){
        Debug.Log("Replace this with the main menu or first level");
    }
}
