
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Image GameOver;
    public GameObject Health;
    public Image CrossHair;
    public GameObject DisplayScore;
    public Text score;
    public Text mainScore;

    PlayerHealthManager PlayerHealthScript;
    Scoremanager ScoreScript;
    Enemy enemyScript;
    CharacterControllerScript ccScript;
    Shoot shootScript;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealthScript = FindObjectOfType<PlayerHealthManager>();
        ScoreScript = FindObjectOfType<Scoremanager>();
        enemyScript = FindObjectOfType<Enemy>();
        ccScript = FindObjectOfType<CharacterControllerScript>();
        shootScript = FindObjectOfType<Shoot>();
        GameOver.enabled = false;
        DisplayScore.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHealthScript.IsDead)
        {
            GameOver.enabled = true;
            DisplayScore.SetActive(true);
            score.text = ScoreScript.score.ToString();
            Health.SetActive(false);
            CrossHair.enabled = false;
            mainScore.enabled = false;
            enemyScript.enabled = false;
            ccScript.enabled = false;
            shootScript.enabled = false;
        }
    }
}
