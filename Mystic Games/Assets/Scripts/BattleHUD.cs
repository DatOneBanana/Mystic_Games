using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    new public TMP_Text name;
    public Slider healthSlider;
    public GameObject attackMenu;
    private bool attackMenuOpen = false;

    public void SetHUD(CharacterCombatStatus status)
    {
        name.text = status.charName;
        healthSlider.maxValue = status.maxHealth;
        healthSlider.value = status.currHealth;
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
    }

    public void OpenMenu()
    {
        Debug.Log("menu called");
        Debug.Log(attackMenuOpen);
        if(attackMenuOpen) 
        {
            attackMenu.SetActive(false);
        }
        else
        {
            attackMenu.SetActive(true);
        }
        attackMenuOpen = !attackMenuOpen;
    }
}
