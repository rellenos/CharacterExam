using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 7;
    public float rotationSpeed = 250;
    public float jumpHeight = 3f;
    private float x, y;

    //public CharacterController player;
    public Animator animator;
    public Rigidbody rb;

    public bool canJump;
    
    /*void Start()
    {
        player = GetComponent<CharacterController>();
    }*/

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        /*if ( x>0 || x<0 || y>0 || y<0 )
        {
            animator.SetBool("Other", true);
        }*/

        if (canJump)
        {
            if (Input.GetKey("space"))
            {
                animator.SetBool("jumping", true);
                rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            }
            animator.SetBool("inGround", true);
        }
        else
        {
            IsFalling();
        }

    }

    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * runSpeed);
    }

    public void IsFalling()
    {
        animator.SetBool("jumping", false);
        animator.SetBool("inGround", false);
    }

}
