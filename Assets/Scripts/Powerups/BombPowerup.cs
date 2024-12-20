using UnityEngine;

public class BombPowerup : MonoBehaviour
{
    public float despawnTime = 15f;

    public LayerMask whatIsEnemy;
    public GameObject bigExplosion;
    public float bombRadius;

    private void Start()
    {
        Destroy(gameObject, despawnTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("WE BRING THE BOOOOM");
            AudioManager.instance.PlayClip(4, AudioManager.instance.sfxSource);
            Instantiate(bigExplosion, transform.position, Quaternion.identity);

            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, bombRadius, whatIsEnemy);

            foreach (Collider2D hit in hits)
            {                
                Destroy(hit.gameObject);

                LevelManager.Instance.EnemyDies();
                LevelManager.Instance.EnemyKilled();
            }

            Destroy(gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, bombRadius);
    }

}
