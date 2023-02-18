using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{

    public bool open = false;
    SpriteRenderer sr;
    public Sprite openDoor;
    public Sprite closeDoor;
    Collider2D col;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        col.isTrigger = true;
        open = false;
        closeDoor = sr.sprite;
    }
    // Start is called before the first frame update
    public void Open()
    { 
        sr.sprite = openDoor;
        open = true;
    }

    public void Close()
    {
        sr.sprite = closeDoor;
        open = false;
    }


    
}
