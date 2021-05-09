using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimizeGame : MonoBehaviour
{   
    public void Optimize(float level)
    {
        QualitySettings.SetQualityLevel((int)level); 
    }
}
