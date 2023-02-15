using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public bool active = false;
    //private GameController gc;
    private GameController gc;
    private SpriteRenderer sr;
    public Sprite pressedButton;
    // Start is called before the first frame update
    GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        sr.sprite = pressedButton;
        //gm.AddB(this.gameObject);
       
    }


    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("Player")){
            if(!active){
                active = true;
                gm.RemoveB(this.gameObject);
                sr.sprite = pressedButton;
            }

        }
    }
}
