using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamPos : MonoBehaviour
{
    public GameObject initCamPosText;
    public GameObject currentCamPosText;
    public GameObject currentCamRotText;

    public GameObject navigationArrow;
    public GameObject objectSwitcher;

    //public UnityARAlignment startAlignment = UnityARAlignment.UnityARAlignmentGravity;
    private Camera cam;

    private ButtonSwitcher buttonScript;
    private Location station = new Location(35.655047d, 139.796662d);
    //private Location station = new Location(-65.65614d, 159.7969d);

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;                      //メインカメラのタグが付いているオブジェクト

        Input.location.Start();

        //ボタンについているスクリプトを呼ぶ
        buttonScript = objectSwitcher.GetComponent<ButtonSwitcher>();

        //起動時にオブジェクトとの差分から 0,0,0 の相対位置を補正する。
        //テラスキューブの座標位置が必ず -16,-1,27 として、起動位置の補正をかける。

    }

    // Update is called once per frame
    void Update()
    {
        //テキストの内容を変更する
        Vector3 camPos = cam.transform.position;
        Vector3 camRot = cam.transform.eulerAngles;

        GameObject gobj = GameObject.Find("testMarker");
        //Vector3 testMarker = gobj.transform.position;

        
        const float D_R = Mathf.PI / 180;
        Vector3 testMarker = new Vector3(Mathf.Cos((float) station.Longitude* D_R) * Mathf.Cos((float) station.Latitude* D_R), Mathf.Sin((float) station.Latitude* D_R), Mathf.Sin((float) station.Longitude* D_R) * Mathf.Cos((float) station.Latitude* D_R));
        //GetComponent<Transform>().position = locale* 550;

        Input.location.Start();
        //initial camera position 0,0,0 -> START de yoi
        initCamPosText.GetComponent<Text>().text = "\n" + "altitude高度       :" + Input.location.lastData.altitude + "\n" + "latitude経度       :" + Input.location.lastData.latitude + "\n" + "longitude緯度      :" + Input.location.lastData.longitude;
        //initCamPosText.GetComponent<Text>().text = "\n" + Input.location.status + "\n" + "X:  " + testMarker.x + "\n" + "Y:  " + testMarker.y + "\n" + "Z:  "  + testMarker.z + "\n" + "altitude高度       :" + Input.location.lastData.altitude + "\n" + "latitude経度       :" + Input.location.lastData.latitude + "\n" + "longitude緯度      :" + Input.location.lastData.longitude;
        //current camera position x,y,z
        currentCamPosText.GetComponent<Text>().text = "Xm:" + camPos.x + "\n" + "Ym:" + camPos.y + "\n" + "Zm:" + camPos.z;
        currentCamRotText.GetComponent<Text>().text = "X°:" + camRot.x + "\n" + "Y°:" + camRot.y + "\n" + "Z°:" + camRot.z;

        navigationArrow.transform.LookAt(buttonScript.targetObject);

    }
}
