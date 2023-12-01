using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] public float moveSpeed;
    [SerializeField] Transform orientation;

    [Header("Boost")] // TODO enable boost via UI
    [SerializeField] float boostSpeed;
    [SerializeField] float boostLength;
    [SerializeField] float boostCooldown;
    [SerializeField] Camera cam;
    [SerializeField] public KeyCode boostKey = KeyCode.E;

    public bool boost = false;
    private float oldSpeed;
    private float oldFOV;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;
    
    private float health = 100;

    private Rigidbody rb;

    private void Start()
    {
       rb = GetComponent<Rigidbody>();
       rb.freezeRotation = true;
       rb.useGravity = false;

    }

    private void Update()
    {
        if(boost &&  Input.GetKeyDown(boostKey))
        {
            StartCoroutine(Boost());
        }

        MyInput();
        SpeedControl();
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
        oldSpeed = moveSpeed;
        oldFOV = cam.fieldOfView;
        moveSpeed = boostSpeed;
        cam.fieldOfView = oldFOV * 2;
        yield return new WaitForSeconds(boostLength);
        moveSpeed = oldSpeed;
        cam.fieldOfView = oldFOV;
        yield return new WaitForSeconds(boostCooldown);
        boost = true;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
           Destroy(gameObject);
        }
    }
}