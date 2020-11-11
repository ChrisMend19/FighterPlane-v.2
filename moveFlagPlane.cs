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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count = distanceCounter.distance;
        //Debug.Log(count);
        if (count == 500) {
        rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2( speed,0);
        }
    }
}
