using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyStat.TakeDamage(playerStat.damage);
        enemyHUD.SetHealth(enemyStat.currHealth);

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

        bool isDead = playerStat.TakeDamage(enemyStat.damage);
        playerHUD.SetHealth(playerStat.currHealth);

        yield return new WaitForSeconds(2f);

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
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        state = BattleState.ENEMYTURN;
        StartCoroutine(PlayerAttack());
    }
}
