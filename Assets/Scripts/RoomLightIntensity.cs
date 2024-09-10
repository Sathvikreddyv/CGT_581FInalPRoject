using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class RoomLightIntensity : MonoBehaviour
{
    public Light[] lamps;
    public Transform measurementPoint;
    public float targetIntensity;

    void Start()
    {
        // Calculate the intensity at the measurement point
        CalculateIntensityAtPoint();
    }

    void CalculateIntensityAtPoint()
    {
        // Randomize the intensity of each lamp
        float intensity1 = Random.Range(0f, targetIntensity);
        float intensity2 = targetIntensity - intensity1;

        // Set the intensities of the lamps
        lamps[0].intensity = intensity1;
        lamps[1].intensity = intensity2;

        // Calculate the total intensity at the measurement point
        float distance1 = Vector3.Distance(measurementPoint.position, lamps[0].transform.position);
        float distance2 = Vector3.Distance(measurementPoint.position, lamps[1].transform.position);
        float totalIntensity = (intensity1 / Mathf.Pow(distance1, 2)) + (intensity2 / Mathf.Pow(distance2, 2));

        Debug.Log("Intensity at measurement point: " + totalIntensity);
    }

}
