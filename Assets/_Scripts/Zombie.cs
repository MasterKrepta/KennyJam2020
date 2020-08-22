using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] GameObject parent;
    public Rigidbody[] bodies;
    public SphereCollider[] sphereColliders;
    // Start is called before the first frame update
    void Start()
    {
        bodies = parent.GetComponentsInChildren<Rigidbody>();
        sphereColliders = parent.GetComponentsInChildren<SphereCollider>();

        foreach (var rb in bodies)
        {
            rb.isKinematic = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
              foreach (var rb in bodies)
            {
                rb.isKinematic = false;
            }
        }
    }
}