using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("123");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("123");
    }
}