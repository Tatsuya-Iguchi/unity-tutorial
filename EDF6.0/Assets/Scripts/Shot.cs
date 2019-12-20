using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet = null;
    [SerializeField]
    Transform muzzle = null;
    [SerializeField]
    float speed = 100;
    [SerializeField]
    GameObject ps;

    private ParticleSystem muzzleFlash;
    private float timer = 0.0f;
    private float effectTime = 0.5f;

    void Start()
    {
        muzzleFlash = ps.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log("MSG:" + timer);
        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Z))
        {
            Shooting();
        }
        if (timer > effectTime)
        {
            muzzleFlash.Stop();
            Debug.Log("MSG: mF stop");
            timer = 0.0f;
        }
    }

    void Shooting()
    {
        muzzleFlash.Play();
        GameObject bullets = Instantiate(bullet) as GameObject;
        Vector3 force;
        force = Camera.main.transform.forward * speed;
        bullets.GetComponent<Rigidbody>().AddForce(force);
        bullets.transform.position = muzzle.position;
        //Destroy(bullets, 3.0f);
    }
}
