using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alter : MonoBehaviour
{
    public int items = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            items++;
            CheckVictory();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.tag = "Untagged";
            var col = other.GetComponent<Collectable>();
            col.PlaceCollectable();
            items++;
            other.gameObject.transform.parent = this.transform;
            CheckVictory();

        }
    }

    private void CheckVictory()
    {
        if (items == 3)
        {
            GameObject.FindObjectOfType<AudioManager>().GameOver(); // this should always just work
        }
    }
}
