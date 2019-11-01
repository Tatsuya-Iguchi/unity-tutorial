using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSwitcher : MonoBehaviour
{
    public string goal;
    public string target;
    public Vector3 objectPosition;

    private bool ObjectSwitcher;
    //private Vector3 objectPos;
    //private Vector3 objectPos2;

    //Params printerParams = new Params();

    void Start()
    {
        goal = "N05-N06柱の間";
        target = "GoalA";
        //printerParams.Goal = "トイレ近くのプリンター";
        //printerParams.Target = "GoalA";
        //printerParams.ObjectPosition = GameObject.Find("GoalA").transform.position;
        ObjectSwitcher = false;
    }


    public void OnClick()
    {
        if (ObjectSwitcher == false) {
            //printerParams.Goal = "N06の柱付近";
            //printerParams.Target = "GoalA";
            //printerParams.ObjectPosition = GameObject.Find("GoalA").transform.position;
            goal = "N05-N06柱の間";
            target = "GoalA";
            //objectPosition = GameObject.Find("GoalA").transform.position;
        }
        else {
            //printerParams.Goal = "トイレ近くのプリンター";
            //printerParams.Target = "GoalB";
            //printerParams.ObjectPosition = GameObject.Find("GoalB").transform.position;
            goal = "トイレ近くのプリンター";
            target = "GoalB";
            //objectPosition = GameObject.Find("GoalB").transform.position;
        }
        ObjectSwitcher = !ObjectSwitcher;
    }

    //target
    //public string getTarget()
    //{
    //    return this.target;
    //}
    //public void setTarget(string target)
    //{
    //    this.target = target;
    //}
    //goal
    //public string getGoal()
    //{
    //    return this.goal;
    //}
    //public void setGoal(string goal)
    //{
    //    this.goal = goal;
    //}
    ////objectPos
    //public Vector3 getObjectPosition()
    //{
    //    return this.objectPosition;
    //}
    //public void setObjectPosition(Vector3 objectPosition)
    //{
    //    this.objectPosition = objectPosition;
    //}

    public class Params
    {
        [SerializeField]
        private string target;
        public string Target
        {
            get { return this.target; }
            private set { this.target = value; }
        }

        [SerializeField]
        private string goal;
        public string Goal
        {
            get { return this.goal; }
            private set { this.goal = value; }
        }

        [SerializeField]
        private Vector3 objectPosition;
        public Vector3 ObjectPosition
        {
            get { return this.objectPosition; }
            private set { this.objectPosition = value; }
        }

    }
}
