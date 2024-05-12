using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    [SerializeField]
    private HeartMeterManager heartMeterManager;
    [SerializeField]
    private Transform _balloonTransform;
    [SerializeField]
    private List<TriggerController> _triggerObjects;
    [SerializeField]
    private float _air = 1f;
    [SerializeField]
    private float _airDecrease = 0.25f;
    [SerializeField]
    private float _airIncrease = 2f;
    [SerializeField]
    private int _multiplier = 10000;

    private Rigidbody2D _rb2D;
    public bool _isPumping = false;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        foreach (var trigger in _triggerObjects)
        {
            trigger.BalloonController = this;
        }
    }

    private void Start()
    {

    }

    private void Update()
    {
        UpdateBalloon();
    }

    public void HandleTriggerEnter(ObjectTypeEnum type, string collide)
    {
        switch (type)
        {
            case ObjectTypeEnum.Pump when collide == "Player":
                _isPumping = true;
                break;
            case ObjectTypeEnum.Receiver when collide == "Signal":
                heartMeterManager.IsLostConnection = false;
                break;
            default: break;
        }
    }

    public void HandleTriggerExit(ObjectTypeEnum type, string leave)
    {
        switch (type)
        {
            case ObjectTypeEnum.Pump when leave == "Player":
                _isPumping = false;
                break;
            case ObjectTypeEnum.Receiver when leave == "Signal":
                heartMeterManager.IsLostConnection = true;
                break;
            default: break;
        }
    }

    private void UpdateBalloon()
    {
        if (_isPumping)
        {
            _air += _airIncrease / _multiplier;
            if (_air > 2.5)
                _air = 2.5f;

            _rb2D.AddForce(transform.up * _air);
        }
        else
        {
            _air -= _airDecrease / _multiplier;
            if (_air < 1)
                _air = 1;

            _rb2D.AddForce(transform.up * 0);
        }

        _balloonTransform.localScale = Vector3.one * _air;
    }
}
