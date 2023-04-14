using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Script : MonoBehaviour
{
    public PlayerScript player;
    public GameObject NPCUI2;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.health = 10f;
            GameObject NPCUITwo = Instantiate(NPCUI2, transform.position, Quaternion.identity);
            Debug.Log("Should be working");
            Destroy(NPCUITwo, 2);
        }
    }
}
