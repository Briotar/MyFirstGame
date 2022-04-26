using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreenView : MonoBehaviour
{
    [SerializeField] TMP_Text _score;
    [SerializeField] TMP_Text _time;
    [SerializeField] TMP_Text _coins;

    public void OnEndscreenShow(int coinsCount, int minuts, int seconds)
    {
        _coins.text = $"Coins:{coinsCount}";

        if(seconds < 10)
            _time.text = $"Time:{minuts}:0{seconds}";
        else
            _time.text = $"Time:{minuts}:{seconds}";

        int score = (minuts + 1) * coinsCount + seconds;
        _score.text = $"Score:{score}";
    }
}
