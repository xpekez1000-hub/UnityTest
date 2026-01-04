using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    Animator anim;

    void Start()
    {

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        transform.Translate(Vector2.right * h * speed * Time.deltaTime);

        anim.SetBool("Walking", h != 0);
    }
}
