using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LapManager : MonoBehaviour
{
    public int numberOfLaps = 3;
    public Dictionary<string, List<float>> carLapTimes = new Dictionary<string, List<float>>();

    public void UpdateCarLapTimes(string carName, float lapTime)
    {
        if(carLapTimes.ContainsKey(carName))
        {
            carLapTimes[carName].Add(lapTime);
        }
        else
        {
            carLapTimes.Add(carName, new List<float> { lapTime });
        }

        if(carLapTimes[carName].Count == numberOfLaps)
        {
            DisplayFinalCarResults(carName);
        }
    }

    private void DisplayFinalCarResults(string carName)
    {
        print(carName);
        
        for(int i = 0; i<numberOfLaps; i++)
        {
            print("Lap " + (i + 1) + ": " + carLapTimes[carName][i]);
        }
        print("Total Race Time: " + carLapTimes[carName].Sum());
        print("----------------------------------");
    }
}
