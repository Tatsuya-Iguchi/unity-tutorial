using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject CP1;
    [SerializeField]
    GameObject CP2;
    [SerializeField]
    GameObject CP3;
    [SerializeField]
    GameObject CP4;
    [SerializeField]
    GameObject CP5;
    [SerializeField]
    GameObject CP6;
    [SerializeField]
    GameObject CP7;
    [SerializeField]
    GameObject CP8;


    protected int endSCN = 4;
    
    void Update()
    {
        if (CP1.GetComponent<Renderer>().material.color == Color.green &&
            CP2.GetComponent<Renderer>().material.color == Color.green &&
            CP3.GetComponent<Renderer>().material.color == Color.green &&
            CP4.GetComponent<Renderer>().material.color == Color.green &&
            CP5.GetComponent<Renderer>().material.color == Color.green &&
            CP6.GetComponent<Renderer>().material.color == Color.green &&
            CP7.GetComponent<Renderer>().material.color == Color.green &&
            CP8.GetComponent<Renderer>().material.color == Color.green)
        {
            SceneManager.LoadScene(endSCN);
        }
    }
}
