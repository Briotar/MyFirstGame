using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudView : MonoBehaviour
{
    [SerializeField] private TMP_Text _time;
    [SerializeField] private TMP_Text _coins;

    private string _showText;

    public void ShowTime(int currentMinuts, int CurrentSeconds)
    {
        if(CurrentSeconds < 10)
            _showText = $"{currentMinuts}:0{CurrentSeconds}";
        else
            _showText = $"{currentMinuts}:{CurrentSeconds}";

        _time.text = _showText;
    }

    public void ShowCoins(int coinsCount)
    {
        _coins.text = coinsCount.ToString();
    }
}
