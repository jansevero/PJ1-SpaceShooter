using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGO;
    public GameObject scoreUITextGO;

    public Subject subject = new Subject();

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        GameOver,
    }
    GameManagerState GMState;

    //singleton
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); //persiste entre as cenas
        }
    }

    void UpdateGameManagerState()
    {
        switch(GMState)
        {
            case GameManagerState.Opening:

                playButton.SetActive(true);
                GameOverGO.SetActive(false);

                break;
            case GameManagerState.Gameplay:

                scoreUITextGO.GetComponent<GameScore>().Score = 0;
                playButton.SetActive(false);
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                playerShip.GetComponent<PlayerControl>().Init();
                break;

            case GameManagerState.GameOver:

                GameOverGO.SetActive(true);
                enemySpawner.GetComponent<EnemySpawner>().UnscheduleEnemySpawner();
                Invoke("ChangeToOpeningState", 5f);
                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    //play
    public void StartGamePlay()
    {
        GMState = GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    //gameover
    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }
}
