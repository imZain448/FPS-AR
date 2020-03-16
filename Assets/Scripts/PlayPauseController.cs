using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPauseController : MonoBehaviour
{
    public bool IsPaused;
    public GameObject PauseMenu;
    public Button fireButton;
    public Button pauseButton;
    public GameObject Health;
    public Text score;
    public Text scoreText;
    private void Start()
    {
        IsPaused = false;
    }

    public void Pause()
    {
        if(!IsPaused)
        {
            IsPaused = true;
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            scoreText.text = score.text;
            fireButton.enabled = false;
            pauseButton.enabled = false;
            Health.SetActive(false);
            score.enabled = false;
        }
    }

    public void resume()
    {
        if(IsPaused)
        {
            IsPaused = false;
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            fireButton.enabled = true;
            pauseButton.enabled = true;
            Health.SetActive(true);
            score.enabled = true;
        }
    }
}
