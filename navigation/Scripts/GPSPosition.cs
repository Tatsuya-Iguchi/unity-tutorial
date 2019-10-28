using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSPosition : MonoBehaviour
{
    //private Location station = new Location(35.655047d, 139.796662d);
    //const float D_R = Mathf.PI / 180;
    //locale = new Vector3(Mathf.Cos((float) station.Longitude* D_R) * Mathf.Cos((float) station.Latitude* D_R), Mathf.Sin((float) station.Latitude* D_R), Mathf.Sin((float) station.Longitude* D_R) * Mathf.Cos((float) station.Latitude* D_R));
    //GetComponent<Transform>().position = locale* 550;

    IEnumerator Start()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        }

        // Stop service if there is no need to query location updates continuously
        //Input.location.Stop();
    }
}