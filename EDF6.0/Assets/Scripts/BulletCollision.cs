using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("MSG: Bullet Collision");
        if (col.gameObject.tag == "Target")
        {
            Destroy(gameObject);
            Debug.Log("MSG: Bullet is Destroy");
        }
    }
}
