using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetManager : MonoBehaviour
{
    [SerializeField]
    int hitPoint = 100;

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("MSG: Target Collision");
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("MSG: Target_HP is :" + hitPoint );
            hitPoint--;
        }
        if(hitPoint < 0)
        {
            Destroy(gameObject);
            Debug.Log("MSG: Target is Destroy");

            SceneManager.LoadScene(5);
        }
    }
}
