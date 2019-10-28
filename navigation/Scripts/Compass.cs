using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{

    [SerializeField]
    private RectTransform m_root;

    [SerializeField]
    private Text m_trueHeading;

    //[SerializeField]
    //public static LocationInfo m_locationInfo;

    // Start is called before the first frame update
    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        m_root.rotation = Quaternion.Euler(0, 0, Input.compass.trueHeading);
        m_trueHeading.text = ((int)Input.compass.trueHeading).ToString() + "°";
        
    }

    //void OnGUI()
    //{
    //    var sb = new System.Text.StringBuilder();
    //    sb.Append("Enabled        :").AppendLine(Input.compass.enabled.ToString());
    //    sb.Append("headingAccuracy:").AppendLine(Input.compass.headingAccuracy.ToString());
    //    sb.Append("magneticHeading:").AppendLine(Input.compass.magneticHeading.ToString());
    //    sb.Append("rawVector      :").AppendLine(Input.compass.rawVector.ToString());
    //    sb.Append("timestamp      :").AppendLine(Input.compass.timestamp.ToString());
    //    sb.Append("trueHeading    :").AppendLine(Input.compass.trueHeading.ToString());
    //    sb.Append("----------------" + "\n");
    //    sb.Append("\n" + "lastdata       :" + Input.location.lastData.altitude);
    //    sb.Append("\n" + "horizontalAccuracy:" + Input.location.lastData.horizontalAccuracy);
    //    sb.Append("\n" + "latitude       :" + Input.location.lastData.latitude);
    //    sb.Append("\n" + "longitude      :" + Input.location.lastData.longitude);
    //    sb.Append("\n" + "timestamp      :" + Input.location.lastData.timestamp);
    //    sb.Append("\n" + "verticalAccuracy:" + Input.location.lastData.verticalAccuracy);

    //    GUI.Label(new Rect(10, 100, 256, 256), sb.ToString());
    //}
}
