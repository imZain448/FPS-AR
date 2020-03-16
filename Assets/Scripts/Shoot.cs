
using System;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public GameObject ImpactEffect;
    CharacterControllerScript ccScript;
    public float Damage = 10f;
    public float range = 100f;

    public float recoilUp = 2f;
    public float recoilDown = 2f;

    public float enemiesKilled;

    public Camera FPSCam;
    public Vector3 damageEffectOffset = new Vector3(0, 0, 0.6f);
    public AudioClip MuzzleSound;
    public AudioSource PlayShoot;

    public GameObject ExplosionEffect;

    private void Start()
    {
        enemiesKilled = 0f;
        ccScript = FindObjectOfType<CharacterControllerScript>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void shoot()
    {
        muzzleFlash.Play();
        _addRecoil();
        PlayShoot.GetComponent<AudioSource>().PlayOneShot(MuzzleSound);

        RaycastHit hit;
        if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(Damage);
                if(enemy.dead)
                {
                    GameObject Explosion = Instantiate(ExplosionEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    enemiesKilled += 1;
                    Destroy(Explosion, 2f);
                }
            }
            else if(hit.transform.gameObject.CompareTag("enemyShooter"))
            {
                Destroy(hit.transform.gameObject);
            }
            GameObject impact = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impact, 2f);
        }
    }

    private void _addRecoil()
    {
        ccScript.upRecoil += recoilUp;
        ccScript.sideRecoil += recoilDown;
    }
}
