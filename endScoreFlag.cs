using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endScoreFlag : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 4;
    private Rigidbody2D rigidBody;
    private Vector2 screenBounds;
    private playerHealth playerHealth;
    private bool crash;
    public Text score;
    public Button button;
    private distanceCounter d;
    private int count;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        score.fontSize = 32;

    }

    // Update is called once per frame
    void Update()
    {
        crash = GameObject.Find("Plane").GetComponent<playerHealth>().crashPlaneBegin; 
        // when the plane loses health removes controls and shows score
        if (crash) { 
            count = distanceCounter.distance;
            //Debug.Log(count.ToString());
            score.fontSize = 20;
            score.text = "score:  " + count.ToString();
            rigidBody = this.GetComponent<Rigidbody2D>();
            rigidBody.velocity = new Vector2( -speed,0);
            Vector2 scorePos = new Vector2(rigidBody.position.x + 6, rigidBody.position.y + 1.5f);
            Vector2 buttonPos = new Vector2(rigidBody.position.x + 6.2f, rigidBody.position.y - 1f);
            //fix text not showing up and plane not going  invisible
            score.transform.position = scorePos;
            button.transform.position = buttonPos;
            if(rigidBody.position.x < -screenBounds.x * 2 + 2){
                rigidBody.velocity = new Vector2( 0,0);
            }
        }        
    }
}

