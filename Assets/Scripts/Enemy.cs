using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    public int health = 100;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f)).normalized;
        //transform.Translate(randomDirection * speed * Time.deltaTime);
        rb.AddForce(randomDirection * moveSpeed * 10f, ForceMode.Force);
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
           Destroy(rb);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
    }
    
}

