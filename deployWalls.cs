using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployWalls : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myPrefab;
    public float respawnTime = 1.0f;
    
    private Vector2 screenBounds;
    //copy this  code for pufferfish and change random spawn range

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        StartCoroutine(rocketWave());
    }

    private void spawnEnemy() {
        GameObject a = Instantiate(myPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x + 5, Random.Range(-screenBounds.y + 5 , screenBounds.y - 1.75f)); //fix this bounds so bombs deploy over water
        
    }

    IEnumerator rocketWave() {
        while (true) {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
            //Debug.Log(screenBounds);
        }
    }
}
