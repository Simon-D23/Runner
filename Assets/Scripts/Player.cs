using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using UnityEngine.SceneManagement;

[SerializePrivateVariables]

public class Player : MonoBehaviour {
    
    private GameObject player;
    private Rigidbody2D rb;
    private Inventory inventory = new Inventory();
    public AudioSource audioSource;
    

    private int health = 0;
    private int MAX_HEALTH = 100;
    private int energy = 0;
    private int MAX_ENERGY = 100;
    private float x;
    private float y;
    private float jump;
    private float speed;
    private float MAX_SPEED;
    private string side = "right";
    private bool win = false;

    private bool isGrounded = false;
    private bool canClimbLadder = false;
    private float canClimbLadderTimer = 0;
    private float canClimbLadderMaxTime = 25;

    private const int ENERGY_TIMER = 1;
    private const int ACTION_TIMER = 1;
    private const int DEAD_TIMER = 3;
    private float currentActionTimer = 0;
    private float currentEnergyTimer = 0;
    private float currentDeadTimer = 0;
    

    void Start () {        
        inventory.SetPlayer(this);
        player.GetComponent<Animator>().enabled = false;
    }
	
	void Update () {
        if (health > 0)
        {
            Move();
            Jump();
            inventory.EquipedItems();
            inventory.UseEquipItem();
            FreeCraft();
            BulletsRep.ToUpdate();
            Energy();          
        }
        Die();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }      
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Climb(collision);
        Eat(collision);
        TakeItem(collision);
        Hit(collision);
        Fall(collision);
    }
    
    private void Climb(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder") && Time.fixedTime - canClimbLadderTimer <= canClimbLadderMaxTime)
        {
            if (Input.GetKey("w"))
            {
                rb.velocity = new Vector2(0, 8);
            }
            if (Input.GetKey("d") && rb.velocity.x <= 8)
            {
                rb.velocity += new Vector2(speed, 0);
            }
            if (Input.GetKey("a") && rb.velocity.x >= -8)
            {
                rb.velocity -= new Vector2(speed, 0);
            }
        }
        if (collision.gameObject.CompareTag("Ladder") && !(Time.fixedTime - canClimbLadderTimer <= canClimbLadderMaxTime)) {
            GetComponent<HUD>().SetTooFatText("You'r too Fat Boyyy");
            GetComponent<HUD>().SetTooFatTextTimer(Time.fixedTime);
        }

    }

    private void TakeItem(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            if (Input.GetKey("e"))
            {               
                inventory.EquipItem(collision.gameObject);               
            }
        }
        if (collision.gameObject.CompareTag("Item"))
        {
            if (Input.GetKey("e"))
            {
                inventory.Add(collision.gameObject);
                collision.gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.name.Equals("Coin"))
        {
            inventory.AddCoin(1);
            collision.gameObject.SetActive(false);
        }
    }
    
    private void FreeCraft()
    {
        if (Input.GetKey("c") && inventory.Contain("Plank") > 1 && Time.fixedTime - currentActionTimer > ACTION_TIMER)
        {
            ItemFactory.Create("Ladder", transform.position.x, transform.position.y - 0.3f);          
            currentActionTimer = Time.fixedTime;
            inventory.Remove("Plank", 2);
        }
    }

    private void Eat(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mushroom"))
        {
            collision.gameObject.SetActive(false);
            canClimbLadder = true;
            canClimbLadderTimer = Time.fixedTime;
            canClimbLadderMaxTime = 25;
            IncreaseEnergy(30);
            IncreaseHealth(30);
        }
        if (collision.gameObject.name.Equals("Cake"))
        {
            collision.gameObject.SetActive(false);
            IncreaseEnergy(60);
            IncreaseHealth(40);
        }
    }

    private void Move()
    {
        if (Input.GetKey("d") && rb.velocity.x <= 8)
        {
            rb.velocity += new Vector2(speed, 0);
            player.GetComponent<Animator>().enabled = true;
            player.GetComponent<SpriteRenderer>().flipX = false;
            side = "right";

        }
        else if (Input.GetKey("a") && rb.velocity.x >= -8)
        {
            rb.velocity -= new Vector2(speed, 0);
            player.GetComponent<Animator>().enabled = true;
            player.GetComponent<SpriteRenderer>().flipX = true;
            side = "left";       
        }
        else
        {
            player.GetComponent<Animator>().enabled = false;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
            rb.velocity += new Vector2(0, jump);
        }
    }
    
    public void Hit(Collider2D collision)
    {
        if (Input.GetKey("k"))
        {
            player.GetComponent<Animator>().enabled = true;
        }
    }

    public void Fall(Collider2D collision)
    {
        if (collision.name.Equals("FallHit"))
        {
            health = 0;
        }
    }

    public void Energy()
    {
        if (Time.fixedTime - currentEnergyTimer > ENERGY_TIMER)
        {
            DecreaseEnergy(2);
            speed = MAX_SPEED * ((energy + 50f) / (float)MAX_ENERGY);
            speed = (speed > MAX_SPEED) ? MAX_SPEED : speed;      
            currentEnergyTimer = Time.fixedTime;
        }
        if (energy < 30)
        {
            GetComponent<HUD>().SetInfoText("Fat Ass Need Sugar?");
            GetComponent<HUD>().SetLittleHotTimer(Time.fixedTime);
        }
        else if (GetComponent<HUD>().GetInfoText() == "Fat Ass Need Sugar?")
        {
            GetComponent<HUD>().SetInfoText("");
        }
    }

    public void Die()
    {
        if (health <= 0) {
            GetComponent<SpriteRenderer>().sprite = null;
            if (currentDeadTimer == 0)
            {
                currentDeadTimer = Time.fixedTime;
            }
            if (Time.fixedTime - currentDeadTimer > 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void IncreaseEnergy(int value)
    {
        energy += value;
        energy = (energy > MAX_ENERGY) ? MAX_ENERGY : energy;
    }

    public void DecreaseEnergy(int value)
    {
        energy -= value;
        energy = (energy < 0) ? 0 : energy;
    }

    public void IncreaseHealth(int value)
    {
        health += value;
        health = (health > MAX_HEALTH) ? MAX_HEALTH : health;
    }

    public void DecreaseHealth(int damage)
    {
        health -= damage;
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetEnergy()
    {
        return energy;
    }

    public string GetSide()
    {
        return side;
    }

    public void SetWin(bool value)
    {
        win = value;
    }
    public bool GetWin()
    {
        return win;
    }

    public void SetInfoText(string value)
    {
        GetComponent<HUD>().SetInfoText(value);
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

}
