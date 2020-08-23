using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] Transform[] RespawnPoints;
    Transform closestRespawn;
    Transform player;
    Vector3 zombieSpawnpoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        zombieSpawnpoint = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        var parent = other.gameObject.transform.parent;
        if (parent != null && parent.CompareTag("Player"))
        {
            this.transform.parent.position = zombieSpawnpoint;
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
        closestRespawn = RespawnPoints[0];
        var shortest = Vector3.Distance(player.position, closestRespawn.position);
        foreach (var t in RespawnPoints)
        {
            var curr = Vector3.Distance(player.position, t.position);
            if (curr < shortest)
            {
                curr = shortest;
                closestRespawn = t;
            }
        }

        player.position = closestRespawn.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            RespawnPlayer();
        }
        
    }
}
