// ==============================================================
//   Created by (huangcs) at #CREATETIME#.
//   Descirbe: 
// ==============================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " -OnCollisionEnter- " + collision.gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.name + " -OnTriggerEnter- " + other.gameObject.name);
    }

}
