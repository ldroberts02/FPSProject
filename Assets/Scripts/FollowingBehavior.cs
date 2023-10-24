using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingBehavior : MonoBehaviour
{
    public float speed;
    public float visionRange;
    public float visionConeAngle;
    public bool alert;
    public Light myLight;
    Rigidbody enemyRigidBody;
    public LayerMask playerLayer;

    GameObject playerEntity;
    RaycastHit hitData;
    RaycastHit[] rayHitArray;
    // Start is called before the first frame update
    void Start()
    {
        alert = false;
        enemyRigidBody = GetComponent<Rigidbody>();
        playerEntity = GameObject.FindWithTag("Player");
        myLight = this.gameObject.transform.GetChild(2).GetComponent<Light>();
        //gameObject.transform.position = playerEntity.transform.position;
        //playerLayer = ~playerLayer;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerEntity != null)
        {
            Vector3 playerPosition = playerEntity.transform.position;
            Vector3 vectorToPlayer = playerPosition - transform.position;
            myLight.color = Color.white;
            if (alert)
            {
                //follow player
                //print("alert");
                myLight.color = Color.red;

            }
            else
            {
                if (Vector3.Distance(transform.position, playerPosition) <= visionRange)
                {
                    if(Vector3.Angle(transform.right, vectorToPlayer) <= visionConeAngle)
                    {
                        
                        rayHitArray = Physics.RaycastAll(transform.position + new Vector3(0,1,0), Vector3.Normalize(playerEntity.transform.position - transform.position)); //add 1 to y to shoot ray from midddle of enemy
                        RaycastHit hit = rayHitArray[0]; //get first raycast hit from multihit
                        GameObject multiHitObject = hit.transform.gameObject;

                        if (hit.transform.tag == "Player")
                        {
                            
                            //if(hit.transform.gameObject.layer == LayerMask.NameToLayer("examplelayername"))
                            //Debug.DrawRay(transform.position+ new Vector3(0,1,0), Vector3.Normalize(playerEntity.transform.position - transform.position)* 1000, Color.green);
                            Debug.DrawRay(transform.position+ new Vector3(0,1,0), hit.transform.position - transform.position, Color.green, 1);


                            string testText = "";
                            for (int index = 0; index < rayHitArray.Length; index++) {testText += " , " + rayHitArray[index].transform.gameObject.name;}
                            Debug.Log(testText);

                        }
                        else if (hit.transform.tag != "Player")
                        {
                            //Debug.DrawRay(transform.position+ new Vector3(0,1,0), hit.transform.position - transform.position, Color.red, 1);
                            //Debug.DrawRay(transform.position, Vector3.Normalize(playerEntity.transform.position - transform.position) * 1000, Color.red);
                            Debug.Log("Did not Hit");
                            //Debug.Log(multiHitObject.name);
                        }
                    }
                else
                {
                    alert = false;
                }
            }
        }
    }
}
}