using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody rb;

    [SerializeField] float idleMoveSpeed=1;

    private bool didHit = false;
    private Vector3 rotationAxis = Vector3.up;
    private Vector3 collisionVelocity;
    
    [SerializeField] private float forceMultiplier = 10;

    // Start is called before the first frame update
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log(didHit);
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
}
