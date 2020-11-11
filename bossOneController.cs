using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossOneController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;
    private Vector2 screenBounds;
    private distanceCounter counter;
    public int count;
    public bool bossHasSpawned = false;
    private joystickShoot playerControls; 
    void Start()
    {
        //Debug.Log("boss");
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        
        //Debug.Log(count);
        //GameObject a = Instantiate(myPrefab) as GameObject;
        //a.transform.position = new Vector2(screenBounds.x + 5, Random.Range(-screenBounds.y + 5 , screenBounds.y - 1.75f));
    }
    void Update() {
        count = distanceCounter.distance;
        if (count == 650 && !bossHasSpawned) { //650
            spawnBoss();
            bossHasSpawned = true;

        }
    }

    // Update is called once per frame
    void spawnBoss() {
        GameObject a = Instantiate(myPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x-4.5f, screenBounds.y-7);
    }

    public bool getBossSpawned(){
        return bossHasSpawned;
    }
}

