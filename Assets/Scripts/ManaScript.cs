using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ManaScript : MonoBehaviour
{
    public PlayerScript player;
    public Image Mana;

    void Update()
    {
        Mana.fillAmount = player.mana / player.maxMana;
    }
}
