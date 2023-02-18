using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector3 spawnPoint;
    Vector3 startScale;
    Rigidbody2D rb;
    [SerializeField] float jumpingDuration, speed, knockbackDuration, knockbackForce;
    bool isJumping, isStunned;
    IsGrounded gr;
    Color startColor;
    Color[] playerColors = new Color[] { new Color(51f / 255f, 34f / 255f, 136f / 255f , 1f), 
        new Color(17f / 255f, 119f / 255f, 51f / 255f, 1f),
        new Color(170f / 255f, 68f / 255f, 153f / 255f , 1f),
        new Color(136f / 255f, 204f / 255f, 238f / 255f , 1f) };
    [SerializeField] Vector3[] spawnPositions = new Vector3[] { new Vector3(-0.75f, 0.5f, 0f),
        new Vector3(0.75f, 0.5f, 0f),
        new Vector3(0f, -0.5f, 0f) };
    Coroutine cr;

    GameManager gm;

    Vector2 moveVector;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        cr = null;
        spawnPoint = transform.position;
        startScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        gr = GetComponent<IsGrounded>();

        GameObject[] playerArray = GameObject.FindGameObjectsWithTag("Player");
        startColor = playerColors[playerArray.Length - 1];
        transform.position = spawnPositions[playerArray.Length - 1];
        GetComponent<SpriteRenderer>().color = startColor;
        gm.AddP(this.gameObject);
    }


    // Update is called once per frame
    void LateUpdate()
    {
        //Debug.Log(gr.grounded);
        if (!gr.grounded && !isJumping)
        {
            isStunned = true;
            rb.velocity = Vector3.zero;
            Fall();
        }
    }

    private void FixedUpdate()
    {
        if(!isStunned && !isJumping)
            rb.velocity = moveVector * speed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }

    void Fall()
    {
        if (cr == null)
            cr = StartCoroutine(Die());
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (isJumping == false && context.performed && gr.grounded)
        {
            isJumping = true;
            StartCoroutine(Jumping());
        }
    }
    IEnumerator Jumping()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(jumpingDuration);
        GetComponent<SpriteRenderer>().color = startColor;
        isJumping = false;
    }

    IEnumerator Die()
    {
        while(transform.localScale.x >0)
        {
            yield return new WaitForSeconds(0.01f);
            transform.localScale = transform.localScale - new Vector3(0.01f, 0.01f, 0.01f);
        }
        StartCoroutine(Respawn());
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        gr.grounded = true;
        isStunned = false;
        isJumping = false;
        transform.position = gr.last;
        transform.localScale = startScale;
        cr = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isStunned = true;
            rb.velocity = -(collision.transform.position - transform.position).normalized * knockbackForce;
            StartCoroutine(PlayerCollision());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Door"))
        {
            gm.RemoveP(this.gameObject);
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
            isStunned = true;
        }
    }

    IEnumerator PlayerCollision()
    {
        yield return new WaitForSeconds(knockbackDuration);
        rb.velocity = Vector3.zero;
        isStunned = false;
    }
}
