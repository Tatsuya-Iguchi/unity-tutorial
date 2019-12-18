using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSDebugger : MonoBehaviour
{
    [SerializeField]
    GameObject textArea;

    // Start is called before the first frame update
    void Start()
    {
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        textArea.GetComponent<Text>().text = "X°:" + Camera.main.transform.position.x + "  " +
                                             "Y°:" + Camera.main.transform.position.y + "  " +
                                             "Z°:" + Camera.main.transform.position.z + "  " +
                                             "\n" + "----------" + "\n" +
                                             "Xm:" + Camera.main.transform.eulerAngles.x + "  " +
                                             "Ym:" + Camera.main.transform.eulerAngles.y + "  " +
                                             "Zm:" + Camera.main.transform.eulerAngles.z + "  " +
                                             "\n" + "----------" + "\n" +
                                             "GPS:" + Input.location.status.ToString() + "\n" +
                                             "緯度:" + Input.location.lastData.latitude.ToString() + "\n" +
                                             "経度:" + Input.location.lastData.longitude.ToString() + "\n" +
                                             "";
    }
}
