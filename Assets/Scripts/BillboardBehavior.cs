using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BillboardBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    Camera mainCamera;


    void Start()
    {
        //mainCamera = GameObject.FindWithTag("Camera").GetComponent<Camera>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
    Vector3 newRotation = mainCamera.transform.eulerAngles;
    newRotation.x = 0;
    newRotation.z = 0;
    transform.eulerAngles = newRotation;
    transform.Rotate(0, 90, 0);
    }
}
