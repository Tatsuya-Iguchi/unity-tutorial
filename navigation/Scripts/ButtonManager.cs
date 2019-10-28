using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager: MonoBehaviour
{
    public static string targetName = null;

    // ボタンをクリックした時の処理
    public void ToNavigation()
    {
        targetName = "toiletPrinter";
        SceneManager.LoadScene("Navigation");
    }

    public void ToTitle()
    {
        targetName = "N06";
        SceneManager.LoadScene("Title");
    }
}