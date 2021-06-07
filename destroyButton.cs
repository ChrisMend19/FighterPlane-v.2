using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyButton : MonoBehaviour
{
    // Start is called before the first frame update
        [SerializeField]
        GameObject objectToDestroy;


    public void DestroyGameObject(){
        Destroy(objectToDestroy);
    }
}
