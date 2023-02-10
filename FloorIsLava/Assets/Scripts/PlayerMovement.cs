using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector3 spawnPoint;
    Vector3 startScale;
    PlayerControls pc;
    Rigidbody2D rb;
    [SerializeField] float jumpingDuration, speed, knockbackDuration, knockbackForce;
    bool isJumping, isStunned;
    IsGrounded gr;
    Color debugStartColor;
    Coroutine cr;
    // Start is called before the first frame update

    private void Awake()
    {
        pc = new PlayerControls();
        pc.Enable();
        pc.BasicControls.Jump.performed += _ => Jump();

    }
    void Start()
    {
        cr = null;
        spawnPoint = transform.position;
        startScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        gr = GetComponent<IsGrounded>();
        debugStartColor = GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Debug.Log(gr.grounded);
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
            rb.velocity = pc.BasicControls.Move.ReadValue<Vector2>() * speed;
    }

    void Fall()
    {
        if (cr == null)
            cr = StartCoroutine(Die());
    }

    void Jump()
    {
        if (isJumping == false)
        {
            isJumping = true;
            StartCoroutine(Jumping());
        }
    }
    IEnumerator Jumping()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(jumpingDuration);
        GetComponent<SpriteRenderer>().color = debugStartColor;
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
        transform.position = spawnPoint;
        transform.localScale = startScale;
        cr = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isStunned = true;
            rb.velocity = (collision.transform.position - transform.position).normalized * knockbackForce;
            StartCoroutine(PlayerCollision());
        }
    }

    IEnumerator PlayerCollision()
    {
        yield return new WaitForSeconds(knockbackDuration);
        rb.velocity = Vector3.zero;
        isStunned = false;
    }
}
