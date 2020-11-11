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
    public bool doSpawn = true;
    private bossOneBehavior boss;
    public float bossHealth;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        StartCoroutine(rocketWave());
        
        //bossHealth = boss.bossHealth;
    }

    void Update() {
        turnOffEnemies();
        //turnOnEnemies();
        Debug.Log(doSpawn);
    }

    private void spawnEnemy() {
        GameObject a = Instantiate(myPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x + 5, Random.Range(-screenBounds.y + 7 , screenBounds.y - 1.75f)); //fix this bounds so bombs deploy over water
        
        
    }

    IEnumerator rocketWave() {
        while (doSpawn) {
            //Debug.Log("b");
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
            //Debug.Log("h");
        }
    }
    

    private void turnOffEnemies() {
        count = distanceCounter.distance;
        //Debug.Log(count);
        if (count == 430) {
            doSpawn = false;
        }
        if (count > 750) {
            doSpawn = true;
            
        }
    }
}
