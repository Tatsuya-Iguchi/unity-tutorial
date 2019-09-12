using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class TapToObject : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementMarker;

    private ARRaycastManager arRayMgr;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    // Start is called before the first frame update
    void Start()
    {
        arRayMgr = FindObjectOfType<ARRaycastManager>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementMarker();

        if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject();
        }
    }

    private void PlaceObject()
    {
        Quaternion q = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        Instantiate(objectToPlace, placementPose.position, placementPose.rotation * q);
    }

    private void UpdatePlacementMarker()
    {
        if (placementPoseIsValid)
        {
            placementMarker.SetActive(true);
            Quaternion q = Quaternion.Euler(180.0f, 0.0f, 180.0f);
            placementMarker.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation * q);
        }
        else
        {
            placementMarker.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRayMgr.Raycast(screenCenter, hits);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }

    }
}
