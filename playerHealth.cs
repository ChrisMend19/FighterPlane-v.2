using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public static int health =9999;
    public GameObject hitMarker;
    //public planeEnemyBomb explosionPlane;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "planeEnemy" || other.tag == "pufferfish" || other.tag == "bossOne" ) {
            health--;
            Destroy(other.gameObject);
        }
        if(other.tag == "planeFlag") {
            health--;
            GameObject e = Instantiate(hitMarker) as GameObject;
            e.transform.position = transform.position;
            Destroy(e, .35f);
        }
    }
}
