using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBehavior : MonoBehaviour
{
    public float speed;
    public float visionRange;
    public float visionConeAngle;
    public bool alert;
    Rigidbody enemyRigidBody;

    GameObject playerEntity;
    // Start is called before the first frame update
    void Start()
    {
        alert = false;
        enemyRigidBody = GetComponent<Rigidbody>();
        playerEntity = GameObject.FindWithTag("Player");
        //gameObject.transform.position = playerEntity.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerEntity != null)
        {
            Vector3 playerPosition = playerEntity.transform.position;
            Vector3 vectorToPlayer = playerPosition - transform.position;
            if (alert)
            {
                //follow player
                print("alert");
            }
            else
            {
                if (Vector3.Distance(transform.position, playerPosition) <= visionRange)
                {
                    if(Vector3.Angle(transform.forward, vectorToPlayer) <= visionConeAngle)
                    {
                        alert = true;
                    }
                }
            }
        }
    }
}
