using TMPro;
using UnityEngine;

public class Basket : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private int _score;

    private void OnTriggerEnter(Collider other)
    {
        _score++;
        scoreText.text = _score.ToString();
    }
}