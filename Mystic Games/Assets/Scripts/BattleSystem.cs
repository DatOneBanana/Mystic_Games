using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public enum BattleState {START, PLAYERTURN, ENEMYTURN, VICTORY, DEFEAT}

public class BattleSystem : MonoBehaviour
{
    public BattleState state;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleLocation;
    public Transform enemyBattleLocation;

    CharacterCombatStatus playerStat;
    CharacterCombatStatus enemyStat;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public TMP_Text dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject player = Instantiate(playerPrefab, playerBattleLocation);
        playerStat = player.GetComponent<CharacterCombatStatus>();

        GameObject enemy = Instantiate(enemyPrefab, enemyBattleLocation);
        enemyStat = enemy.GetComponent<CharacterCombatStatus>();

        dialogueText.text = enemyStat.charName + " approaches for battle.";

        playerHUD.SetHUD(playerStat);
        enemyHUD.SetHUD(enemyStat);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack(Type type)
    {
        dialogueText.text = "You attack " + enemyStat.charName;
        bool isDead = enemyStat.TakeDamage(playerStat.damage, type);
        enemyHUD.SetHealth(enemyStat.currHealth);

        yield return new WaitForSeconds(2f);
        if(enemyStat.TypeAdvantage(type))
        {
            dialogueText.text = type.ToString() + " is powerful against the enemy.";
        }
        else if(enemyStat.TypeDisadvantage(type))
        {
            dialogueText.text = type.ToString() + " is weak against the enemy.";
        }
        yield return new WaitForSeconds(2f);

        if(isDead)
        {
            state = BattleState.VICTORY;
            EndBattle();
        }
        else
        {
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = enemyStat.charName + " attacks you!";

        bool isDead = playerStat.TakeDamage(enemyStat.damage, enemyStat.type);
        playerHUD.SetHealth(playerStat.currHealth);

        yield return new WaitForSeconds(3f);

        if(isDead)
        {
            state = BattleState.DEFEAT;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if(state == BattleState.VICTORY) 
        {
            dialogueText.text = "Victory!";
            LevelLoader.instance.LoadLevel("Brandon");
        }
        else if(state == BattleState.DEFEAT) 
        {
            dialogueText.text = "Defeat!";
        }
    }

    void PlayerTurn()
    {
        dialogueText.text = "Pick an action: ";
    }

    public void OnAttackButton()
    {
        //call battlehud function to set buttons active
        Debug.Log("calling OpenMenu");
        playerHUD.OpenMenu();
    }

    public void AttackSelected()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        state = BattleState.ENEMYTURN;
        string x = EventSystem.current.currentSelectedGameObject.name;
        Type type = Type.Water;

        if(x == "Water") 
        {
            type = Type.Water;
        }
        else if(x == "Fire")
        {
            type = Type.Fire;
        }
        else if(x == "Wood")
        {
            type = Type.Wood;
        }
        else if(x == "Earth")
        {
            type = Type.Earth;
        }
        else if(x == "Metal")
        {
            type = Type.Metal;
        }
        playerHUD.OpenMenu();
        StartCoroutine(PlayerAttack(type));
    }
}
