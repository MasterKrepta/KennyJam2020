using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] Transform hands;
    bool hasItem = false;
    Transform itemInHand;
    public float range = 1f;
    public float scale = 0.5f;
    public float throwForce = 5f;
    public float pickupAngle = 10;
    public float throwAngle = -30f;

    // Start is called before the first frame update
    void Start()
    {
        hands.rotation = Quaternion.Euler(pickupAngle, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (hasItem == false)
            {
                hands.rotation = Quaternion.Euler(pickupAngle, 0, 0);
                PickupItem();
            }
            else
            {
                hands.rotation = Quaternion.Euler(throwAngle, 0, 0);
                ThrowItem(itemInHand);
            }
        }
    }

    private void ThrowItem(Transform itemInHand)
    {
        itemInHand.parent = null;
        Rigidbody rb = itemInHand.transform.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddForce(hands.forward * throwForce, ForceMode.Impulse);
        itemInHand.transform.GetComponent<Collider>().enabled = true;
        itemInHand.transform.localScale = Vector3.one;
        hasItem = false;
    }

    private void PickupItem()
    {
        
        RaycastHit hit;
        
        if (Physics.Raycast(hands.position, hands.TransformDirection(Vector3.forward), out hit, range))
        {
            Debug.Log(hit.collider.name);
            hasItem = true;
            hit.transform.GetComponent<Rigidbody>().isKinematic = true;
            hit.transform.GetComponent<Collider>().enabled = false;
            hit.transform.localScale = Vector3.one * scale;
            hit.transform.parent = hands;
            hit.transform.position = hands.position;
            itemInHand = hit.transform;

        }
    }
}
