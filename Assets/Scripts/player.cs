using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider m_CrouchDisableCollider;                // A collider that will be disabled when crouching

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody m_Rigidbody;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

    // Start is called before the first frame update
    public int playerSpeed;
    public int jumpSpeed;


    bool ifGround;
    Rigidbody thisRigid;
    void Start()
    {
        thisRigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    void playerMove()
    {
        float h = Input.GetAxis("Horizontal");
        flip(h);

        
    }

    bool isGround()
    {

        return false;
    }

    void flip(float h)
    {
        if (transform.localScale.y * h < 0)
        {
            transform.localScale.x *= -1; 
        }
    }

    void groundWake()
    {

    }

    private void FixedUpdate()
    {
        bool wasGround = ifGround;
        ifGround = false;
        Collider[] colliders = Physics.OverlapCapsule(m_GroundCheck.position,m_GroundCheck.position,k_GroundedRadius,m_WhatIsGround);
        for(int i = 0; i < colliders.Length; i++)
        {
            if(colliders[i]!=gameObject)
            {
                ifGround = true;
                if (!wasGround) groundWake();
            }
        }
    }

    void Update()
    {
        
    }
}
