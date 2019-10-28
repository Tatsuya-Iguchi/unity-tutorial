using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitcher : MonoBehaviour
{
    public GameObject objectPosText;

    private bool ObjectSwitcher;
    private Vector3 objectPos;
    private Vector3 objectPos2;
    public Vector3 targetObject;

    void Start()
    {
        ObjectSwitcher = false;

        objectPos = GameObject.Find("terraceCube").transform.position;
        objectPos2 = GameObject.Find("toiletSphere").transform.position;
        targetObject = objectPos;
    }

    void Update()
    {
        objectPosText.GetComponent<Text>().text = "X:" + targetObject.x + "\n" + "Y:" + targetObject.y + "\n" + "Z:" + targetObject.z;
    }

    public void OnClick()
    {
        if (ObjectSwitcher == false) {
            targetObject = objectPos;
        }
        else {
            targetObject = objectPos2;
        }
        ObjectSwitcher = !ObjectSwitcher;
    }
}
