using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossOneShootSpikeBall : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float speed = 8f;
    private Vector2 screenBounds;
    public GameObject myPrefab;
    
    void Start()
    {
        rb =  this.GetComponent<Rigidbody2D>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.transform.position.z));
        rb.velocity = new Vector2(-speed,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -screenBounds.x * 5) {
            //Debug.Log("asdf");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "playerPlane") {
            Destroy(this.gameObject);
            GameObject e = Instantiate(myPrefab) as GameObject;
            e.transform.position = transform.position;
            Destroy(e, .35f);
        }
    }
}
