using UnityEngine;

public class HealthPowerup : MonoBehaviour
{
    public float despawnTime = 15f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, despawnTime);
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
