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

    Collider handsCol;
    // Start is called before the first frame update
    void Start()
    {
        //hands.rotation = Quaternion.Euler(pickupAngle, 0, 0);
        handsCol = hands.GetComponent<Collider>();
        handsCol.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (hasItem == false)
            {
                handsCol.enabled = true;
                //hands.rotation = Quaternion.Euler(pickupAngle, 0, 0);
                StartCoroutine(TogglePickup());
                //PickupItem();
            }
            else
            {
                //hands.rotation = Quaternion.Euler(throwAngle, 0, 0);
                ThrowItem(itemInHand);
            }
        }
    }

    private void ThrowItem(Transform itemInHand)
    {
        itemInHand.parent = null;
        Rigidbody rb = itemInHand.transform.GetComponent<Rigidbody>();
        hasItem = false;
        handsCol.enabled = false;
        rb.isKinematic = false;
        rb.AddForce(hands.forward * throwForce, ForceMode.Impulse);
        itemInHand.transform.GetComponent<Collider>().enabled = true;
        itemInHand.transform.localScale = Vector3.one;
        
    }

    public void PickupItem(Transform item)
    {
        Debug.Log(item.name);
        hasItem = true;
        item.transform.GetComponent<Rigidbody>().isKinematic = true;
        item.transform.GetComponent<Collider>().enabled = false;
        item.transform.localScale = Vector3.one * scale;
        item.transform.parent = hands;
        item.transform.position = hands.position;
        itemInHand = item.transform;
    }


    IEnumerator TogglePickup()
    {
        yield return new WaitForSeconds(.25f);
        if (hasItem == false)
        {
            handsCol.enabled = false;
        }
        
    }
}