using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts;



public class Opponent : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private int health = 100;
    private int damage = 0;
    private float currentAttTimer = 0;
    private int ATT_TIMER = 2;
    private string side = "right";
    private float speed = 4;
    private string startedSide;
    private int speedMultiplier;

    public void Start()
    {
        init();
        speedMultiplier = (startedSide.Equals("right")) ? 1 : -1;
    }

    public void Update()
    {
        Move();
        Die();
        Attack();
    }

    public virtual void init()
    {

    }

    private void Move()
    {
        if (side.Equals(startedSide))
        {

            rb.velocity = new Vector2(speed*speedMultiplier, 0);
            rb.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            rb.velocity = new Vector2(-speed*speedMultiplier, 0);
            rb.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public virtual void Attack()
    {
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("OppWall"))
        {
            side = (side.Equals("right")) ? "left" : "right";
        }
        if (collision.gameObject.name.Equals("Bullet"))
        {
            DecreaseHealth(20);         
            collision.gameObject.SetActive(false);           
        }
    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player") && (Time.fixedTime - currentAttTimer > ATT_TIMER))
        {
            collision.gameObject.GetComponent<Player>().DecreaseHealth(10);
            currentAttTimer = Time.fixedTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            collision.gameObject.GetComponent<Player>().DecreaseHealth(damage);
        }
    }

    public void Die()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void DecreaseHealth(int damage)
    {
        health -= damage;
    }

    public string GetSide()
    {
        return side;
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }

    public Rigidbody2D GetRigidBody()
    {
        return rb;
    }

    public void SetStartedSide(string value)
    {
        startedSide = value;
    }

    public void SetDamage(int value)
    {
        damage = value;
    }

    public void SetHealth(int value)
    {
        health = value;
    }

}

