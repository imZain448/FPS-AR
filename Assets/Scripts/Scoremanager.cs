
using UnityEngine;
using UnityEngine.UI;

public class Scoremanager : MonoBehaviour
{
    Shoot shootScript;
    public float scorePoints = 10f;
    public float score;

    public Text Scoretext;
    // Start is called before the first frame update
    void Start()
    {
        shootScript = FindObjectOfType<Shoot>();
        score = 0f;
        Scoretext = gameObject.GetComponent<Text>();
        Scoretext.text = "0000000";
    }

    // Update is called once per frame
    void Update()
    {
        score = scorePoints * shootScript.enemiesKilled;
        Scoretext.text = score.ToString();
    }
}
