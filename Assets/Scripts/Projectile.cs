﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [HideInInspector] new public Rigidbody rigidbody;

    void Reset()
    {
        Debug.Log("Hello");
        rigidbody = GetComponent<Rigidbody>();
    }
}