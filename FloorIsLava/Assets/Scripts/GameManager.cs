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

    [SerializeField] CountdownController timer;
    [SerializeField] int twoStarMark, threeStarMark;
    public static int numStars;

    private void Awake()
    {
        buttons = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ground"));
        Debug.Log(buttons.Count);
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
        players.Remove(temp);
        changed = true;
    }
    void Update()
    {
        if (changed) 
        {
            changed = false;
            Debug.Log(door.open);
            Debug.Log(players.Count);
            if (buttons.Count <= 0)
            {
              door.Open();
            }

            if (buttons.Count>0)
            {
                door.Close();
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
        if (timer.countdownTime >= threeStarMark)
        {
            numStars = 3;
        }
        else if (timer.countdownTime >= twoStarMark)
        {
            numStars = 2;
        }
        else
        {
            numStars = 1;
        }

        SceneManager.LoadScene("Win Screen");
    }
}
