using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashScript : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;
    [SerializeField] private GameObject Slash;
    public SpriteRenderer SlashRenderer;

    private SpriteRenderer playerSpriteRenderer;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SlashRenderer = GetComponent<SpriteRenderer>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) 
        {
            SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer>();

            rb.velocity = (playerSprite.flipX ? Vector3.left : Vector3.right) * speed;
            SlashRenderer.flipX = playerSprite.flipX;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(Slash);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(Slash, 0.1f);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(Slash,0.1f);
        }
    }
}
