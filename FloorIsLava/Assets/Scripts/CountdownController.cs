using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;

    IEnumerator CountdownToStart()
    {
        while(countdownTime >= 0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        //this is where the timer reaches 0 and starts blinking

        for(int i = 0; i < 5; i++)
        {
            countdownDisplay.gameObject.SetActive(false);
            yield return new WaitForSeconds(.2f);
            countdownDisplay.gameObject.SetActive(true);
            yield return new WaitForSeconds(.2f);

        }
        SceneManager.LoadScene("Loss Screen");

    }
    

    public void StartTimer()
    {
        StartCoroutine(CountdownToStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
