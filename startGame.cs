using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    // Start is called before the first frame update
    //public int speed = 8;
    public Rigidbody2D rigidBody;
    //private distanceCounter counter;
    //private int count;
    //private Vector2 screenBounds;
    void Start()
    {
       //Debug.Log("asdf"); 
       rigidBody = this.GetComponent<Rigidbody2D>();
       Debug.Log(rigidBody.position);
       //rigidBody.velocity = new Vector2( -speed,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rigidBody.position);
        
        
    }
    

    public void starting()
    {
         Debug.Log("MainMenu");
         //SceneManager.UnloadSceneAsync("Main Menu");
         SceneManager.LoadSceneAsync(1);
         Time.timeScale = 1;
        
    }
}
