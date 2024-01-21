using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ewe : EntityBase
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;
    public override void Move()
    {
        // Generate random direction vector
        Vector3 randomDirection = Quaternion.Euler(0f, Random.Range(0f, 60f), 0f) * Vector3.forward;

        // Calculate rotation towards the new direction
        Quaternion targetRotation = Quaternion.LookRotation(randomDirection);

        // Smoothly rotate towards the target rotation
        rb.rotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move in the forward direction using rigidbody velocity
        rb.velocity = rb.rotation * Vector3.forward * moveSpeed;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
