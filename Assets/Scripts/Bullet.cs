using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.Scripts;



class Bullet : MonoBehaviour
{
    GameObject bullet = new GameObject("Bullet");
    private Sprite sprite1 = Resources.Load<Sprite>("bullet");
    private int timeToLive = 2;
    private float timeCreated = Time.fixedTime;
    private bool destroyed = false;
    private string side = "right";
    private int damage = 20;
        

    public void Create(Player player)
    {
        bullet.transform.localScale += new Vector3(-0.8f, -0.8f, 0);
        bullet.transform.Rotate(Vector3.forward * -90);
        bullet.AddComponent<SpriteRenderer>();
        bullet.GetComponent<SpriteRenderer>().sprite = sprite1;
        bullet.AddComponent<BoxCollider2D>().isTrigger = true;
        if (player.GetSide().Equals("left"))
        {
            bullet.transform.position = new Vector3(player.GetGameObject().transform.position.x - 1, player.GetGameObject().transform.position.y, -2);
            bullet.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            side = "left";
        }
        else
        {
            bullet.transform.position = new Vector3(player.GetGameObject().transform.position.x + 1, player.GetGameObject().transform.position.y, -2);
            bullet.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            side = "right";
        }                              
    }

    public void ToUpdate()
    {
        if (side.Equals("right"))
        {
            bullet.transform.position = new Vector3(bullet.transform.position.x + 0.4f, bullet.transform.position.y, 0);           
        }
        else
        {
            bullet.transform.position = new Vector3(bullet.transform.position.x - 0.4f, bullet.transform.position.y, 0);
            bullet.GetComponent<SpriteRenderer>().flipX = true;
        }           
        if (Time.fixedTime - timeCreated > timeToLive)
        {

        }
    }
    
    public bool IsDestroyed()
    {
        return destroyed;
    }

    public void SetDamage(int _damage)
    {
        damage = _damage;
    }

    public int GetDamage()
    {
        return damage;
    }

}

