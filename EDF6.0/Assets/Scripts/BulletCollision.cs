using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("MSG: Bullet Collision" + col);
        if (col.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
