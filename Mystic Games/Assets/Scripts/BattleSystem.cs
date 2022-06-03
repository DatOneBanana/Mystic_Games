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

    private bool isPlayerDefending = false;
    private bool isEnemyDefending = false;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        if(GameObject.Find("Player") != null) {
            Debug.Log("Player found");
        }
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Instantiate(playerPrefab, playerBattleLocation);
        playerStat = player.GetComponent<CharacterCombatStatus>();

        GameObject enemy = Instantiate(LevelLoader.instance.tempEnemy, enemyBattleLocation);
        enemy.transform.localPosition = new Vector3(-1f, 0f, 1f);
        enemy.transform.localScale = new Vector3(8f, 8f, 8f);
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
        if(Random.Range(1,101) <= playerStat.missChance)
        {
            dialogueText.text = "You missed your attack!";

            yield return new WaitForSeconds(3f);

            EnemyTurn();
        }
        else
        {
            dialogueText.text = "You attack " + enemyStat.charName;
            bool isDead = false;

            if(isEnemyDefending)
            {
                isDead = enemyStat.TakeDamage(playerStat.damage / 2, type);
            }
            else
            {
                isDead = enemyStat.TakeDamage(playerStat.damage, type);
            }
            
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
                EnemyTurn();
            }
        }
    }

    //Randomly chooses attack (1), defense (2), or heal (3)
    public void EnemyTurn()
    {
        isEnemyDefending = false;
        int roll;
        if(enemyStat.currHealth < 0.5 * enemyStat.maxHealth)
        {
            roll = Random.Range(1,5);
            Debug.Log("Enemy chose: " + roll);
            if(roll == 1 || roll == 2)
            {
                StartCoroutine(EnemyAttack());
            }
            else if(roll == 3)
            {
                StartCoroutine(EnemyDefend());
            }
            else
            {
                StartCoroutine(EnemyHeal());
            }
        }
        else
        {
            roll = Random.Range(1,4);
            Debug.Log("Enemy chose: " + roll);
            if(roll == 1 || roll == 2)
            {
                StartCoroutine(EnemyAttack());
            }
            else
            {
                StartCoroutine(EnemyDefend());
            }
        }
    }

    IEnumerator EnemyAttack()
    {
        if(Random.Range(1,101) <= enemyStat.missChance)
        {
            dialogueText.text = enemyStat.charName + " missed their attack!";

            yield return new WaitForSeconds(3f);

            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else 
        {
            dialogueText.text = enemyStat.charName + " attacks you!";

            bool isDead = false;

            if(isPlayerDefending)
            {
                isDead = playerStat.TakeDamage(enemyStat.damage / 2, enemyStat.type);
            }
            else
            {
                isDead = playerStat.TakeDamage(enemyStat.damage, enemyStat.type);
            }
            
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
    }

    IEnumerator EnemyHeal()
    {
        dialogueText.text = enemyStat.charName + " heals themselves!";
        enemyStat.Heal();
        enemyHUD.SetHealth(enemyStat.currHealth);

        yield return new WaitForSeconds(4f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator EnemyDefend()
    {
        dialogueText.text = enemyStat.charName + " braces themselves for the next attack!";
        isEnemyDefending = true;

        yield return new WaitForSeconds(4f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void EndBattle()
    {
        if(state == BattleState.VICTORY) 
        {
            dialogueText.text = "Victory!";
            LevelLoader.instance.EnableSceneUI();
            LevelLoader.instance.UnloadLevel("BattleArena");
        }
        else if(state == BattleState.DEFEAT) 
        {
            dialogueText.text = "Defeat!";
            LevelLoader.instance.UnloadLevel("BattleArena");
            StartCoroutine(LevelLoader.instance.EnableGameOverMenu());
        }
    }

    void PlayerTurn()
    {
        isPlayerDefending = false;
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

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        state = BattleState.ENEMYTURN;
        StartCoroutine(PlayerHeal());
    }

    IEnumerator PlayerHeal()
    {
        dialogueText.text = "You heal yourself!";
        playerStat.Heal();
        playerHUD.SetHealth(playerStat.currHealth);

        yield return new WaitForSeconds(4f);

        EnemyTurn();
    }

    public void OnDefendButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        state = BattleState.ENEMYTURN;
        StartCoroutine(PlayerDefend());
    }

    IEnumerator PlayerDefend()
    {
        dialogueText.text = "You brace yourself for the next attack!";
        isPlayerDefending = true;

        yield return new WaitForSeconds(4f);

        EnemyTurn();
    }
}
