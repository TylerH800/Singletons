using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPositions;
    public float timeBetweenSpawns = 0.6f;

    private void Start()
    {
        LevelManager.Instance.SetEnemyCount(0);
        LevelManager.Instance.ResetRound();

    }
    void Update()
    {
        DetectForRoundWon();
  
    }    

    void DetectForRoundWon()
    {
        if (LevelManager.Instance.GetEnemyCount() <= 0)
        {
            StartCoroutine(NewRound(timeBetweenSpawns));
        }
    }

    IEnumerator NewRound(float time)
    {
        LevelManager.Instance.IncreaseRound();
        LevelManager.Instance.SetEnemyCount(LevelManager.Instance.GetRound());
        for (int i = 0; i < LevelManager.Instance.GetRound(); i++)
        {
            //print("spawning");
            Instantiate(enemyPrefab, GenerateSpawnPos(), Quaternion.identity);
            yield return new WaitForSeconds(time);
        }
    }

    private Vector3 GenerateSpawnPos()
    {
        int index = Random.Range(0, spawnPositions.Length);
        Transform pos = spawnPositions[index];
        return pos.position;
    }
}
