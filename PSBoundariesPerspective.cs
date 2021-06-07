using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSBoundariesPerspective : MonoBehaviour {
    //public Camera MainCamera; //be sure to assign this in the inspector to your main camera
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public SpriteRenderer background;

    // Use this for initialization
    void Start(){
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void LateUpdate(){
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, (float)background.bounds.size.x * -0.8f + objectWidth, (float)background.bounds.size.x * 0.2f - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, (float)background.bounds.size.y * -0.5f + (objectHeight * 2) + 1.1f, (float)background.bounds.size.y * 0.5f - objectHeight);
        transform.position = viewPos;
    }
}