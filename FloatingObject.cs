using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class FloatingObject : MonoBehaviour
{

    private Transform playerTransform;
    private Rigidbody rb;

    float idleMoveSpeed=1;

    private bool didHit = false;
    private Vector3 rotationAxis = Vector3.up;
    private Vector3 collisionVelocity;
    
    private float forceMultiplier = 1;

    private Vector3 endScale;

    // Start is called before the first frame update
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        endScale = transform.localScale;
        transform.localScale=new Vector3(0.1f,0.1f,0.1f);
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.localScale.x < endScale.x)
        {
            transform.localScale*=1.25f;
        }
        if (!didHit)
        {
            transform.RotateAround(playerTransform.position, rotationAxis, idleMoveSpeed * Time.deltaTime);
        }
    }
    private void CalculateCollisionForce()
    {
        Vector3 offsetFromCenter = transform.position - playerTransform.position;
        float radius = offsetFromCenter.magnitude;

        Vector3 travelDirection = Vector3.Cross(rotationAxis, offsetFromCenter).normalized;

        collisionVelocity = radius * idleMoveSpeed * Mathf.Deg2Rad * travelDirection;

        rb.velocity = collisionVelocity * forceMultiplier;

        didHit = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!didHit)
        {
            CalculateCollisionForce();
        }
    }
    public void SetIdleSpeed(float speed)
    {
        idleMoveSpeed = speed;
    }
    public void Dragged()
    {
        didHit = true;
    }

    public void SetCollisionForce(float force)
    {
        forceMultiplier = force;
    }
}
