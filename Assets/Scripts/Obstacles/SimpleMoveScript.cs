using UnityEngine;

public class SimpleMoveScript : MonoBehaviour
{
    public bool MoveToRight;
    public Vector2 SpeedRange;
    private readonly string BoundaryColliderTag = "Boundary";
    private float Speed;

    private void Awake()
    {
        Speed = Random.Range(SpeedRange.x, SpeedRange.y);
    }

    private void FixedUpdate()
    {
        var direction = MoveToRight ? Vector2.right : Vector2.right * -1;
        transform.Translate(direction * Time.deltaTime * Speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if(other.gameObject.CompareTag(BoundaryColliderTag))
            Destroy(gameObject);
    }
}
