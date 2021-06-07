using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployRockets : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    private distanceCounter counter;
    private int count;
    //copy this  code for pufferfish and change random spawn range
    public bool doSpawn;
    private bossOneBehavior boss;
    public float bossHealth;
    private playerHealth ph;
    private bool crash;
    public SpriteRenderer background;


    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        StartCoroutine(rocketWave());
        doSpawn = true;
    }

    void Update() {        

        crash = GameObject.Find("Plane").GetComponent<playerHealth>().crashPlaneBegin;
        if(respawnTime > 0.5){
            respawnTime -= 0.0001f;
        }
        //turnOffEnemies(); // turn back on enemies since no boss
        rocketWave();
    }

    private void spawnEnemy() {
        if(!crash){
            GameObject a = Instantiate(myPrefab) as GameObject;
            a.transform.position = new Vector2(background.bounds.size.x-15, Random.Range((float)background.bounds.size.y * -0.05f , (float)background.bounds.size.y * 0.4f)); //fix this bounds so bombs deploy over water
        }
        
    }

    IEnumerator rocketWave() {
        while (doSpawn) {
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
}
