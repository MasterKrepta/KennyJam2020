using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    float height;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        height = offset.y;
    }
    private void Update()
    {
        transform.position = (player.position + offset);
        transform.position = new Vector3(transform.position.x, height, transform.position.z); // Lock the height for jumping. 
    }
}

