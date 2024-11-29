using System.Collections;
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

    public SpriteRenderer body;
    public SpriteRenderer outline;


    private AudioSource source;
    public AudioClip boom;
    public AudioClip hit;

    [Header("Powerups")]
    public GameObject[] powerUps;
    public float powerUpChance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        LevelManager.Instance.SetPlayerHealth(startingHealth);
        LevelManager.Instance.ResetKills();

        playerInput = new PlayerInput();

        StartCoroutine(PlayBGMusic());
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        ChangeColour();

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
        
        AudioManager.instance.PlayClip(0, AudioManager.instance.sfxSource);

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRadius, whatIsEnemy);
       
        foreach (Collider2D hit in hits)
        {
            SpawnPowerUp(hit.transform.position);
            Destroy(hit.gameObject);

            LevelManager.Instance.EnemyDies();
            LevelManager.Instance.EnemyKilled();
        }


        
    }
    
    void AttackReset()
    {
        canAttack = true;
    }

    void SpawnPowerUp(Vector2 position)
    {
        int index = Random.Range(0, 100);
        if (index > powerUpChance) //5% chance of spawn
        {
            return;
        }
        print("spawn");
        int powerup = Random.Range(0, powerUps.Length);
        Instantiate(powerUps[powerup], position, Quaternion.identity);
    }

    IEnumerator PlayBGMusic()
    {
        float length = 90f;
        while (true)
        {
            AudioManager.instance.PlayClip(3, AudioManager.instance.musicSource);
            yield return new WaitForSeconds(length);
        }        
    }    

    void ChangeColour()
    {
        if (canAttack)
        {         
            outline.color = Color.black;
        }
        else
        {            
            outline.color = new Color32(109, 0, 0, 255);
        }

        switch (LevelManager.Instance.GetPlayerHealth())
        {
            case 3:
                body.color = new Color32(31, 222, 50, 255);
                return;

            case 2:
                body.color = new Color32(250, 166, 40, 255);
                return;

            case 1:
                body.color = Color.red;
                return;
        }

        

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
