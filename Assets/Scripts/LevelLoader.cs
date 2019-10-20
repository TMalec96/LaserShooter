using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delay = 0.5f;
    [SerializeField] int numbersOfLevels = 1;
    private int _currentLevel = 0;

    public int CurrentLevel { get => _currentLevel; set => _currentLevel = value; }

    public  void LoadStartMenu()
    {
        //załadowanie pierwszego poziomu - menu start i dalsza inkrementacja
        SceneManager.LoadScene(++_currentLevel);
    }
    public  void LoadGameScreen()
    {
        //usunięcie obiektu sesji służącego do przechowywania wyniku gracza
        FindObjectOfType<GameSession>().ResetGame();

        SceneManager.LoadScene(++_currentLevel);
    }
    public void LoadGameOverScreen()
    {
        StartCoroutine(DelayLoading());
        _currentLevel = 0;
    }
    public void LoadNextLevel()
    {
        
    }

    public IEnumerator DelayLoading()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameOver");

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
