using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeEnemyBomb : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20.0f;
    private Rigidbody2D rigidBody;
    private Vector2 screenBounds;
    public GameObject bulletPrefab;
    public Transform player;
    public float timer = 50f;
    private static int health;
    public GameObject myPrefab;

    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(-speed*2,0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > screenBounds.x * 7 ) {
            Destroy(this.gameObject);
        }
        if (timer == 0) {
            shootBullet();
        }
        timer = timer - 1f;
        //Debug.Log(timer);

    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "playerPlane") {
            Destroy(this.gameObject);
            health = playerHealth.health;
            health --;
            explosionPlane();
        }
        
    }

    void shootBullet(){
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = player.transform.position;
        
    }
    
    public void explosionPlane() {
        GameObject e = Instantiate(myPrefab) as GameObject;
        e.transform.position = transform.position;
        Destroy(e, .35f);
    }
    
    
}
