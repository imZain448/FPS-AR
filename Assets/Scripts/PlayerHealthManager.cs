using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    public float Currenthealth;
    public float PlayerDamage = 2f;
    public float maxHealth = 10f;

    public float PlayerHitTimer;

    public float CoolDownTime = 4f;

    [HideInInspector]
    public bool IsDead;
    // Start is called before the first frame update
    void Start()
    {
        Currenthealth = maxHealth;
        IsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(Currenthealth, 0, maxHealth);
        PlayerHitTimer += 1 * Time.deltaTime;
        if (Currenthealth <= 0)
        {
            IsDead = true;
        }
        if(PlayerHitTimer >= CoolDownTime)
        {
            _coolDown();
        }
    }

    private void _coolDown()
    {
        if (Currenthealth < maxHealth)
        {
            Currenthealth += PlayerDamage;
        }
        PlayerHitTimer = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemyShooter"))
        {
            Currenthealth -= PlayerDamage;
            PlayerHitTimer = 0;
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
        }
    }
}
