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
        if(SceneController.IsWinning)
        {
            scoreText.text = $"You got it in {score} seconds";
        }
        else
        {
            scoreText.text = $"You have been trying for {score} seconds and failed";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
