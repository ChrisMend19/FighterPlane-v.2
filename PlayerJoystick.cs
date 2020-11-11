using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    //private Rigidbody2D characterBody;
    //public GameObject character;
    public float speed = 2.0f;
    private bool touchStart = false;
    private Vector2 pointA;
    private Vector2 pointB;
    public Transform circle;
    public Transform outerCircle;
    public GameObject bulletPrefab;
    void Start()
    {
        //characterBody = character.GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            //Debug.Log("shoot");
            shootBullet();
        }
        
        if(Input.GetMouseButtonDown(0)) {
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.transform.position.z));

            circle.transform.position = pointA * 1;
            outerCircle.transform.position = pointA * 1;
            circle.GetComponent<SpriteRenderer>().enabled = true;
            outerCircle.GetComponent<SpriteRenderer>().enabled = true;
        }
        if(Input.GetMouseButton(0)) {
            touchStart = true;
            pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else {
            touchStart = false;
            //characterBody.velocity = new Vector2(4, 0); //add colliders that move with moving camera
        }

        

    }

    private void FixedUpdate() {
        if(touchStart) {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            moveCharacter(direction * 1);
            

            circle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * 1;
        }
        
        else {
            circle.GetComponent<SpriteRenderer>().enabled = false;
            outerCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }

    void moveCharacter (Vector2 direction) {
        player.Translate(direction * speed * Time.deltaTime);
    }


    void shootBullet(){
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = player.transform.position;
    }
}
