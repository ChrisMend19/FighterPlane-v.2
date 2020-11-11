﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossOneBehavior : MonoBehaviour
{
    // Start is called before the first frame update
     private Rigidbody2D rigidBody;
     private float planeBody;
     private float bossBody;
     private joystickShoot playerControls;
     private float speed = 1.5f; //find way to link player direction
     public GameObject spikePrefab;
     public GameObject minionPrefab;
     public Transform player;
     private distanceCounter counter;
     private int count;
     private bool fired = false;
     private bool fired2 = false;
     private int distance;
     public float bossHealth = 100;//
     public GameObject hitMarker;
     private int startShoot = 660;
     private int startMinions =  740;
     private Vector2 screenBounds;
     public bool bossOneOn = false;
     public bool bossOneHealthOn = false;
     public bossOneHealth bossOneHealth;
     public GameObject bosssOneHealthBar;
     
     public GameObject bosssHealth;
     //public deployRockets deployRockets;
     
     
     
     
    void Start()
    {    //fix!!!!
        rigidBody = this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        bossOneOn = true;
        //Debug.Log(deployRockets.doSpawn);
        
        //Debug.Log(bossOneHealth.getHealth()); //fix health bar b1

        //bossOneHealth.setMaxHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(bossOneOn); //follow plane
        bossBody = transform.position.y;
        planeBody = GameObject.Find("Plane").transform.position.y;
        if(planeBody > bossBody) {
            rigidBody.velocity = new Vector2(0,speed);
            
        }
        else if(planeBody < bossBody) {
            rigidBody.velocity = new Vector2(0,-speed);
        }
        else {
            rigidBody.velocity = new Vector2(0,0);
        }

        shootTimes(startShoot);
        shootTimesMinions(startMinions); //boss attack
        //shootMinions();
        /*
        if (bossOneOn && !bossOneHealthOn) {
            bossOneHealthOn = true;
            spawnBossHealth();
            //Debug.Log(bossOneOn);
            bossOneHealth.setHealth(100);
            
        }
        bossOneHealth.setHealth(bossHealth); 
         //fix bool not updating to BOH
         */


    

    }
    public bool getBossOn() {
        return bossOneOn;
    }
    void spawnBossHealth() {
        //GameObject a = Instantiate(bosssHealth) as GameObject;
        //GameObject d = Instantiate(bosssOneHealthBar) as GameObject;
        //a.transform.position = transform.position;
        //a.transform.position = new Vector2(screenBounds.x-4.5f, screenBounds.y-7);
    }

    void shootSpikeBall(){
        GameObject b = Instantiate(spikePrefab) as GameObject;
        b.transform.position = player.transform.position - new Vector3(1f,0.5f,0);
    }

    void shootMinions(){
        GameObject c = Instantiate(minionPrefab) as GameObject; //fix
        c.transform.position = new Vector2(screenBounds.x + 5, Random.Range(-screenBounds.y + 5f , screenBounds.y - 2.7f));
    }

    void shootTimes(int distance) {
         //fix  boss  gun
        count = distanceCounter.distance;
        if (count == distance && !fired) { //660
            //Debug.Log("spike");
            shootSpikeBall();
            fired = true;
            //Debug.Log(distance);
        }
        if (count == distance + 4) { //fire rate
            fired = false;
            startShoot += 20;
        }
    }
    void shootTimesMinions(int distance2) {
         //fix  boss  gun
        count = distanceCounter.distance;
        if (count == distance2 && !fired2) { //660
            //Debug.Log("spike");
            shootMinions();
            fired2 = true;
            //Debug.Log(distance);
        }
        if (count == distance2 + 4) { //fire rate
            fired2 = false;
            startMinions += 40;
        }
    }

    public float getBossOneHealth() {
        return bossHealth;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "planeBlast") {
            bossHealth -= 12.5f;
            Debug.Log(bossHealth);
            bossOneHealth.setHealth(bossHealth);
            if (bossHealth == 0) {
                Destroy(this.gameObject);
                bossOneOn = false;
                Debug.Log("dead");
            }
        }
        
    }
}
