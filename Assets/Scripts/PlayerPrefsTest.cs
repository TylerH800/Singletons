using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsTest : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI loadstext;
    int score = 0;
    int timesLoaded = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        timesLoaded = PlayerPrefs.GetInt("TimesLoaded", 0);
        timesLoaded++;
        PlayerPrefs.SetInt("TimesLoaded", timesLoaded);
        loadstext.text = "Times loaded: " + PlayerPrefs.GetInt("TimesLoaded");
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Score: " + score + "         HighScore: " + PlayerPrefs.GetInt("HighScore", 0); 
    }

    public void ChangeScore(int change)
    {
        score += change;
        if (score < 0)
        {
            score = 0;
        }

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(3);
    }
    
}
