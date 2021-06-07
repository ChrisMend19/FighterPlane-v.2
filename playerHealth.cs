using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public static int health;
    public GameObject hitMarker;
    public bool crashPlane = false;
    public bool crashPlaneBegin = false;
    private bool shieldOn = false;
    SpriteRenderer sprite;
    float scale = 0.01f;
    int crashTime = 0;
    public Transform player;
    public GameObject playerObject;
    //public planeEnemyBomb explosionPlane;
    float timer = 0.0f;
    private int seconds;
 
    void Start(){
        Time.timeScale = 0;
        sprite = GetComponent<SpriteRenderer>();
        health = 3;
    }

   
    void Update()
    {
        //Debug.Log(health);
        if(shieldOn){
            timer += Time.deltaTime;
            if(health >= 1)
            sprite.color = new Color (.65f, .65f, .65f, .65f); 
            // work on opacity on and off
            //Debug.Log(seconds);
        }
        int seconds = (int)timer % 60;
        if(seconds == 2){
            //Debug.Log("shield off");
            shieldOn = false;
            timer = 0.0f;
            sprite.color = new Color (1, 1, 1, 1); 
        }
        if(health == 0){
            crashTime ++;
            
            crashPlaneBegin = true;
            if(player.position.y < -4.4f && !crashPlane){
                crashPlane = true;
                
                sprite.color = new Color (1, 1, 1, 0); 
                player.Translate(new Vector3(-0.1f,0.0f, 0.0f));
                GameObject e = Instantiate(hitMarker) as GameObject;
                e.transform.position = transform.position;
                Destroy(e, 1f); 
                
            }
            if(crashTime < 100)
            player.Translate(new Vector3(0.02f,-0.01f, 0.0f));
            if(crashTime > 100 && crashTime <= 140)
            player.Translate(new Vector3(0.0175f,-0.0125f, 0.0f));
            if(crashTime > 140 && crashTime <= 160)
            player.Translate(new Vector3(0.0175f,-0.0165f, 0.0f));
            if(crashTime > 160 && player.position.y > -4.4f) // todo: get plane 2 crash end game
            player.Translate(new Vector3(0.0175f,-0.0185f, 0.0f));//GameObject e = Instantiate(hitMarker) as GameObject;
            
        }
    }


        void crashPlaneAnim(){
            Vector3 planepos = new Vector3(player.position.x,player.position.y,player.position.z);
            //Debug.Log(planepos);
            player.Translate(new Vector3(0.02f,-0.01f, 0.0f));
        }
        // if(hitMarkerBool){ //fix the end animation
        //     while(scale < 16f){
        //         GameObject e = Instantiate(hitMarker) as GameObject;
        //         e.transform.position = transform.position;
        //         scale += 0.009f;
        //         e.transform.localScale = new Vector2(scale, scale);
        //         if (scale >= 0.05f){
        //             Destroy(e,.1f);
        //         }
        //         // if (scale >= .5f){
        //         //     Destroy(e);
        //         // } 
        //     }
            
        // }
        
        //Debug.Log(shieldOn);
        
    

    private void OnTriggerEnter2D(Collider2D other) {

        if(!shieldOn){
            //Debug.Log("shield on");
            
            if(other.tag == "planeEnemy" && health > 0 || other.tag == "pufferfish" &&  health > 0) { //|| other.tag == "bossOne"
                health--;
                shieldOn = true;
                //Debug.Log(health);
                Destroy(other.gameObject);
            }
            if(other.tag == "planeFlag" && health > 0) {
                health--;
                shieldOn = true;
                GameObject e = Instantiate(hitMarker) as GameObject;
                e.transform.position = transform.position;
                Destroy(e, .35f);
            }
        }
    }

    public bool getCrashPlane(){
        return crashPlane;
    }

    
}
