using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float damageDone = 10f;
    public float totalHealth = 100f;
    public float moveRate = 10f;

    public Player playerHealth;
    
    // Start is called before the first frame update
    public void Start()
    {
        // playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
