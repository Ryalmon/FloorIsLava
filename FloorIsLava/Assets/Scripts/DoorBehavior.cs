using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    public bool open = false;
    SpriteRenderer sr;
    Collider2D col;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        col.isTrigger = false;
        open = false;
    }
    // Start is called before the first frame update
    public void Open()
    { 
        sr.color = Color.green;
        col.isTrigger = true;
        open = true;
    }


    
}
