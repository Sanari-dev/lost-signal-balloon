using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public HeartMeterManager HeartMeterManager;
    [SerializeField]
    private BalloonController _balloonController;
    [SerializeField]
    private Slider _heartMeterUI;
    [SerializeField]
    private TextMeshProUGUI _time;    

    Stopwatch stopWatch = new Stopwatch();

    private void Awake()
    {
        _balloonController.HeartMeterManager = HeartMeterManager;        
    }

    private void Start()
    {
        stopWatch.Start();
    }

    private void Update()
    {
        _heartMeterUI.value = HeartMeterManager.GetCurrentHeartValue();
        var counter = (int)stopWatch.Elapsed.TotalSeconds;
        _time.text = counter.ToString();
        SceneController.Score = counter;
    }

}
