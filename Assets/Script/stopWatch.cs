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
    private float _elapsedTime;
    private bool _isRunnig = false;
    
    
    void Start()
    {
        _isRunnig = true;
        
    }
   

    
    void Update()
    {
        if (_isRunnig)
        {
            _elapsedTime += Time.deltaTime;
            UpdateStopWatch();
        }
    }

    private void UpdateStopWatch()
    {
        string formattedTime = string.Format("{0:00}:{1:00}" , Mathf.Floor((_elapsedTime / 60) % 60), _elapsedTime % 60);

        _textStopWatch.text = formattedTime;

    }
}
