using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> buttons;
    public List<GameObject> players;
    private DoorBehavior door;
    bool changed = false;

    private void Awake()
    {
        buttons = new List<GameObject>();
        players = new List<GameObject>();
    }
    void Start()
    {
        door = FindObjectOfType<DoorBehavior>();
    }

    public void AddB(GameObject temp)
    {
        buttons.Add(temp);
        changed = true;
    }

    public void RemoveB(GameObject temp)
    {
        buttons.Remove(temp);
        changed = true;
    }

    public void AddP(GameObject temp)
    {
        players.Add(temp);
        changed = true;
    }

    public void RemoveP(GameObject temp)
    {
        buttons.Remove(temp);
        changed = true;
    }
    void Update()
    {
        if (changed) 
        {
            changed = false;
            Debug.Log(buttons.Count);
            if (buttons.Count <= 0)
            {
             door.Open();
            }

            if (door.open && players.Count <= 0)
            {
                Debug.Log("all players left.");
                WinGame();
            }
        }
    }
    void BeginGame()
    {
        //buttonsPressed = 0;

    }
    void WinGame()
    {
        SceneManager.LoadScene("Win Screen");
    }
}
