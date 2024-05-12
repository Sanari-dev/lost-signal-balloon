using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    private Vector2 _offset;

    private void Start()
    {
        _offset = transform.position - _target.position;
    }

    private void Update()
    {
        var newPosition = new Vector2(transform.position.x, _offset.y + _target.position.y);
        transform.position = newPosition;
    }
}
