using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthChanger : MonoBehaviour
{
    // Start is called before the first frame update
    private static int health;
    public Sprite health0;
    public Sprite health1;
    public Sprite health2;
    public Sprite healthN;
    public GameObject hitMarker;
    private int zeroHealthTimer = 0;
    private int zeroHealthTimer2;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = playerHealth.health;  //  Update our health continuously.
        //Donebool = playerHealth.hitMarkerBoolDone;

        if (health == 2) {
            //Debug.Log("adsf");
            this.gameObject.GetComponent<SpriteRenderer>().sprite = health2;
        }
        if (health == 1) {
            //Debug.Log(this.gameObject);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = health1;
        }
        if (health == 0) {
            zeroHealthTimer++;
            //zeroHealthTimer2 = zeroHealthTimer % 10;
            if(zeroHealthTimer % 40 == 0)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = health0;
            if(zeroHealthTimer % 20 == 0 && !(zeroHealthTimer % 40 == 0))
            this.gameObject.GetComponent<SpriteRenderer>().sprite = healthN;
            // GameObject e = Instantiate(hitMarker) as GameObject;
            // e.transform.position = transform.position;
            // Destroy(e, .9f);
            //Invoke("endGame", .5f);
            
        }
    }

    void endGame(){
        Destroy(this.gameObject);
        FindObjectOfType<manageGame>().endGame();
    }

    
}
