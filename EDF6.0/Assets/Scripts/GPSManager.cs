using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSManager: MonoBehaviour
{
    const double lat2km = 111319.491; // 緯度（経度）1°分の差分(km)
    [SerializeField]
    double latitude = 35.692892;
    [SerializeField]
    double longitude = 139.729042;
    [SerializeField]
    double debug_latitude = 35.657716;
    [SerializeField]
    double debug_longitude = 139.796801;
    [SerializeField]
    bool isDebug = false;

    public Vector3 ConvertGPS2ARCoordinate(LocationInfo location)
    {
        double dz = (latitude - location.latitude) * lat2km;    // -zが南方向
        double dx = -(longitude - location.longitude) * lat2km; // +xが東方向
        return new Vector3((float)dx, 20, (float)dz);
    }

    void Start()
    {
        if (isDebug)
        {
            latitude = debug_latitude;
            longitude = debug_longitude;
        }
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
                this.transform.position = ConvertGPS2ARCoordinate(location);
            }
        }
    }
}
