﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMover : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 5;
    private Rigidbody2D rigidBody;
    private Vector2 screenBounds;
    public SpriteRenderer background;
    private float xpos;
    void Start()
    {
        
        rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(-speed,0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        xpos = rigidBody.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("T: "+transform.position.x);
        //Debug.Log("B: "+-background.bounds.size.x);
        if (transform.position.x < -background.bounds.size.x*1.25f) {
            rigidBody.transform.position = new Vector2(background.bounds.size.x - 37f,3.45f);
            //Debug.Log(screenBounds.x);
        }
    }
}
