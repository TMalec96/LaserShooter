using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    TextMeshProUGUI score;
    GameSession gameSession;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
        

    }

    // Update is called once per frame
    void Update()
    {
        score.SetText(gameSession.Score.ToString());
    }
}
