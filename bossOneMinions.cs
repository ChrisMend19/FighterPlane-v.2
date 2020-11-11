using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossOneMinions : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed = 10f;
    private distanceCounter distanceCounter;
    private int count;
    public GameObject myPrefab;
    private Vector2 screenBounds;
    void Start()
    {
        rb =  this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed,0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenBounds.x * 10) {
            //Debug.Log("asdf");
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "playerPlane") {

            Destroy(this.gameObject);
            GameObject e = Instantiate(myPrefab) as GameObject;
            e.transform.position = transform.position;
            Destroy(e, .35f);
        }
    }
}
