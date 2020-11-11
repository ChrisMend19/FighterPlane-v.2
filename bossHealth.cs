using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private distanceCounter distance;
    bossOneBehavior boss;
    private bool bossOneOn;
    public GameObject myPrefab;
    //public float health = 100;//
    void Start()
    {
        //rb.this.GetComponent<Rigidbody2D>();
        rb = this.GetComponent<Rigidbody2D>();
        //bossOneOn = boss.bossOneOn;
        
        
    }
    void spawnBossHealth() {
        GameObject a = Instantiate(myPrefab) as GameObject;
        a.transform.position = transform.position;
        //a.transform.position = new Vector2(screenBounds.x-4.5f, screenBounds.y-7);
    }

    // Update is called once per frame
    
}
