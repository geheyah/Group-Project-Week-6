using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCScript : MonoBehaviour
{
    public PlayerScript player;
    public GameObject NPCUI1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.mana = 10f;
            GameObject NPCUIOne = Instantiate(NPCUI1, transform.position, Quaternion.identity);
            Destroy(NPCUIOne, 2);
        }
    }
}
