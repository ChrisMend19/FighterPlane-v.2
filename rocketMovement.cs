using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;
    //public float timer = 0;
    private Rigidbody2D rb;
     
    private Vector2 screenBounds;
    private static int health;
    public float timer = 0;
    public GameObject myPrefab;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0,-speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        //Debug.Log(screenBounds/2);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenBounds.x * 5) {
            //Debug.Log("asdf");
            Destroy(this.gameObject);
        }
        timer++;
        //Debug.Log(timer);
        if (timer == 40) {
            //Debug.Log("adsf");
            rb.velocity = new Vector2(-speed*2,0);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        health = playerHealth.health;
        if(other.tag == "playerPlane") {
            //GameObject e = Instantiate() as GameObject;
            //e.transform.position = transform.position;
            
            //Debug.Log("hit");
            //Debug.Log(health);
            //health--;
            Destroy(this.gameObject);
            GameObject e = Instantiate(myPrefab) as GameObject;
            e.transform.position = transform.position;
            Destroy(e, .35f);
            //Debug.Log(health);
        }
    }

    
}
