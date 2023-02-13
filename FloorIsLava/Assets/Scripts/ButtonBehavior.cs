using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public bool active = false;
    private GameController gc;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            if(!active){
                active = true;
                GetComponent<SpriteRenderer>().color = Color.red;
                gc.buttonsPressed++; 
                Debug.Log("buttons pressed: " + gc.buttonsPressed);
            }

        }
    }
}
