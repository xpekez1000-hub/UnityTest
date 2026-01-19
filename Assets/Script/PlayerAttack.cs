using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    public GameObject fireBulletPrefab;
    public Transform firePoint;

    public void Fire()
    {
        GameObject bullet = Instantiate(fireBulletPrefab, firePoint.position, Quaternion.identity);
        Vector2 dir = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        bullet.GetComponent<FireBall>().SetDirection(dir);
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetTrigger("Strike");
        }
    }
}
