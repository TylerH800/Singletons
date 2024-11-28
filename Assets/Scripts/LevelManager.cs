using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private int playerHealth;
    private int kills = 0;

    private int enemyCount;
    private int round;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("HighestRound"))
        {
            PlayerPrefs.GetInt("HighestRound");
        }
        else
        {
            PlayerPrefs.SetInt("HighestRound", 1);
        }
    }


    #region Levels
    public void LoadLevel(string index)
    {
        SceneManager.LoadScene(index);
       
    }

    #endregion

    #region health
    public void SetPlayerHealth(int health)
    {
        playerHealth = health;
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public void DoDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        LoadLevel("Frontend");
    }

    #endregion

    #region enemies
    //----- Keeps track of the enemy count for round purposes --------
    public void SetEnemyCount(int count)
    {
        enemyCount = count;
    }

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public void EnemyDies()
    {
        enemyCount--;
    }

    //----- Keeps track of the players kills ---------
    public void EnemyKilled()
    {
        kills++;
    }
    
    public void ResetKills()
    {
        kills = 0;
    }
    public int GetKills()
    {
        return kills;
    }

    

    #endregion

    #region rounds

    public void IncreaseRound()
    {
        round++;
        AudioManager.instance.PlayClip(1, 0.7f);

        if (round > PlayerPrefs.GetInt("HighestRound"))
        {
            PlayerPrefs.SetInt("HighestRound", round);
        }
        
    }
    

    public int GetRound()
    {
        return round;
    }

    public void ResetRound()
    {
        round = 0;
    }

    #endregion
}
