using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TargetManager : MonoBehaviour
{
    [SerializeField]
    private int maxHP = 100;
    [SerializeField]
    private int hitPoint;
    [SerializeField]
    private GameObject HPHUD;
    private Slider hpBar;

    void Start()
    {
        hitPoint = maxHP;
        hpBar = HPHUD.transform.Find("HP Bar").GetComponent<Slider>();
        hpBar.value = 1f;
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("MSG: Target Collision");
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("MSG: Target_HP is :" + hitPoint );
            hitPoint--;

            hpBar.value = (float)hitPoint / (float)maxHP;
        }
        if(hitPoint <= 0)
        {
            Destroy(gameObject);
            Debug.Log("MSG: Target is Destroy");

            SceneManager.LoadScene(5);
        }
    }
}
