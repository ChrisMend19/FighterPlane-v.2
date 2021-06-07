using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burstPixelShot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject centerPixel;
    public GameObject topPixel;
    public GameObject bottomPixel;
    private Rigidbody2D rigidBody1;
    private Rigidbody2D rigidBody2;
    private Rigidbody2D rigidBody3;
    public int speed = 5;
    void Start()
    {
        //rb = this.GetComponent<Rigidbody2D>();
        rigidBody1 = centerPixel.GetComponent<Rigidbody2D>();
        rigidBody2 = topPixel.GetComponent<Rigidbody2D>();
        rigidBody3 = bottomPixel.GetComponent<Rigidbody2D>();
        rigidBody1.velocity = new Vector2(speed,0);
        rigidBody2.velocity = new Vector2(speed,11);
        rigidBody3.velocity = new Vector2(speed,-11);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
