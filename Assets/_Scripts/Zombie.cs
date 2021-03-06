﻿using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] Transform player;
    Animator anim;
    AudioSource audio;
    Rigidbody[] bodies;
    public float stunTime = 5f;
    NavMeshAgent agent;
    bool stunned = false;
    [SerializeField]GameObject attackPoint;

    
    // Start is called before the first frame update
    void Start()
    {
        
        audio = GetComponent<AudioSource>();
        bodies = parent.GetComponentsInChildren<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        foreach (var rb in bodies)
        {
            rb.isKinematic = true;
        }
    }

    private void Update()
    {
        if (!stunned)
        {
            agent.SetDestination(player.position);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup")) 
        {
            attackPoint.SetActive(false);
            stunned = true;
            audio.Play();
            anim.enabled = false;
            other.GetComponent<Pickup>().Respawn();
            foreach (var rb in bodies)
            {
                rb.isKinematic = false;
                StartCoroutine(Stun());
            }
        }
    }

    IEnumerator Stun()
    {
        yield return new WaitForSeconds(stunTime);
        anim.enabled = true;
        foreach (var rb in bodies)
        {
            rb.isKinematic = false;
            
        }
        stunned = false;
        attackPoint.SetActive(true);
    }
}