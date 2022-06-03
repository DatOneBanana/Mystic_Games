using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, ICustomerShop
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public int maxMana = 100;
    public int currentMana;
    public ManaBar manaBar;

    public int currency = 0;

    public int killCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        currentMana = maxMana;
        //manaBar.SetMaxMana(maxMana);
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentHealth != 0)
        {
            TakeDamage(20);
            Debug.Log(currentHealth);
        }

        if (Input.GetKeyDown(KeyCode.G) && currentMana != 0)
        {
            //Debug.Log("I pressed G");
            UseMana(10);
            Debug.Log(currentMana);
        }
        //Debug.Log(playerStatus.currHealth);
    }

    void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
    }

    void UseMana(int m)
    {
        currentMana -= m;
        manaBar.SetMana(currentMana);
    }

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {  
            killCount++;
            LevelLoader.instance.DisableSceneUI();
            LevelLoader.instance.LoadLevel("BattleArena", other.gameObject);

            yield return new WaitForSeconds(2f);

            Destroy(other.gameObject);
        }
        else if(other.tag == "Start Text")
        {
            other.gameObject.GetComponent<StartText>().EnableText();
        }
        else if(other.tag == "Girl")
        {
            other.gameObject.GetComponent<GirlScript>().EnableText();
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Invisible Wall")
        {
            if(killCount < 10)
            {
                other.gameObject.GetComponent<WallScript>().EnableText(killCount);
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Invisible Wall")
        {
            if(killCount < 10)
            {
                other.gameObject.GetComponent<WallScript>().DisableText();
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Start Text")
        {
            other.gameObject.GetComponent<StartText>().DisableText();
        }
        else if(other.tag == "Girl")
        {
            other.gameObject.GetComponent<GirlScript>().DisableText();
        }
    }
    
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this, this.GetComponent<CharacterCombatStatus>());
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        currentHealth = data.health;
        healthBar.SetHealth(currentHealth);
        currentMana = data.mana;
        this.GetComponent<CharacterCombatStatus>().currHealth = data.combatHealth;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public void BoughtItem(Weapons.ItemType itemType)
    {
        Debug.Log("Bought item" + itemType);
    }
}
