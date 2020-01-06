using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemManager : MonoBehaviour
{
    [SerializeField]
    public ParticleSystem ps;

    private string efe = "CoroutineEffector";

    void Update()
    {
        Debug.Log("MSG:CM: 親要素 " + ps.name + " ");
        StartCoroutine(efe, ps);
    }

    private IEnumerator CoroutineEffector(ParticleSystem _ps)
    {
        Debug.Log("MSG:CM:" + _ps.isPlaying + _ps.name);
        _ps.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.0f);

        Debug.Log("MSG:CM:" + _ps.isPlaying + _ps.name);
        _ps.gameObject.SetActive(false);
        yield return null;
    }
}