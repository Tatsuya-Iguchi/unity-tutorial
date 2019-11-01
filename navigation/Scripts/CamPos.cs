using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CamPos : MonoBehaviour
{
    public GameObject navigationArrow;
    public ButtonSwitcher bsScript;
    protected int minDistance = 1;

    private Camera cam;
    private Vector3 goalPos;
    private GameObject currentCamPosText; //for DEBUG

    private GameObject goalText;
    private GameObject goalDistance;

    private string goal;
    private string target;
    private float distance;

    //public ButtonSwitcher script;

    // Start is called before the first frame update
    void Start()
    {
        goalText = GameObject.Find("GoalText");
        goalDistance = GameObject.Find("DistanceText");

        goal = bsScript.goal;
        target = bsScript.target;

        goalPos = GameObject.Find(target).transform.position;
        currentCamPosText = GameObject.Find("currentPosition"); //for DEBUG
    }

    // Update is called once per frame
    void Update()
    {
        goal = bsScript.goal;
        target = bsScript.target;
        goalPos = GameObject.Find(target).transform.position;

        Vector3 cameraPosition = Camera.main.transform.position;
        distance = Vector3.Distance(cameraPosition, goalPos);

        //テキストの内容を変更する
        goalText.GetComponent<Text>().text = "目標地点は、 " + "\n　" + goal + "\n" + "です。";

        if (distance > minDistance)
        {
            goalDistance.GetComponent<Text>().text = "残り" + distance.ToString("f1") + "m です。";
            goalDistance.GetComponent<Text>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            GameObject.Find(target).SetActive(true);
        }
        else
        {
            goalDistance.GetComponent<Text>().text = "目的地付近です。";
            goalDistance.GetComponent<Text>().color = new Color(0.0f, 0.8f, 0.0f, 1.0f);
            GameObject.Find(target).SetActive(false);
        }


        //for DEBUG
        currentCamPosText.GetComponent<Text>().text = "Xm:" + cameraPosition.x + "\n" + "Ym:" + cameraPosition.y + "\n" + "Zm:" + cameraPosition.z;

        navigationArrow.transform.LookAt(goalPos);
    }
}
