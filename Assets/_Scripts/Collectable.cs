using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    public Vector3 dropPoint;
    public RawImage image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var parent = other.gameObject.transform.parent;
        if (parent != null && parent.CompareTag("Player"))
        {
            this.transform.parent = other.transform;
            this.transform.position = other.transform.position;
            
            this.GetComponent<Rigidbody>().isKinematic = true;
            var particle = this.transform.GetChild(0);
            particle.gameObject.SetActive(false);
        }
    }

    public void PlaceCollectable()
    {
        print(this.name);
        transform.position = dropPoint;
        Destroy(image.gameObject);
    }
}
