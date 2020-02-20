using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SCNChanger : MonoBehaviour
{
    public void SCNChange(int index)
    {
        SceneManager.LoadScene(index);
    }
}