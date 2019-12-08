using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

[SerializePrivateVariables]

public class Saw : MonoBehaviour
{
    private float rotate = 0;
    
    void Start()
    {

    }
    
    void Update()
    {
        rotate += 0.2f;
        transform.Rotate(Vector3.forward * rotate);
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("CrateGold"))
        {
            for (int i = 0; i < 6; i++)
            {
                GameObject plank = new GameObject("Plank");
                plank.transform.position = new Vector3(collision.transform.position.x + 1, collision.transform.position.y - 0.3f, -2);
                plank.transform.localScale += new Vector3(0.2f, 0.2f, 0);
                plank.AddComponent<SpriteRenderer>();
                plank.GetComponent<SpriteRenderer>().sprite = Resources.LoadAll<Sprite>("TerrainTileset")[17];
                plank.AddComponent<BoxCollider2D>().isTrigger = true;
                plank.tag = "Item";
                plank.name = "Plank";
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.Equals("Player"))
        {
            collision.GetComponent<Player>().DecreaseHealth(100);
        }
    }
}
