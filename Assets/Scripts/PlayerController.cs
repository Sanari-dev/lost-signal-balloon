using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 0.5f;
    [Range(0, .3f)]
    [SerializeField] 
    private float _movementSmoothing = .05f;

    private Rigidbody2D _rb2D;
    private bool _facingLeft = true;
    private Vector3 _velocity = Vector3.zero;
    private float _horizontalSpeed = 0f;

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

    }

    private void Update()
    {
        _horizontalSpeed = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Move(_horizontalSpeed);
    }

    public void Move(float move)
    {
        Vector3 targetVelocity = new Vector2(move * _moveSpeed, _rb2D.velocity.y);
        _rb2D.velocity = Vector3.SmoothDamp(_rb2D.velocity, targetVelocity, ref _velocity, _movementSmoothing);

        if (move > 0 && _facingLeft)
        {
            Flip();
        }
        else if (move < 0 && !_facingLeft)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _facingLeft = !_facingLeft;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Boundary")
            SceneController.EndGame();
    }
}
