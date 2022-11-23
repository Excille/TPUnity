using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packet : MonoBehaviour
{
    [SerializeField] private GameObject boomEffect;

    public void Force(float force)
    {
        if(TryGetComponent(out Rigidbody rb))
        {
            rb.AddForce(transform.forward * force, ForceMode.Impulse);
            rb.maxAngularVelocity = 10;
            rb.AddTorque(Random.insideUnitSphere);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out Pnj pnj))
        {
            pnj.Stunned(5);
            Instantiate(boomEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
