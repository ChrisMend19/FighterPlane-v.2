using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distanceCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public static int distance;
    private int distance2 = 0;
    private GameObject boss;
    private bool b; //todo:fix score pause w/ boss
    public Text score;
    private playerHealth ph;
    private bool crash;
    private manageGame mg;
    private bool restartstat;

    void Start(){

        distance = 0;
       
       //GameObject.Find("Bob").GetComponent<bobScript>().isCounting
    }

    public void setDistance(int dist){
        distance = dist;

    }



    // Update is called once per frame
    void Update()
    {
        //restartstat = GameObject.Find("manageGame").GetComponent<manageGame>().restartStats;
        crash = GameObject.Find("Plane").GetComponent<playerHealth>().crashPlaneBegin;
        boss = GameObject.Find("firstBoss(Clone)");
        //Debug.Log(restartstat);
        if(boss == GameObject.Find("Null")){
            distance2 ++;
            if(distance2 % 10 == 0 && !crash) {
                //Debug.Log(distance2);
                distance ++;
                score.text = distance.ToString();
            }
        }
    }
}
