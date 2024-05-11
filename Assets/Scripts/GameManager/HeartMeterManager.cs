using UnityEngine;

public class HeartMeterManager : MonoBehaviour
{
    public float MaxHeartValue;
    public bool IsLostConnection;
    public float DecreaseRate;
    
    private float CurrentHeartValue;

    private void Start()
    {
        CurrentHeartValue = MaxHeartValue;
    }

    private void FixedUpdate()
    {
        if (!IsLostConnection)
            return;
        
        CurrentHeartValue -= Time.deltaTime * DecreaseRate;
        Debug.Log(CurrentHeartValue);
    }

    public float GetCurrentHeartValue()
    {
        return CurrentHeartValue;
    }
}
