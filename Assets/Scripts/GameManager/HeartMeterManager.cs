using UnityEngine;
using UnityEngine.UI;

public class HeartMeterManager : MonoBehaviour
{
    public float MaxHeartValue;
    public bool IsLostConnection;
    public float DecreaseRate;

    [SerializeField]
    private float CurrentHeartValue;

    private void Start()
    {
        CurrentHeartValue = MaxHeartValue;        
    }

    private void Update()
    {
        if (!IsLostConnection)
            return;
        
        CurrentHeartValue -= Time.deltaTime * DecreaseRate;        
    }

    public float GetCurrentHeartValue()
    {
        return CurrentHeartValue;
    }
}
