using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Camera : MonoBehaviour
{
    public GameObject character;
    public GameObject background;

    void Start()
    {
    
    }

    
    void Update()
    {
        transform.position = new Vector3(character.transform.position.x, character.transform.position.y + 1, -30);
        background.transform.position = new Vector3(transform.position.x / 1.01f, transform.position.y - 0.1f, 100);
    }
}
