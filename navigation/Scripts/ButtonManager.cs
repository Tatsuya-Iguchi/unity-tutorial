using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager: MonoBehaviour
{
    public static string target;
    public static string goal;
    public static Vector3 cameraPosition;

    public void Awake()
    {
        Input.location.Start();
    }

    public void Start()
    {
        DontDestroyOnLoad(this);

        //cameraPosition = cameraPosition + CamPos.getCameraPosition();
    }

    public void Update()
    {
        cameraPosition = Camera.main.transform.position;
        this.OnGUI();
    }

    // ボタンをクリックした時の処理
    public void ToNavigation()
    {
        goal = "トイレ近くのプリンター";
        target = "GoalA";
        //SceneManager.LoadScene("Navigation");
    }

    public void ToTitle()
    {
        goal = "N06の柱付近";
        target = "GoalB";
        //SceneManager.LoadScene("Title");
    }

    //for DEBUG
    void OnGUI()
    {
        var sb = new System.Text.StringBuilder();
        sb.Append("X        :").AppendLine(cameraPosition.x.ToString());
        sb.Append("Y        :").AppendLine(cameraPosition.y.ToString());
        sb.Append("Z        :").AppendLine(cameraPosition.z.ToString());

        GUI.Label(new Rect(30, 200, 256, 256), sb.ToString());
    }

}