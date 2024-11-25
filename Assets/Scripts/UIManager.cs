using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI round;
    public TextMeshProUGUI enemies;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        round.text = "Round: " + LevelManager.Instance.GetRound();
        enemies.text = "Enemies left: " + LevelManager.Instance.GetEnemyCount();
    }
}
