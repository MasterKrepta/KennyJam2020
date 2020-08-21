using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float JumpForce = 2f;
    [SerializeField] float rotSpeed = 10f;
    Rigidbody rb;
    Animator anim;
    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        movement = new Vector3(h, 0, v);

        HandleRotation();

        rb.velocity = new Vector3(h * moveSpeed, rb.velocity.y, v * moveSpeed);
        transform.LookAt(transform.position + movement);

        anim.SetBool("Moving", SetMovementAnim());

        ManageJump();
    }

    private void HandleRotation()
    {
        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(movement),
                Time.deltaTime * rotSpeed
            );
        }
    }

    private void ManageJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity += new Vector3(rb.velocity.x, JumpForce, rb.velocity.z);
            anim.SetTrigger("Jump");
        }
    }

    bool SetMovementAnim()
    {
        
        if (rb.velocity != Vector3.zero)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}