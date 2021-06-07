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
    private bool crash;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));  
    }
    void Update() {
        // removes boss spawn
        // crash = GameObject.Find("Plane").GetComponent<playerHealth>().crashPlaneBegin;
        // count = distanceCounter.distance;
        // if (count == 1000 && !bossHasSpawned && !crash) { //650
        //     spawnBoss();
        //     bossHasSpawned = true;

        // }
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

