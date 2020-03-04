using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageOverlayScript : MonoBehaviour
{
    [SerializeField]
    PlayerHealthManager PlayerHealthScript;

    Image damageOverlay;

    public float red;
    public float green;
    public float blue;
    public float alpha;

    AudioSource HeartBeat;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealthScript = FindObjectOfType<PlayerHealthManager>();

        damageOverlay = gameObject.GetComponent<Image>();
        red = damageOverlay.color.r;
        green = damageOverlay.color.g;
        blue = damageOverlay.color.b;
        alpha = damageOverlay.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        alpha = 1 - (PlayerHealthScript.Currenthealth / PlayerHealthScript.maxHealth);
        Color currentColor = new Color(red, green, blue, alpha);

        gameObject.GetComponent<Image>().color = currentColor;
        HeartBeat = gameObject.GetComponent<AudioSource>();
        if (alpha > 0)
        {
            HeartBeat.volume = alpha;
        }
        else
        {
            HeartBeat.volume = 0;
        }
  
    }
}
