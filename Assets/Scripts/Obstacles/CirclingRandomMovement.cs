using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclingRandomMovement : MonoBehaviour
{
    public float Speed;
    public float MovementRangeRadius;

    public Vector2 NextPosition;
    public float MinimumDistanceBeforeFindingNewPosition;
    
    private void FixedUpdate()
    {
        var distance = Vector2.Distance(NextPosition, transform.localPosition);
        
        if (distance >= MinimumDistanceBeforeFindingNewPosition)
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, NextPosition, Speed * Time.deltaTime);
            return;
        }
            
        
        var randomPos = Random.insideUnitCircle * MovementRangeRadius;
        NextPosition = new Vector2(Mathf.Clamp(randomPos.x, -6, 6), Mathf.Clamp(randomPos.y, 0, 5));
        HandleAnimation();
    }

    private void HandleAnimation()
    {
        transform.localScale = NextPosition.x - transform.localPosition.x >= 0 ? new Vector3(1f,1f,1f) : new Vector3(-1f,1f,1f);
    }
}
