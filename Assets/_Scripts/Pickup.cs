using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Combat _combat;
    Vector3 startingPoint;
    // Start is called before the first frame update
    void Start()
    {
        _combat = GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>();
        startingPoint = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {

        var parent = other.transform.parent;
        if (parent != null && parent.CompareTag("Player"))
        {
            _combat.PickupItem(this.transform);
        }
    }

    public void Respawn()
    {
        transform.position = startingPoint;
    }
}
