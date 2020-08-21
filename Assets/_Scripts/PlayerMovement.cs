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
    public bool _isGrounded = true;
    public LayerMask Ground;
    [SerializeField] Transform groundCheck;
    public float groundDistance = 0.02f;
    float h, v;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        groundDistance = GetComponentInChildren<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        movement = new Vector3(h, 0, v);
        ManageJump();
    }
    void FixedUpdate()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance);
        HandleRotation();

        rb.velocity = new Vector3(h * moveSpeed, rb.velocity.y, v * moveSpeed);
        transform.LookAt(transform.position + movement);

        anim.SetBool("Moving", SetMovementAnim());

        
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
        
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            //rb.velocity += new Vector3(rb.velocity.x, JumpForce, rb.velocity.z) * Time.deltaTime;
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
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