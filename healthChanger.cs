using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthChanger : MonoBehaviour
{
    // Start is called before the first frame update
    private static int health;
    public Sprite health1;
    public Sprite health2;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = playerHealth.health;  //  Update our health continuously.
        
        if (health == 2) {
            //Debug.Log("adsf");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = health2;
        }
        if (health == 1) {
            //Debug.Log(this.gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = health1;
        }
        if (health == 0) {
            Destroy(this.gameObject);
            FindObjectOfType<manageGame>().endGame();
        }
    }

    
}
