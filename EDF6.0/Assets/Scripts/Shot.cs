using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform muzzle;
    [SerializeField]
    float speed = 1000;
    [SerializeField]
    GameObject muzzleFlashPrefab = null;
    GameObject muzzleFlash;

    // TODO: Too Fat
    void Update()
    {

        if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Z))
        {
            
            if (muzzleFlash != null)
            {
                Debug.Log("MSG3:" + muzzleFlash);
                muzzleFlash.SetActive(true);
                Debug.Log("MSG3: mF true");
            }
            else
            {
                Debug.Log("MSG3: mF instantiate");
                muzzleFlash = Instantiate(muzzleFlashPrefab, muzzle.transform.position, muzzle.transform.rotation);
                muzzleFlash.transform.SetParent(muzzle.transform);
                //muzzleFlash.transform.localScale = muzzleFlashScale;
                Debug.Log("MSG3: mF pos:" + muzzleFlash.transform.position.x + " " + muzzleFlash.transform.position.y + " " + muzzleFlash.transform.position.z ) ;
            }

            GameObject bullets = Instantiate(bullet) as GameObject;
            Vector3 force;
            force = Camera.main.transform.forward * speed;
            bullets.GetComponent<Rigidbody>().AddForce(force);
            bullets.transform.position = muzzle.position;

            //Destroy(bullets, 3.0f);
        }
        muzzleFlash.SetActive(false);
        Debug.Log("MSG: mF false");
    }
}
