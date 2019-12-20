using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayManager : MonoBehaviour
{
    [SerializeField]
    float distance = 150.0f;
    [SerializeField]
    Text reticule = null;
    [SerializeField]
    Color origin = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    [SerializeField]
    Color within = new Color(1.0f, 0.0f, 0.0f, 1.0f);

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 350, Color.yellow);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, distance))
        {
            if ((hit.collider.tag.Equals("Target")))
            {
                Debug.Log("MSG: within color " + hit.collider.tag);
                reticule.color = within;
            }
        }
        else
        {
            Debug.Log("MSG: origin color");
            reticule.color = origin;
        }
    }
}
