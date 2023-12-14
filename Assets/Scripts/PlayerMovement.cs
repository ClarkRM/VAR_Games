using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] public float moveSpeed = 10f;
    [SerializeField] Transform orientation;
    [SerializeField] Animator anim;

    [Header("Boost")] // TODO enable boost via UI
    [SerializeField] float boostSpeed = 15f;
    [SerializeField] float boostLength = 1f;
    [SerializeField] float boostCooldown = 3f;
    [SerializeField] Camera cam;
    [SerializeField] public KeyCode boostKey = KeyCode.E;

    private float slowSpeed = 2f;
    private float normalSpeed = 10f;
    private float enemySlowDown = 10.0f;

    public bool boost = false;
    public bool slow = false;
    private float oldSpeed;
    private float oldFOV;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;
    
    private float health = 1;

    private Rigidbody rb;

    private void Start()
    {
       rb = GetComponent<Rigidbody>();
       rb.freezeRotation = true;
       rb.useGravity = false;
    }

    private void Update()
    {
        if (boost)
        {
            oldSpeed = moveSpeed;
            MyInput();
            SpeedControl();
            if (Input.GetKeyDown(boostKey))
            {
                StartCoroutine(Boost());
            }
        }
        else
        {
            MyInput();
            SpeedControl();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        
        if(Input.GetKey(KeyCode.Space))
        {
            moveDirection += Vector3.up;
        }
        else if(Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection += Vector3.down;
        }

        moveDirection = moveDirection.normalized;
        moveDirection.y /= 3;

        rb.AddForce(moveDirection * moveSpeed * 10f, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    IEnumerator Boost()
    {
        boost = false;
        anim.SetBool("BoostActive", true);
        oldSpeed = moveSpeed;
        oldFOV = cam.fieldOfView;
        moveSpeed = boostSpeed;
        cam.fieldOfView = oldFOV * 2;
        yield return new WaitForSeconds(boostLength);
        anim.SetBool("BoostActive", false);
        moveSpeed = oldSpeed;
        cam.fieldOfView = oldFOV;
        yield return new WaitForSeconds(boostCooldown);
        boost = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player touched an enemy!");
            if (!slow) { StartCoroutine(Slow()); }
        }
    }
    IEnumerator Slow()
    {
        slow = true;
        // set movespeed to slowspeed
        moveSpeed = slowSpeed;
        // wait 10 seconds
        yield return new WaitForSeconds(10);
        // reset movespeed to normalspeed
        moveSpeed = normalSpeed;
        // wait
        yield return new WaitForSeconds(3);
        slow = false;
    }
}