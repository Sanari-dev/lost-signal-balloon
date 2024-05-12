using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public HeartMeterManager HeartMeterManager;
    [SerializeField]
    private Slider HeartMeterUI;

    private void Update()
    {
        HeartMeterUI.value = HeartMeterManager.GetCurrentHeartValue();
    }

}
