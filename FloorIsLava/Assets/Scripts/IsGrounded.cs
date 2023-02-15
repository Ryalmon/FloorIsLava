using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{

    public bool grounded = true;
    public Vector2 last;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       if (collision.CompareTag("Ground"))
        {
            grounded = false;
            last = collision.transform.position;
        }
    }
}
