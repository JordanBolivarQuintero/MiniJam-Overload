using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();  
    }

    private void OnTriggerEnter(Collider other)
    {
        Reset_();
    }

    public void Reset_()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.transform.position = gameObject.transform.parent.position;
        rb.velocity = rb.velocity * 0;        
    }
    public void Shoot_(Transform pos, Transform rot)
    {   
        transform.position = pos.position;
        transform.rotation = rot.rotation;
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);
        gameObject.GetComponent<Renderer>().enabled = true;
        Invoke("Reset_", 3);
    }
}
