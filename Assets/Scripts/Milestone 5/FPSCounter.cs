using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    public int target = 60;
    public Text targetText;

    public void Start()
    {
        QualitySettings.vSyncCount = 0;
        targetText.text = "FPS: " + target;
    }

    public void Update()
    {
        if (target != Application.targetFrameRate)
        {
            Application.targetFrameRate = target;
        }
    }
}
