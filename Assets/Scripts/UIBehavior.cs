using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UIBehavior : MonoBehaviour
{
    public GameObject playerObject;
    public Animator uiAnimator;
    public GameObject sunObject;
    public Toggle sunOverride; //this is using the UI toggle atm
    public Slider horizontalSlider;
    public Slider verticalSlider;
    public GameObject verticalSliderGameObject;
    public float sunSpeed = 0.0f;
    public float sunRot = 0.0f;
    public bool showDebugOptions;
    public GameObject debugUI;
    public TMP_Text healthText;
    
    void Start()
    {
        if (!showDebugOptions)
        {
            debugUI.SetActive(false);
            playerObject.GetComponent<FPSController>().canLook = true;
        }
        else if (showDebugOptions)
        {
            debugUI.SetActive(true);
            playerObject.GetComponent<FPSController>().canLook = false;
        }
    }


    void Update()
    {
        if(sunObject != null){
        sunSpeed = horizontalSlider.value * 10;

        if (sunOverride.GetComponent<Toggle>().isOn) //when toggle is true
        {
            verticalSliderGameObject.SetActive(true);
            sunObject.GetComponent<LightTimer>().rotateEnable = false;
            sunObject.GetComponent<LightTimer>().sunLight.transform.eulerAngles = new Vector3(
                                                                                                verticalSlider.value,   
                                                                                                sunObject.GetComponent<LightTimer>().sunLight.transform.eulerAngles.y,  
                                                                                                sunObject.GetComponent<LightTimer>().sunLight.transform.eulerAngles.z);
        }
        else if (!sunOverride.GetComponent<Toggle>().isOn) //when toggle is false
        {
            verticalSliderGameObject.SetActive(false);
            sunObject.GetComponent<LightTimer>().rotateEnable = true;
            sunObject.GetComponent<LightTimer>().rotateSun(sunSpeed);
        }
        }
        uiAnimator.SetFloat("PlayerSpeed", playerObject.GetComponent<FPSController>().velocity);

        healthText.text = ("Health: " + (playerObject.GetComponent<Health>().healthNum / 9));

    }

}
