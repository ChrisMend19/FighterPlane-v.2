using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerBlast : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 50.0f;
    
    private Rigidbody2D rigidBody;
    private Vector2 screenBounds;
    public GameObject myPrefab;
    private bossOneController boss;
    private distanceCounter distance;
    public bool blastHitmarker;
    int count;
    
    

    void Start()
    {
    
        rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(speed,0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        //explosionPlane.explosionPlane();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > screenBounds.x ) {
            Destroy(this.gameObject);
        }
        blastHitmarker = false;
        
        
        
    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "planeEnemy" || other.tag == "pufferfish") { //dies in one shot //test
            distanceCounter.distance += 100;
            blastHitmarker = true;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            GameObject e = Instantiate(myPrefab) as GameObject;
            e.transform.position = transform.position;
            Destroy(e, .35f);
        }
        if(other.tag == "bossOne") { //takes many to  die
            Destroy(this.gameObject);
            GameObject e = Instantiate(myPrefab) as GameObject;
            e.transform.position = transform.position;
            Destroy(e, .35f);
        }
    }

    public bool getBlastHitmarker(){
        return blastHitmarker;
    }

    

    
}
