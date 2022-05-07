using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public TMP_Text name;
    public Slider healthSlider;

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
}
