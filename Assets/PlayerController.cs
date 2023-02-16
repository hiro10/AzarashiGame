using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    public float maxHeight;

    public float flapVelocity;

    Animator animator;
    float angle;

    public float relativeVelocityX;
    public GameObject sprite;

    bool isdead = false;

    public bool IsDead()
    {
        return isdead;
    }

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1")&&transform.position.y<maxHeight)
        {
            Flap();
        }

        ApplyAngle();

        animator.SetBool("flap", angle >= 0.0f&& !isdead);
    }

    public void Flap()
    {
        if(isdead==true)
        {
            return;
        }

        if(rigidbody2d.isKinematic)
        {
            return;
        }

        rigidbody2d.velocity = new Vector3(0.0f, flapVelocity);
    }

    private void ApplyAngle()
    {
        float targetAngle;
        if (isdead)
        {
            targetAngle = 180f;
        }
        else
        {
            targetAngle = Mathf.Atan2(rigidbody2d.velocity.y, relativeVelocityX) * Mathf.Rad2Deg;
        }
        angle = Mathf.Lerp(angle, targetAngle, Time.deltaTime * 10f);

        sprite.transform.localRotation = Quaternion.Euler(0f, 0f, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isdead)
        {
            return;
        }
        Camera.main.SendMessage("Clash");

        isdead = true;
    }

    public void SetSteerActive(bool active)
    {
        rigidbody2d.isKinematic = !active;
    }
}
