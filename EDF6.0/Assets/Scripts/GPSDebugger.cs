using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSDebugger : MonoBehaviour
{
    [SerializeField]
    GameObject textArea;
    [SerializeField]
    GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        textArea = GameObject.Find("DebugMessageArea");
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        textArea.GetComponent<Text>().text = "Xm:" + Camera.main.transform.position.x + "  " +
                                             "Ym:" + Camera.main.transform.position.y + "  " +
                                             "Zm:" + Camera.main.transform.position.z + "  " +
                                             "\n" + "----------" + "\n" +
                                             "X°:" + Camera.main.transform.eulerAngles.x + "  " +
                                             "Y°:" + Camera.main.transform.eulerAngles.y + "  " +
                                             "Z°:" + Camera.main.transform.eulerAngles.z + "  " +
                                             "\n" + "----------" + "\n" +
                                             "緯度:" + Input.location.lastData.latitude.ToString() + "\n" +
                                             "経度:" + Input.location.lastData.longitude.ToString() + "\n" +
                                             "\n" + "----------" + "\n" +
                                             "Xm:" + target.transform.position.x + "  " +
                                             "Ym:" + target.transform.position.y + "  " +
                                             "Zm:" + target.transform.position.z + "  " +
                                             "\n" + "----------" + "\n" +
                                             "";
    }
}
