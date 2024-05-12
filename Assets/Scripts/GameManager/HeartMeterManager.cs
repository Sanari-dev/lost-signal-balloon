using UnityEngine;
using UnityEngine.UI;

public class HeartMeterManager : MonoBehaviour
{
    public float MaxHeartValue;
    public bool IsLostConnection;
    public float DecreaseRate;

    [SerializeField]
    private float CurrentHeartValue;
    [SerializeField]
    private Color _colorFailed;
    [SerializeField]
    private Color _colorConnect;
    [SerializeField]
    private Image _fillMeter;

    private void Start()
    {
        CurrentHeartValue = MaxHeartValue / 2;
        IsLostConnection = true;
        _fillMeter.color = _colorFailed;
    }

    private void Update()
    {
        if (!IsLostConnection)
        {
            _fillMeter.color = _colorConnect;
            CurrentHeartValue += Time.deltaTime * DecreaseRate/4;
        }
        else
        {
            _fillMeter.color = _colorFailed;
            CurrentHeartValue -= Time.deltaTime * DecreaseRate;
            if(CurrentHeartValue <= 0)
            {
                SceneController.IsWinning = false;
                SceneController.EndGame();
            }
                
            else if(CurrentHeartValue >= MaxHeartValue)
            {
                SceneController.IsWinning = true;
                SceneController.EndGame();
            }
        }              
    }

    public float GetCurrentHeartValue()
    {
        return CurrentHeartValue;
    }
}
