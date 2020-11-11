using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystickShoot : MonoBehaviour {
    public Transform player;
    public float speed = 15.0f;
    public GameObject bulletPrefab;

    public Transform circle;
    public Transform outerCircle;

    private Vector2 startingPoint;
    private int leftTouch = 99;
    private int shootTime = 50;
    private bool doShoot = true;

    //private playerShootGauge;
    public playerShootGauge shootGauge;
    public float playerYDirection;
    

    
    // Update is called once per frame
    void Update () { // touch joystick controls
        int i = 0;
        while(i < Input.touchCount){
            Touch t = Input.GetTouch(i);
            Vector2 touchPos = getTouchPosition(t.position); // * -1 for perspective cameras
            if(t.phase == TouchPhase.Began){
                if(t.position.x > Screen.width / 2){
                    if(doShoot){
                        doShoot = false;
                        shootBullet();
                        //lowerShootGauge();
                    }

                }else{
                    leftTouch = t.fingerId;
                    startingPoint = touchPos;
                }
            }else if(t.phase == TouchPhase.Moved && leftTouch == t.fingerId){
                Vector2 offset = touchPos - startingPoint;
                Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
                //playerYDirection = direction.y;
                //getPlayerYDirection();
                moveCharacter(direction);
                //Debug.Log(playerYDirection);

                circle.transform.position = new Vector2(outerCircle.transform.position.x + direction.x, outerCircle.transform.position.y + direction.y);

            }else if(t.phase == TouchPhase.Ended && leftTouch == t.fingerId){
                leftTouch = 99;
                circle.transform.position = new Vector2(outerCircle.transform.position.x, outerCircle.transform.position.y);
            }
            ++i;
            
        }
        if (!doShoot){ // lowers shoot stamina bar and refills it
            shootTime--;
            shootGauge.setHealth(shootGauge.getHealth() - 1f);
            Debug.Log(shootGauge.getHealth());
            if(shootTime == 0) {
                doShoot = true;
                shootTime = 50;
                shootGauge.setHealth(100);
            }
        }
        
        

    }
    Vector2 getTouchPosition(Vector2 touchPosition){
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z));
    }

    void moveCharacter(Vector2 direction){
        player.Translate(direction * speed * Time.deltaTime);
    }
    void shootBullet(){
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = player.transform.position;
    }
    
    public float getPlayerYDirection() {
        return playerYDirection;
    }
    

}