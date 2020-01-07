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
        Debug.Log("MSG:RM: ");
        if (Physics.Raycast(ray, out hit, distance))
        {
            if ((hit.collider.tag.Equals("Target")))
            {
                Debug.Log("MSG:RM: within color " + hit.collider.tag);
                reticule.color = within;
            }
            Debug.Log("MSG:RM: ?????? " + hit.collider.name);
        }
        else
        {
            Debug.Log("MSG:RM: origin color");
            reticule.color = origin;
        }
    }
}
