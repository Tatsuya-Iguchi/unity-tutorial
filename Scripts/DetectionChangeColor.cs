using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionChangeColor : MonoBehaviour
{
    protected string csName = "DetectionChangeColor";
    void OnCollisionEnter(Collision col)
    {
        Debug.Log(csName + ": " + col.gameObject.tag);
        if (col.gameObject.tag == "CheckPoint")
        {
            col.gameObject.GetComponent<Renderer>().material.color = Color.green;
            Debug.Log(csName + ": " + "CheckPoint hit");
        }
        else
        {
            Debug.Log(csName + ": " + col.gameObject.name);
        }
    }
    void OnCollisionStay(Collision col)
    {
        Debug.Log(csName + ": " + col.gameObject.tag);
        if (col.gameObject.tag == "CheckPoint")
        {
            col.gameObject.GetComponent<Renderer>().material.color = Color.green;
            Debug.Log(csName + ": " + "CheckPoint hit");
        }
    }
}
