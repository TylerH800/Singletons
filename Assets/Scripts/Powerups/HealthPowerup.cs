using UnityEngine;

public class HealthPowerup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.Instance.SetPlayerHealth(LevelManager.Instance.GetPlayerHealth() + 1);
            print("You got health!");
            Destroy(gameObject);
        }
    }
}
