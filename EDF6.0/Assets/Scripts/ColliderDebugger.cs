using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDebugger : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("DebugMSG: " + col.gameObject.tag);
        Debug.Log("DebugMSG: " + col.gameObject.name);
    }
}
