using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSManager: MonoBehaviour
{
    public double latitude = 35.657716; //35.692892
    public double longitude = 139.796801; //139.729042
    const double lat2km = 111319.491;

    public Vector3 ConvertGPS2ARCoordinate(LocationInfo location)
    {
        double dz = (latitude - location.latitude) * lat2km;   // -zが南方向
        double dx = -(longitude - location.longitude) * lat2km; // +xが東方向
        return new Vector3((float)dx, 0, (float)dz);
    }

    void Start()
    {
        Input.location.Start();
        Invoke("UpdateGPS", 1.0f);
    }

    public void UpdateGPS()
    {
        if (Input.location.isEnabledByUser)
        {
            if (Input.location.status == LocationServiceStatus.Running)
            {
                LocationInfo location = Input.location.lastData;
                transform.position = ConvertGPS2ARCoordinate(location);
            }
        }
    }
}
