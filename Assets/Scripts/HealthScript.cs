using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class HealthScript : MonoBehaviour
{
    public PlayerScript player;
    public Image Health;

    void Update()
    {
        Health.fillAmount = player.health / player.maxHealth;
    }
}
