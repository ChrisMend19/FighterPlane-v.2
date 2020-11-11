using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveElectricWall : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed = 5;
    public GameObject myPrefab;
    private Vector2 screenBounds;
    private static int health;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed,0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update() {
        //rigidbody.velocity = new Vector2(-speed,0);
        if (transform.position.x < -screenBounds.x * 5) {
            //Debug.Log("asdf");
            Destroy(this.gameObject);
        }   
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        //health = playerHealth.health;
        if(other.tag == "playerPlane") {
            health = playerHealth.health;
            health --;
            //GameObject e = Instantiate() as GameObject;
            //e.transform.position = transform.position;
            
            //Debug.Log("hit");
            //Debug.Log(health);
            //health--;
            Destroy(this.gameObject);
            GameObject e = Instantiate(myPrefab) as GameObject;
            e.transform.position = transform.position;
            Destroy(e, 0.1f);
        }
    }
}
