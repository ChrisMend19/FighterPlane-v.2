using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerShootGauge : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
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

    void Start() {
        setMaxHealth(100);
    }
}
