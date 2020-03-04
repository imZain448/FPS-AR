using System.Collections.Generic;
using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50;
    public float AttackRange = 20f;
    public GameObject spell;
    public Vector3 BlasterOffset = new Vector3(0, 0, 0.3f);
    public float force = 2f;
    public float rotationSpeed = 5f;

    public float maxTime = 2.06f;

    [HideInInspector]
    public bool dead = false;

    [HideInInspector]
    public float StartTime;

    public AudioClip ExplosionSound;

    private void Start()
    {
        StartTime = 0f;
    }

    public void ResetTimer()
    {
        StartTime = 0f;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        dead = true;
        gameObject.GetComponentInParent<AudioSource>().PlayOneShot(ExplosionSound);
        Destroy(transform.parent.gameObject) ;
    }

    private void Update()
    {
        StartTime += 1 * Time.deltaTime;

        float step = force * Time.deltaTime;

        var distance = (float)Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if(distance <= AttackRange)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("ShooterCollider").transform.position);
            if (StartTime >= maxTime)
            {
                ResetTimer();

                // attack function
                GameObject Shooter = Instantiate(spell, transform.position - BlasterOffset, transform.rotation);
                Shooter.transform.position = Vector3.MoveTowards(Shooter.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, step);
                
            }
        }
        
    }

}
