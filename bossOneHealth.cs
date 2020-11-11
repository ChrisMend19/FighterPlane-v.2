using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bossOneHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    //public GameObject bosssHealthBar;
    public bossOneBehavior boss;
    private bool bossActive;
    //public GameObject myPrefab;
    
    
    //bossOneBehavior boss;
    void spawnBossHealthBar() {
        //GameObject a = Instantiate(bosssHealth) as GameObject;
        //GameObject d = Instantiate(bosssHealthBar) as GameObject;
        //d.transform.SetParent(GameObject.FindGameObjectWithTag("canvas").transform,false);
        //Debug.Log("asd");
        //a.transform.position = transform.position;
        //a.transform.position = new Vector2(screenBounds.x-4.5f, screenBounds.y-7);
    }
    public void setMaxHealth(float charge) {
        slider.value = charge;
        slider.maxValue = charge;
    }
    
    public void setHealth(float charge) {
        slider.value = charge;
        

    
    }

    public float getHealth() {
        return slider.value;
    }

    void Start(){
        bossActive = boss.bossOneOn;
        setMaxHealth(100);
        setHealth(0);
        //spawnBossHealthBar();
    }
    void Update() {
        
        /*
        bossActive = boss.bossOneOn;
        Debug.Log(bossActive);
        if (bossActive) {
            Debug.Log("now");
            GameObject e = Instantiate(myPrefab) as GameObject;
            setHealth(100);
        }
        else if(!bossActive){
            setHealth(0);
            bossActive = boss.bossOneOn;
        }
        */
        
    }
}
