using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    void Start()
    {
        var scoreText = GetComponent<TextMeshProUGUI>();
        var score = SceneController.Score.ToString();
        scoreText.text = $"Your time: {score}"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
