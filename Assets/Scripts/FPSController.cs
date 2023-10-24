using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 22.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 90.0f;
    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public Animator uiAnimator;
    
    Vector3 previousPos;
    public float velocity;
    
    
    
    public bool canLook = false;
    public bool canLookVertical = false;
    [HideInInspector]
    public bool canMove = true;

    public bool fireBool = false;

    public LayerMask entityLayer;
    public LayerMask worldLayer;

    //starting here is new stuff
    public float maxSpeed = 10.0f;

    public float frictionAmount = 12.0f;

    public int maxAmmo;
    public int currentAmmo;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        if(!canLook && Input.GetButton("Look"))
        {
            canLook = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (canLook && !Input.GetButton("Look"))
        {
            canLook = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetButton("Fire"))
        {
            Ray ray = playerCamera.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0));
            Debug.DrawRay(ray.origin, ray.direction * 10,Color.red,1);
            
            
            //if(!fireBool && uiAnimator.GetFloat("FireFloat") == 1.0f){fireBool = true}
            
            if(!fireBool){fireBool = true;}
           
            //RaycastHit hitData;
            //Physics.Raycast(ray, out hitData);
            //Debug.Log(hitData);
            //if(Physics.Raycast(ray, 100, worldLayer))
            //{
           //     //Debug.Log("Hit World Layer");
           // }

            if(Physics.Raycast(ray, 10, entityLayer))
            {
                Debug.Log("Hit Entity Layer");   
            }
        }

        if(fireBool){uiAnimator.SetTrigger("Fire");fireBool = false;}
        fireBool = false;

        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : runningSpeed;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : runningSpeed;
        float movementDirectionY = moveDirection.y;
        moveDirection = Vector3.ClampMagnitude((((forward * curSpeedX) + (right * curSpeedY)) / frictionAmount), (maxSpeed / 10));
        

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (canLook)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (!canLook)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }


        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        

        velocity = ((transform.position - previousPos).magnitude) / Time.deltaTime;
        previousPos = transform.position;

        //print (velocity);

        characterController.Move((moveDirection * maxSpeed)* Time.deltaTime);
        


        //Debug.Log(Input.GetButton("Fire"));

        // Player and Camera rotation
        if (canMove && canLook)
        {
            if (canLookVertical)
            {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            }
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        if (Input.GetButton("Camera Reset"))
        {
            playerCamera.transform.localRotation = Quaternion.Euler(0,-90,0);
        }

        if(velocity > 1)
        {
            //set ui blending and stuff here
        }


    }
}