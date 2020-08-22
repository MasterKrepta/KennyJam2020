using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Combat _combat;
    // Start is called before the first frame update
    void Start()
    {
        _combat = GameObject.FindGameObjectWithTag("Player").GetComponent<Combat>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Player"))
        {
            _combat.PickupItem(this.transform);
        }
    }


}
