using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distanceCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public static int distance = 0;
    private int distance2 = 0;

    public Text score;

    // Update is called once per frame
    void Update()
    {
        
        distance2 ++;
        if(distance2 % 10 == 0) {
            //Debug.Log(distance2);
            distance ++;
            score.text = distance.ToString();
        }
    }
}
