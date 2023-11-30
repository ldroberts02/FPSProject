using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    MeshRenderer spinnableModel;
    public float spinSpeed = 10.0f;
    void Start()
    {
        spinnableModel = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        spinnableModel.transform.Rotate((spinSpeed / 10.0f),0.0f,0.0f,Space.Self);
    }
}
