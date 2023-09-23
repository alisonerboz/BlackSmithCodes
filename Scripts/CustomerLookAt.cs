using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerLookAt : MonoBehaviour
{
    
    [SerializeField] private MeshRenderer Customer;
    
    public Transform target;
    
    void FixedUpdate()
    {
        //Customer.transform.LookAt(target);
        

    }
}
