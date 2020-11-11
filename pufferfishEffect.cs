using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pufferfishEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidBody;
    //public Transform player;
    private static int health;
    private planeEnemyBomb explosionPlane;
    public GameObject myPrefab;
    

    
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.tag == "playerPlane") {
            Destroy(this.gameObject);
            health = playerHealth.health;
            health --;
            //explosionPlane.explosionPlane();
            GameObject e = Instantiate(myPrefab) as GameObject;
            e.transform.position = transform.position;
            Destroy(e, .35f);
            //Debug.Log("hiut");
        }
        
    }

    
}
