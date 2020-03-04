
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    Image HealthBar;
    PlayerHealthManager PlayerHealthScript;

    float fill;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = gameObject.GetComponent<Image>();
        PlayerHealthScript = FindObjectOfType<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        fill = PlayerHealthScript.Currenthealth / PlayerHealthScript.maxHealth;
        HealthBar.fillAmount = fill;
    }
}
