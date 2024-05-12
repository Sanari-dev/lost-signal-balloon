using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public HeartMeterManager HeartMeterManager;
    [SerializeField]
    private BalloonController _balloonController;
    [SerializeField]
    private Slider _heartMeterUI;

    private void Awake()
    {
        _balloonController.HeartMeterManager = HeartMeterManager;
    }

    private void Update()
    {
        _heartMeterUI.value = HeartMeterManager.GetCurrentHeartValue();
    }

}
