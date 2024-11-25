using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private int playerHealth;

    private int enemyCount;
    private int round;

    private AudioSource source;
    public AudioClip hit;
    public AudioClip newLevel;

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
        source = GetComponent<AudioSource>();
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
        source.PlayOneShot(hit, 0.7f);
    }

    #endregion

    #region enemies
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

    #endregion

    #region rounds

    public void IncreaseRound()
    {
        round++;
        source.PlayOneShot(newLevel, 0.7f);
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
