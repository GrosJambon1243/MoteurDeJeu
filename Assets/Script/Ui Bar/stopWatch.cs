
using TMPro;

using UnityEngine;


public class stopWatch : MonoBehaviour
{
    [SerializeField] TMP_Text _textStopWatch;

    private float _elapsedTime;

    public float ElapsedTime
    {
        get => _elapsedTime;
    }
    private bool _isRuning = false;
    
    
    void Start()
    {
        _isRuning = true;
        
    }
   

    
    void Update()
    {
        if (_isRuning)
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
