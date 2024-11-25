using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerScript : MonoBehaviour
{
    public float speed;

    public float attackRadius;
    bool canAttack = true;
    public float attackCld;
    public LayerMask whatIsEnemy;
    public GameObject explosion;

    public int startingHealth;

    private Rigidbody2D rb;

    private PlayerInput playerInput;
    private Vector2 moveDirection;

    public GameObject gameOverText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LevelManager.Instance.SetPlayerHealth(startingHealth);

        playerInput = new PlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (LevelManager.Instance.GetPlayerHealth() <= 0)
        {
            Destroy(gameObject);
            gameOverText.SetActive(true);
        }
    }

    void Movement()
    {               
        rb.linearVelocity = moveDirection * speed;
        
    }

    void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();        
    }

    void OnAttack(InputValue value)
    {
        if (!canAttack)
        {
            return;
        }
        canAttack = false;
        Invoke("AttackReset", attackCld);       

        Instantiate(explosion, transform.position, Quaternion.identity);

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRadius, whatIsEnemy);
       
        foreach (Collider2D hit in hits)
        {
            print("hit");
            Destroy(hit.gameObject);

            LevelManager.Instance.EnemyDies();
            print(LevelManager.Instance.GetEnemyCount());
        }
    }
    
    void AttackReset()
    {
        canAttack = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
