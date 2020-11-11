using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployPuffer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    private distanceCounter counter;
    private int count;
    private bool doSpawn = true;
    private bossOneBehavior boss;
    private float bossHealth;

    //copy this  code for pufferfish and change random spawn range

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        StartCoroutine(rocketWave());
    }
    void Update() {
        turnOffEnemies();
        turnOnEnemies();
    }

    private void spawnEnemy() {
        GameObject a = Instantiate(myPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x + 5, Random.Range(-screenBounds.y + 6 , screenBounds.y - 0.75f)); //fix this bounds so bombs deploy over water
        
    }

    IEnumerator rocketWave() {
        while (true && doSpawn) {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
            //Debug.Log(screenBounds);
        }
    }

    private void turnOffEnemies() {
        count = distanceCounter.distance;
        //Debug.Log(count);
        if (count == 400) {
            doSpawn = false;
        }
    }

    private void turnOnEnemies() {
        count = distanceCounter.distance;
        if (count == 750) {
            doSpawn = true;
        }
    }
}
