using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyScript : MonoBehaviour
{
    public float rotSpeed;
    public float moveSpeed;
    public float bumpForce;
    public float lookRadius;

    public int damage = 10;

    private Vector2 moveDirection;
    
    private Rigidbody2D rb;
    public LayerMask whatIsPlayer;

    public GameObject miniExplosion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed * Time.deltaTime);
        Movement();
    }

    void Movement()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, lookRadius, whatIsPlayer);
        {
            if (hit != null)
            {
                moveDirection = hit.transform.position - transform.position;
            }

            rb.linearVelocity = moveDirection.normalized * moveSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Player")
        {
            LevelManager.Instance.DoDamage(damage);
            print(LevelManager.Instance.GetPlayerHealth());

            LevelManager.Instance.EnemyDies();
            print(LevelManager.Instance.GetEnemyCount());
            
            
            Destroy(gameObject);
        }

    }

    private void OnDestroy()
    {
        if (!this.gameObject.scene.isLoaded)
        {
            return;
        }
        Instantiate(miniExplosion, transform.position, Quaternion.identity);
    }


}
