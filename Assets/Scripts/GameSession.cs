using UnityEngine;

public class GameSession : MonoBehaviour
{
     [SerializeField]int score = 0;


    public int Score { get => score; set => score = value; }



    // Start is called before the first frame update
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numbersOfGameSessions = FindObjectsOfType<GameSession>().Length;
        if ( numbersOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
   
    public void AddToScore(int value)
    {
        score += value;
    }
    public void ResetGame()
    {
        FindObjectOfType<LevelLoader>().CurrentLevel = 0;
        Destroy(gameObject);
    }
   
}
