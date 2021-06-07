using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer background;
    // void Start()
    // {
    //     Debug.Log("cameraScript");
    //     float screenRatio = (float)Screen.width / (float)Screen.height;
    //     float targetRatio = background.bounds.size.x / background.bounds.size.y;

    //     if(screenRatio >= targetRatio){
    //         Debug.Log("1");
    //         Camera.main.orthographicSize = background.bounds.size.x / 2;
    //     }
    //     else{
    //         Debug.Log("2");
    //         float differenceInSize = targetRatio / screenRatio;
    //         Debug.Log(differenceInSize);
    //         Camera.main.orthographicSize = background.bounds.size.x / 2 * differenceInSize;
    //     }
        
    // }
    void Start () 
{
    
	// set the desired aspect ratio, I set it to fit every screen 
    // public SpriteRenderer background;
    Debug.Log("letgo");
	float targetaspect = (float)Screen.width / (float)Screen.height;
	
	// determine the game window's current aspect ratio
	float windowaspect = background.bounds.size.x / background.bounds.size.y;
	
	// current viewport height should be scaled by this amount
	float scaleheight = targetaspect / windowaspect;
	
	// obtain camera component so we can modify its viewport
	Camera camera = GetComponent<Camera>();
	
	// if scaled height is less than current height, add letterbox
	if (scaleheight < 1.0f)
	{  
        Debug.Log(scaleheight);
		Rect rect = camera.rect;
		
		rect.width = 1.0f;
		rect.height = scaleheight;
		rect.x = 0;
		rect.y = (1.0f - scaleheight) / 2.0f;
		
		camera.rect = rect;
	}
	else // add container box
	{
        Debug.Log("a");
		float scalewidth = 1.0f / scaleheight;
		
		Rect rect = camera.rect;
		
		rect.width = scalewidth;
		rect.height = 1.0f;
		rect.x = (1.0f - scalewidth) / 2.0f;
		rect.y = 0;
		
		camera.rect = rect;
	}
    
}
}
