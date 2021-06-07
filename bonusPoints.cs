using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class bonusPoints : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    private playerBlast pb;
    private bool blastHit;
    void Start()
    {
        text.gameObject.SetActive(false); // need to work on triggering on and off this text for bonus points
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //blastHit = playerBlast.blastHitmarker;
        //Debug.Log(blastHit);
        
        
    }
}
