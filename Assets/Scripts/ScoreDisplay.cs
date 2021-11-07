using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreDisplayText;
    private int coinScore;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerController>().OnCoinCollect += OnCoinCollected;
        coinScore = 0;
    }

    private void OnCoinCollected() {
        coinScore += 1;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplayText.text = "Coins: " + coinScore;
    }
}
