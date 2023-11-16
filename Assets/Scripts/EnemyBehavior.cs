using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public float speed;
    public float visionRange = 50.0f;
    public float visionConeAngle = 90.0f;
    public bool alert;
    public Light myLight;
    Rigidbody enemyRigidBody;
    public LayerMask playerLayer;
    public Transform targetPosition;
    public NavMeshAgent agent;
    public bool enemyFire;
    public Animator enemyAnimator;

    GameObject playerEntity;
    RaycastHit hitData;
    RaycastHit[] rayHitArray;
    public Health Health;
    public bool Moving = true;
    public int walkInt = 0;
    public bool hurtBool = false;
    public bool dead = false;
    int deadint = 0;
    void Start()
    {
        alert = false;
        enemyRigidBody = GetComponent<Rigidbody>();
        playerEntity = GameObject.FindWithTag("Player");
        myLight = this.gameObject.transform.GetChild(2).GetComponent<Light>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()

    {
        if (playerEntity != null)
        {
            Vector3 playerPosition = playerEntity.transform.position;
            Vector3 vectorToPlayer = playerPosition - transform.position;
            myLight.color = Color.white;
            if (alert)
            {
                myLight.color = Color.red;
                if (Vector3.Distance(targetPosition.position, this.transform.position) <= 5.0f | !Moving)
                {
                    //Debug.Log("Too close, stop");

                    agent.isStopped = true;
                    enemyAnimator.SetBool("isMoving", false);
                
                }
                else if (Vector3.Distance(targetPosition.position, this.transform.position) >= 5.0f && Moving)
                {
                    agent.destination = playerEntity.transform.position;
                    agent.isStopped = false;
                    enemyAnimator.SetBool("isMoving", true);
                    
                    walkInt ++;
                }

            }
            else
            {
                if (Vector3.Distance(transform.position, playerPosition) <= visionRange)
                {
                    if (Mathf.Abs(Vector3.Angle(transform.forward, vectorToPlayer)) <= visionConeAngle)
                    {
                        //Debug.Log("Player in range");

                        rayHitArray = Physics.RaycastAll(transform.position + new Vector3(0, 1, 0), Vector3.Normalize(playerEntity.transform.position - transform.position)); //add 1 to y to shoot ray from midddle of enemy
                        RaycastHit hit = rayHitArray[0]; //get first raycast hit from multihit
                        GameObject multiHitObject = hit.transform.gameObject;


                        if (hit.transform.tag == "Player") // still bugged, fix the issue where it always reports player first, so it alerts enemys thru walls
                        {

                            Debug.DrawRay(transform.position + new Vector3(0, 1, 0), hit.transform.position - transform.position, Color.green, 1);
                            string testText = "";
                            for (int index = 0; index < rayHitArray.Length; index++) { testText += " , " + rayHitArray[index].transform.gameObject.name; }
                            alert = true;

                        }
                        else if (hit.transform.tag != "Player" || !alert)
                        {
                            alert = false;
                        }
                    }
                    else
                    {
                        alert = false;
                    }
                }
            }

        }
        if (enemyFire)
        {
            fireEvent();
        }
        if (walkInt == 300)
        {
            enemyAnimator.SetTrigger("Shoot");
            walkInt = 0;
        }
        if(hurtBool)
        {
            enemyAnimator.SetTrigger("OnHurt");
            hurtBool = false;
        }
        if(dead)
        {
            enemyAnimator.SetTrigger("OnDeath");
            agent.isStopped = true;
            
            deadint ++;
            if(deadint == 2000)
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void fireEvent()
    {
        if(!dead){// damage here
        enemyFire = false;
        rayHitArray = Physics.RaycastAll(transform.position + new Vector3(0, 1, 0), Vector3.Normalize(playerEntity.transform.position - transform.position)); //add 1 to y to shoot ray from midddle of enemy
        RaycastHit hit = rayHitArray[0]; //get first raycast hit from multihit
        GameObject multiHitObject = hit.transform.gameObject;
        if(rayHitArray[0].transform.tag == "Player" ) // put 1+1 != 2 in here to ignore for compilation reasons
        {
            Health.Damage(playerEntity, 20);
        } //check for player ray to enemy to see if it even can see the player
        }
        
    }
}