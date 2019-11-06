using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO: ButtonManagerとかに全て移植する

public class ButtonSwitcher : MonoBehaviour
{
    public string goal;
    public string target;
    public Vector3 objectPosition;

    private bool ObjectSwitcher;

    void Start()
    {
        goal = "AIOperationManager";    //Jがいじるところ
        target = "GoalA";
        ObjectSwitcher = false;
    }


    public void OnClick()
    {
        if (ObjectSwitcher == false) {
            goal = "AIOperationManager";    //Jがいじるところ
            target = "GoalA";
        }
        else {
            goal = "トイレ近くのプリンター";   //Jがいじるところ
            target = "GoalB";
        }
        ObjectSwitcher = !ObjectSwitcher;
    }

    
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
