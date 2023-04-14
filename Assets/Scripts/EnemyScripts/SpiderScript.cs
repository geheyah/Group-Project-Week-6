using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour
{
    public PlayerScript player;
    public GameObject Enemy3;
    [SerializeField] private GameObject Slash;
    [SerializeField] private GameObject Magic;

    //Movement
    private float speed = 2.0f;
    private float distance = 1.0f;
    private Vector3 startPosition;
    private float direction = 1.0f;
    //Health
    public float spiderHealth = 3f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.health--;
        }
        else if (collision.gameObject.tag == "Slash")
        {
            spiderHealth--;
        }
        else if (collision.gameObject.tag == "Magic")
        {
            spiderHealth--;
        }
    }

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (spiderHealth == 0)
        {
            Destroy(Enemy3);
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
