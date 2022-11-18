using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    Plane playerPlane;
    Ray ray;
    float hitDist;
    Vector3 targetPoint;
    Quaternion targetRotation;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        /*playerPlane = new Plane(Vector3.up, transform.position);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        hitDist = 0;

        if (playerPlane.Raycast(ray, out hitDist))
        {
            targetPoint = ray.GetPoint(hitDist);
            targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            targetRotation = Quaternion.Slerp(transform.rotation, targetRotation, 7 * Time.deltaTime);
            //targetRotation.x = 0;  
            //targetRotation.z = 0;
        }*/
        RotateFromMouseVector();
    }
    void RotateFromMouseVector()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }
}
