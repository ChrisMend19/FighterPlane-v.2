using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manageGame : MonoBehaviour
{
    // Start is called before the first frame update
    private static int health;
    private distanceCounter d;
    public bool restartStats = false;
    private int da;

    void Start()
    {
        Debug.Log("manageGame");
        //SceneManager.LoadScene ("Main Menu");
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync(1);
        //SceneManager.LoadScene ("Main Menu");
        
    }

    public void endGame()
    {
        //playerHealth.health = 3;
        //restartStats = true;
        //d.setDistance(0); // figure out how to restart distance
        //d = GameObject.Find("manageGame").GetComponent<distanceCounter>();
        //d.setDistance(0);
        //da = 0;
        //health = 3;
        SceneManager.LoadSceneAsync(1);
        
    }

    void restart2() {
        health = playerHealth.health;
        health = 3;
        //Debug.Log(health);
        SceneManager.LoadScene(1); 
    }
    
}
