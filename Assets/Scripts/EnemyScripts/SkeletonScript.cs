using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonScript : MonoBehaviour
{
    public PlayerScript player;
    public GameObject Enemy2;
    [SerializeField] private GameObject Slash;
    [SerializeField] private GameObject Magic;

    //Movement
    public float speed = 2.0f;
    public float distance = 3.0f;
    private Vector3 startPosition;
    private float direction = 1.0f;
    //Health
    public float skellyHealth = 3f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.health--;
        }
        else if (collision.gameObject.tag == "Slash")
        {
            skellyHealth--;
        }
        else if (collision.gameObject.tag == "Magic")
        {
            skellyHealth--;
        }
    }

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (skellyHealth == 0)
        {
            Destroy(Enemy2);
        }

        //Enemy Movement
        Vector3 newPosition = transform.position + (Vector3.right * speed * direction * Time.deltaTime);

        if (Mathf.Abs(newPosition.x - startPosition.x) >= distance)
        {
            direction *= -1;
        }
        transform.position = newPosition;
    }
}
