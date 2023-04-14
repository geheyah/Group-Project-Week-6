using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] public Rigidbody2D Player;
    [SerializeField] private SpriteRenderer spriteRenderer;

    //Health
    public float maxHealth = 10f;
    public float health = 10f;

    //Mana
    public float maxMana = 10f;
    public float mana = 10f;

    // Variables for Sprint
    private float SprintM = 2f;
    public bool Sprint = false;
    public float Speed = 10.0f;

    // Variables for Jump and DoubleJump
    private float jumpForce = 5f;
    public int jumpCount = 0;

    //For flipping the player
    private float moveDirection;
    private float moveSpeed = 5f;

    //For the camera to follow the player
    public Transform cameraTransform;


    //For Attacks
    public GameObject meleeAttackPrefab;
    private Transform attackSpawnPoint;
    public SlashScript slash;
    private bool isFacingRight = true;

    //For Magic
    public GameObject magicAttackPrefab;
    public MagicScript magic;


    //Settings
    private bool isEscaped = false;


    private bool[] Cooldowns = { false, false };
    private float[] CooldownDuration = { 1f, 3f };

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //Health
        if (health == 0)
        {
            Debug.Log("You died!");

            SceneManager.LoadScene("Die");
        }

        // Player Movement
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        Vector2 movementInput = new Vector2(horizontal, vertical);

        // Sprint Input
        Sprint = Input.GetKey(KeyCode.LeftShift);
        Move(movementInput);

        // Function for Sprint
        void Move(Vector2 input)
        {
            float ifSprinting = 1.0f;
            if (Sprint)
            {
                ifSprinting = SprintM;
            }

            var transform1 = transform;
            var position1 = transform1.position;
            Vector3 position = new Vector3(Speed * input.x, Speed * input.y, position1.z);
            position1 = position1 + (position * (Time.deltaTime * ifSprinting));
            transform1.position = position1;
        }

        //Flips the Player        

        moveDirection = Input.GetAxisRaw("Horizontal");
        Flip();

        void Flip()
        {
            Player.velocity = new Vector2(moveDirection * moveSpeed, Player.velocity.y);

            if (moveDirection > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (moveDirection < 0)
            {
                spriteRenderer.flipX = true;
            }
        }

        // Double Jump
        
        if (Input.GetKeyDown(KeyCode.W) && jumpCount < 2)
        {
            Player.AddForce(Vector3.up * jumpForce, (ForceMode2D)ForceMode.Impulse);
            jumpCount++;
        }

        //Camera Follow
        cameraTransform.position = new Vector3(transform.position.x, transform.position.y, cameraTransform.position.z);
        float smoothTime = 0.3f;
        Vector3 velocity = Vector3.zero;
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, cameraTransform.position.z);
        cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, targetPosition, ref velocity, smoothTime);

        //Attack
        if (Input.GetKeyDown(KeyCode.Mouse0) && !Cooldowns[0])
        {
            GameObject meleeAttackInstance = Instantiate(meleeAttackPrefab,transform.position + new Vector3(spriteRenderer.flipX ? -1f : 1f, 0, 0), Quaternion.identity);
            //StartCoroutine(SetCooldown(0));
            Destroy(meleeAttackInstance, 0.1f);
        }

        //Magic
        if (Input.GetKeyDown(KeyCode.Mouse1) && !Cooldowns[1])
        {
            GameObject Magic = Instantiate(magicAttackPrefab, transform.position + new Vector3(spriteRenderer.flipX ? -1f : 1f, 0,  0), Quaternion.identity);
            mana--;

            StartCoroutine(SetCooldown(0));
            Destroy(Magic, 2);
        }

        //Access Settings
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isEscaped)
            {
                isEscaped = true;
                SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
                Time.timeScale = 0f;
            }
            else
            {
                isEscaped = false;
                SceneManager.UnloadSceneAsync("Settings");
                Time.timeScale = 1f;
            }
        }
    }

    private IEnumerator SetCooldown(int index)
    {
        float duration = CooldownDuration[index];

        Cooldowns[index] = true;
        yield return new WaitForSeconds(duration);
        Cooldowns[index] = false;
    }

    // Double Jump
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }

}
