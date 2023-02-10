using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 spawnPoint;
    Vector3 startScale;
    PlayerControls pc;
    Rigidbody2D rb;
    [SerializeField] float jumpingDuration, speed;
    bool isJumping, isStunned;
    IsGrounded gr;
    // Start is called before the first frame update

    private void Awake()
    {
        pc = new PlayerControls();
        pc.Enable();
        pc.BasicControls.Jump.performed += _ => Jump();

    }
    void Start()
    {
        spawnPoint = transform.position;
        startScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        gr = GetComponent<IsGrounded>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!gr.grounded && !isJumping)
        {
            isStunned = true;
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

    }

    void Jump()
    {
        isJumping = true;
        StartCoroutine(Jumping());
    }
    IEnumerator Jumping()
    {
        yield return new WaitForSeconds(jumpingDuration);
        isJumping = false;
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        transform.position = spawnPoint;
        transform.localScale = startScale;
        isStunned = false;
        isJumping = false;
    }
}
