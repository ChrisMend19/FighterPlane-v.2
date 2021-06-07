using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossOneBots : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;
    public GameObject hitmarker;
    public Rigidbody2D rb;
    public float respawnTime = 1.0f;
    public float speed = 8f;
    private Vector2 screenBounds;
    private distanceCounter counter;
    private int count;
    private bool doSpawn = true;
    private bossOneBehavior boss;
    private float bossHealth;
    private bool crash;

    //copy this  code for pufferfish and change random spawn range

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        StartCoroutine(rocketWave());
        rb =  this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed,0);
    }
    void Update() {
        //turnOffEnemies();
        //turnOnEnemies();
        crash = GameObject.Find("Plane").GetComponent<playerHealth>().crashPlaneBegin;
        Debug.Log(crash); // fix boss from spawning after dealth. Delete error bossone controller  then  focus on puffer despawn and rockets try adding 
        // !crash if statemetn in boss1behavior instead
        if (rb.transform.position.x < -screenBounds.x * 8 ) {
            Destroy(this.gameObject);
        }
    }

    private void spawnEnemy() {
        if(!crash){
            GameObject a = Instantiate(myPrefab) as GameObject;
            a.transform.position = new Vector2(screenBounds.x + 5, Random.Range(-screenBounds.y + 6 , screenBounds.y - 0.75f)); //fix this bounds so bombs deploy over water
        }
    }

    IEnumerator rocketWave() {
        while (true && doSpawn) {
            yield return new WaitForSeconds(respawnTime);
            //spawnEnemy();
            //Debug.Log(screenBounds);
        }
    }

    private void turnOffEnemies() {
        count = distanceCounter.distance;
        //Debug.Log(count);
        if (count == 850) {
            doSpawn = false;
        }
        
    }

    private void turnOnEnemies() {
        count = distanceCounter.distance;
        if (count == 750) {
            doSpawn = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "playerPlane") {

            Destroy(this.gameObject);
            GameObject e = Instantiate(hitmarker) as GameObject;
            e.transform.position = transform.position;
            Destroy(e, .35f);
        }
    }
}

