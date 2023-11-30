using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTimer : MonoBehaviour
{

    public float rotTest= 10.0f;
    public GameObject sunLight;
    public GameObject playerRot;
    public bool rotateEnable = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //sunVRot = new Vector3((sunXRot), (sunYRot), (sunZRot));
        if (rotateEnable)
        {
            //sunLight.transform.Rotate((5*rotTest*Time.deltaTime),0,0);
        }
    }

    public void rotateSun(float sunSpeed)
    {
        sunLight.transform.Rotate((sunSpeed*10.0f*Time.deltaTime),0,0);
    }


}
