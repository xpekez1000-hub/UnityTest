using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float timeToDie = 10f;   
    private float timer;

    private bool isDead = false;

    private Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        timer = timeToDie; 
    }

    void Update()
    {
        if (isDead) return;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        anim.SetBool("isDead", true);

        rb.velocity = Vector2.zero;
        rb.simulated = false;

        // tắt điều khiển
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
    }
}
