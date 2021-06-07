using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 4;
    public Rigidbody2D rigidBody;
    public Rigidbody2D rigidBodyPlane;
    private Vector2 screenBounds;
    //public Text score;
    public Button button;
    GameObject btnGO;
    public SpriteRenderer background;

    //private distanceCounter d;
    //private int count;
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        //btnGO = GameObject.Find("button").GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidBody.position.x < screenBounds.x - 1000){
            starting();
        }
        // if(button_pressed){
        //     rigidBody = this.GetComponent<Rigidbody2D>();
        //     rigidBody.velocity = new Vector2( -speed,0);
        // }
        
    }

    public void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(-speed,0);
        rigidBodyPlane.velocity = new Vector2(speed/2,0);
        
        //GameObject btn2 = button.GetComponent<Button>();
        //btnObject.SetActive(false);
        
    }
    public void starting()
    {
         Debug.Log("MainMenu");
         //SceneManager.UnloadSceneAsync("Main Menu");
         SceneManager.LoadSceneAsync(1);
         Time.timeScale = 1;
        
    }
}
