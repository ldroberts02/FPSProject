using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BillboardBehavior : MonoBehaviour
{
    // Start is called before the first frame update

    Camera mainCamera;
    MeshRenderer meshRenderer;
    public GameObject playerObject;


    void Start()
    {
        mainCamera = Camera.main;
        meshRenderer = this.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>();
        //playerObject = 
    }

    // Update is called once per frame
    void Update()
    {
    Vector3 newRotation = mainCamera.transform.eulerAngles;
    newRotation.x = 0;
    newRotation.z = 0;
    meshRenderer.transform.eulerAngles = newRotation;
    meshRenderer.transform.Rotate(90, 90, -90);
    //this.transform.eulerAngles = newRotation;
    //transform.LookAt(playerObject.transform);
    //this.transform.Rotate(0, -90, 0);
    }
}
