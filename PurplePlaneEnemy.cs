using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurplePlaneEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private int timeActive;
    float x;
    public GameObject myPrefab;
    void Start()
    {
        timeActive = 0;
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed,0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        timeActive += 1;
        if(timeActive % 25 == 0) // change freq of up and down movement
        {
            x = Mathf.Cos(timeActive);
            rb.velocity = new Vector2(-speed,x*speed*0.45f);
        }
        //Debug.Log(x);


        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //health = playerHealth.health;
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
            //distanceCounter.distance += 100;
            
            
            //Debug.Log(health);
        }
    }
}
