using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarMeter : MonoBehaviour
{
    [SerializeField] Slider starTimerBar;
    [SerializeField] CountdownController countdownController;

    private void Update()
    {
        starTimerBar.value = countdownController.countdownTime / 120f;
    }
}
