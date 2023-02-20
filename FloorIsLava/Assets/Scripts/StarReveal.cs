using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarReveal : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI starCountText;

    private void Awake()
    {
        starCountText.text = "You Got " + GameManager.numStars + " stars!";
    }
}
