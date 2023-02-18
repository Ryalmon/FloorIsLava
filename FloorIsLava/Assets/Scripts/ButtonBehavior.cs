using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public bool active = false;
    //private GameController gc;
    //private GameController gc;
    private SpriteRenderer sr;
    //public Sprite pressedButton;
    //public Sprite unpressed;
    Color unPressedColor;
    public Color pressedColor;
    // Start is called before the first frame update
    GameManager gm;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        gm = FindObjectOfType<GameManager>();
        //unpressed = sr.sprite;

        //gm.AddB(this.gameObject);
        unPressedColor = sr.color;
       
    }


    void OnTriggerEnter2D(Collider2D collider){
        Debug.Log("pressed");
        if(collider.CompareTag("Player")){
            if(!active){
                active = true;
                gm.RemoveB(this.gameObject);
                sr.color = pressedColor;
                //sr.sprite = pressedButton;
            }
            else if(active)
            {
                active = false;
                gm.AddB(this.gameObject);
                sr.color = unPressedColor;
                //sr.sprite = unpressed;
            }

        }
    }
}
