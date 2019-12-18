using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{

    [SerializeField]
    public GameObject bullet;
    [SerializeField]
    public Transform muzzle;
    [SerializeField]
    public float speed = 1000;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Z))
        {
            GameObject bullets = Instantiate(bullet) as GameObject;
            Vector3 force;
            force = Camera.main.transform.forward * speed;
            bullets.GetComponent<Rigidbody>().AddForce(force);
            bullets.transform.position = muzzle.position;

            Destroy(bullets, 3.0f);
        }
    }
}
