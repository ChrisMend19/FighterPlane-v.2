using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveFlagPlane : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 8;
    private Rigidbody2D rigidBody;
    private distanceCounter counter;
    private int count;
    private Vector2 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));

    }

    // Update is called once per frame
    void Update()
    { 
        // commented out to remove boss indication flag
        count = distanceCounter.distance;
        //Debug.Log(count);
        // if (count == 800) {
        // rigidBody = this.GetComponent<Rigidbody2D>();
        // rigidBody.velocity = new Vector2(speed,0);
        // }
        // if(rigidBody.ToString() != null){
        //     if(rigidBody.position.x > screenBounds.x * 7){
        //         Destroy(this.gameObject);
                
        //     }
        // }
        
        
    }
}
