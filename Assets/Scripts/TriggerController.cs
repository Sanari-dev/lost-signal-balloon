using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TriggerController : MonoBehaviour
{
    [SerializeField]
    private ObjectTypeEnum _type;
    public BalloonController BalloonController { get; set; }

    private void OnTriggerEnter2D(Collider2D col)
    {
        BalloonController.HandleTriggerEnter(_type, col.gameObject.tag);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        BalloonController.HandleTriggerExit(_type, col.gameObject.tag);
    }
}
