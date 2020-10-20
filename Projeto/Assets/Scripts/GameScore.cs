using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public static GameScore instance;
    public Text scoreTextUI;
    public int score;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            UpdateScoreTextUI();
        }
    }

    void Start()
    {
        scoreTextUI = GetComponent<Text>();
    }

    //singleton
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //persiste entre as cenas
        }
    }

    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:0000}", score);
        scoreTextUI.text = scoreStr;
    }
}
