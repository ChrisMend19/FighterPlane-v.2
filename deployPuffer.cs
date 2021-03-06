﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployPuffer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;
    public float respawnTime = 0.8f;
    private Vector2 screenBounds;
    private distanceCounter counter;
    private int count;
    private bool doSpawn = true;
    private bossOneBehavior boss;
    private float bossHealth;
    private playerHealth ph;
    private bool crash;
    public SpriteRenderer background;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        StartCoroutine(rocketWave());
    }
    void Update() {
        crash = GameObject.Find("Plane").GetComponent<playerHealth>().crashPlaneBegin;
        if(respawnTime > 0.25){
            respawnTime -= 0.0001f;
        }
        //turnOffEnemies(); // removes the turning off of enemies for bosses
    }

    private void spawnEnemy() {
        if(!crash){
            GameObject a = Instantiate(myPrefab) as GameObject;
            a.transform.position = new Vector2(background.bounds.size.x - 15, Random.Range((float)background.bounds.size.y * -0.22f , (float)background.bounds.size.y * 0.5f)); //fix this bounds so bombs deploy over water
        }
    }

    IEnumerator rocketWave() {
        while (true && doSpawn) {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }

    private void turnOffEnemies() {
        count = distanceCounter.distance;
        if (count == 850) {
            doSpawn = false;
        }
        
    }

    private void turnOnEnemies() {
        count = distanceCounter.distance;
        Debug.Log(count);
        if (count == 750) {
            doSpawn = true;
        }
    }
}
