using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Rounds and Enemies")]
    public TextMeshProUGUI round;
    public TextMeshProUGUI enemies;

    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI highestRound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rounds and enemies
        round.text = "Round: " + LevelManager.Instance.GetRound();
        enemies.text = "Enemies left: " + LevelManager.Instance.GetEnemyCount();

        gameOver.text = "You survived " + LevelManager.Instance.GetRound() + " rounds and killed " + LevelManager.Instance.GetKills() + " enemies!";
        highestRound.text = "Your highest round is round " + PlayerPrefs.GetInt("HighestRound") + "!";
    }
}
