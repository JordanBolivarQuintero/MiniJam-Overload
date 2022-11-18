using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacterController : MonoBehaviour
{
    //private new Rigidbody rigidbody;
    CharacterController controller;
    public float speed = 6f;
    float gravity = 6f;

    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(hor, 0f, ver).normalized;

        if (dir.magnitude > 0.01)
        {
            controller.Move(dir * speed * Time.deltaTime);
        }
    }
}
