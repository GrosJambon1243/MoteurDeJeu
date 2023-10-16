using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class stopWatch : MonoBehaviour
{
    [SerializeField] TMP_Text _textStopWatch;

     private float ElapsedTime { get; set; }
    private bool _isRuning = false;
    
    
    void Start()
    {
        _isRuning = true;
        
    }
   

    
    void Update()
    {
        if (_isRuning)
        {
            ElapsedTime += Time.deltaTime;
            UpdateStopWatch();
        }
    }

    private void UpdateStopWatch()
    {
        string formattedTime = string.Format("{0:00}:{1:00}" , Mathf.Floor((ElapsedTime / 60) % 60), ElapsedTime % 60);

        _textStopWatch.text = formattedTime;

    }
}
