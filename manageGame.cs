using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class manageGame : MonoBehaviour
{
    // Start is called before the first frame update
    private static int health;
    
    public void endGame()
    {
        Debug.Log("Game Over");
        restart();
        
    }

    void restart() {
        health = playerHealth.health;
        health = 3;
        Debug.Log(health);
        SceneManager.LoadScene("gameOver"); 
    }
    
}
