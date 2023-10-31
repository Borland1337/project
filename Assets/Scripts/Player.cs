using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, 1)][SerializeField] private float m_CrouchSpeed = .36f;           // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)][SerializeField] private float m_MovementSmoothing = .05f;   // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.                      // A position marking where to check for ceilings            // A collider that will be disabled when crouching
    public Transform GroundCheck;
    [SerializeField] private float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    [SerializeField] private bool Grounded;            // Whether or not the player is grounded.

    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    float curentspeed;
    public float groundint;
    public Animator Animator;


    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move(curentspeed, true);
            //StartCoroutine(PlayOnce("jump"));
        }
    }

    private IEnumerator PlayOnce(string animationName)
    {
        Animator.SetBool(animationName, true);
        yield return new WaitForSecondsRealtime(0.33f);
        Animator.SetBool(animationName, false);
    }

    private void FixedUpdate()
    {
        curentspeed = Input.GetAxis("Horizontal");
        Move(curentspeed, false);
        Vector3 down = transform.TransformDirection(Vector2.down);
        if (Physics2D.Raycast(GroundCheck.position, down, groundint))
        {
            Grounded = true;
            //Animator.SetBool("fall", false);
        }
        else
        {
            Grounded = false;
            //Animator.SetBool("run", false);
            //Animator.SetBool("fall", true);
        }
    }


    public void Move(float move, bool jump)
    {
        if (Grounded)
        {

            // If crouching
            // Enable the collider when not crouching

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            //if (m_Rigidbody2D.velocity != Vector2.zero)
            //{
            //    Animator.SetBool("run", true);
            //}
            //else
            //{
            //    Animator.SetBool("run", false);
            //}


        }
        // If the player should jump...
        if (Grounded && jump)
        {
            // Add a vertical force to the player.
            Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }


    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
