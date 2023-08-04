using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimit : MonoBehaviour
{
    private int fpsLimit = 30;

    // Start is called before the first frame update
    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = fpsLimit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
