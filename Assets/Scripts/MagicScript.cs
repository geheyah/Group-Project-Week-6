using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicScript : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    [SerializeField] private GameObject Magic;
    public SpriteRenderer MagicRenderer;
    private SpriteRenderer playerSpriteRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MagicRenderer = GetComponent<SpriteRenderer>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer>();

            rb.velocity = (playerSprite.flipX ? Vector3.left : Vector3.right) * speed;
            MagicRenderer.flipX = playerSprite.flipX;
        }
    }   

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(Magic);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(Magic, 0.1f);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(Magic,0.3f);
        }

    }
}
