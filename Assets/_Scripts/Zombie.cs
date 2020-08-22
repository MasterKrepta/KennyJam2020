using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField] GameObject parent;
    [SerializeField] Transform player;
    Animator anim;
    
    Rigidbody[] bodies;
    public float stunTime = 5f;
    NavMeshAgent agent;
    bool stunned = false;

    
    // Start is called before the first frame update
    void Start()
    {
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
        if (other.CompareTag("Pickup")) //! this allows them to trip over pumpkins
        {
            stunned = true;
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
    }
}