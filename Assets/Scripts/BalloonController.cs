using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
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
    [SerializeField]
    private AudioSource _pumpSound;

    private Rigidbody2D _rb2D;
    private bool _isPumping = false;
    public HeartMeterManager HeartMeterManager { get; set; }

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
        if (type == ObjectTypeEnum.Pump && collide == "Player")
        {
            _isPumping = true;
            _pumpSound.Play();
        }


        if (type == ObjectTypeEnum.Receiver && collide == "Signal")
        {
            HeartMeterManager.IsLostConnection = false;
        }
    }

    public void HandleTriggerExit(ObjectTypeEnum type, string leave)
    {
        if (type == ObjectTypeEnum.Pump && leave == "Player")
        {
            _isPumping = false;
            _pumpSound.Stop();
        }
            

        if (type == ObjectTypeEnum.Receiver && leave == "Signal")
        {
            HeartMeterManager.IsLostConnection = true;
        }            
    }

    private void UpdateBalloon()
    {
        if (_isPumping)
        {
            _air += _airIncrease / _multiplier;
            if (_air > 2.5)
                _air = 2.5f;

            _rb2D.AddForce(transform.up * _air / 2);
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
