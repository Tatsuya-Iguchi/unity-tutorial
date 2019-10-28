using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtNorth : MonoBehaviour
{
    public GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        arrow.transform.localEulerAngles = Vector3.up * -Input.compass.trueHeading;
    }
}
