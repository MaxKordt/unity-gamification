using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI = UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    private UI.Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Increase(float increment) {

        slider.value += increment;
    }

    public void Decrease(float decrease) {

        slider.value -= decrease;
    }
}
