using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossOneHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bossHealthBar;
    public bossOneController bossOne;
    public bossOneHealth bossOneH;
    private bool bossSpawned;
    public bool healthSpawned = false;

    void Start()
    {
        bossSpawned = bossOne.getBossSpawned();
    }

    // Update is called once per frame
    void Update()
    {
        bossSpawned = bossOne.getBossSpawned();
        spawnHealthBar();
        //Debug.Log(healthSpawned);
    }

    void spawnHealthBar() {
        if (bossSpawned && !healthSpawned) {
            healthSpawned = true;
            bossOneH.setHealth(100);
            Debug.Log(bossOneH.getHealth());
            Debug.Log("a");
            GameObject a = Instantiate(bossHealthBar) as GameObject; //fix it from spawning infinite HB
            
            
        }
    }
}
