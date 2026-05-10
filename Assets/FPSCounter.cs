using UnityEngine;
using System.Collections.Generic;

public class FPSCounter : MonoBehaviour
{
    int currentFrameCount;

    float nextTick;

    List<int> frameList = new List<int>();
    void Update()
    {
        currentFrameCount++;

        if(Time.time > nextTick)
        {
            nextTick = Time.time + 1;
            frameList.Add(currentFrameCount);
            currentFrameCount = 0;
            if(frameList.Count > 10)
            {
                frameList.RemoveAt(10);
            }
        }

        int AverageFrameCount = 0;
        for(int i = 0; i < frameList.Count; i++)
        {
            AverageFrameCount += frameList[i];
        }

        Debug.Log(AverageFrameCount/frameList.Count);
    }
}