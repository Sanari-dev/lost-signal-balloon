using UnityEngine;

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
        IsLostConnection = true;
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
