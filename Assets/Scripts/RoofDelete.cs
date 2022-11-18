using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofDelete : MonoBehaviour
{
    private MeshRenderer mrender;

    private void Awake()
    {
        mrender = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        mrender.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        mrender.enabled = true;
    }
}
