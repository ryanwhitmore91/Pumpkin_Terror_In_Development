using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float speed;
    public float maxDashTime = 1.0f;
    public float dashSpeed = 0.99f;
    public float dashStoppingSpeed = 0.1f;
    public float dashTimer = 0.0f;

    Rigidbody rb;

    bool hasDashed = false;

    private float currentDashTime;

    float gypsySpeed = 0;

    //Assigns player number -> change in inspector when a new character is created
    public int player = 0;    
    
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        currentDashTime = maxDashTime;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // if (hasDashed == false)
        // {
        //     if (controller.state[player].Buttons.A > 0 && controller.prevState[player].Buttons.A == 0)
        //     {                
        //         currentDashTime = 0.0f;
        //         hasDashed = true;
        //     }
        // }
        //
        // if (currentDashTime < maxDashTime)
        // {
        //     speed = 5.0f;
        //     currentDashTime += dashStoppingSpeed;
        // }
        //
        // if(hasDashed == true)
        // {
        //     dashTimer += Time.deltaTime;
        //     if(dashTimer >= 5)
        //     {
        //         dashTimer = 0.0f;
        //         hasDashed = false;
        //         currentDashTime = 0.0f;
        //     }            
        // }
        //
        // else
        // {
        //     speed = dashSpeed;
        // }

        if (Time.timeScale > 0)
        {
            speed = 5.0f;


            anim.SetFloat("Speed", Mathf.Abs(gypsySpeed));

            ///Player Rotation
            Vector3 lookDirection = new Vector3(controller.state[player].ThumbSticks.Left.X, 0, controller.state[player].ThumbSticks.Left.Y).normalized;
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10);

            if (controller.state[player].ThumbSticks.Left.X != 0 || controller.state[player].ThumbSticks.Left.Y != 0)
            {
                transform.position += transform.forward / speed;
                gypsySpeed = 1;
            }

            else
            {
                gypsySpeed = 0;
                rb.velocity = Vector3.zero;
            }
        }
        
        else
        {
            speed = 0.00000000000000000000000000000000000000000000000001f;
        }  
    }
}