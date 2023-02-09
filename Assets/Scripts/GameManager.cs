using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    protected const int playerLayer = 6;
    protected const int enemyLayer = 8;
    protected static bool isPause;
    protected static bool isPlayerDeath;
    protected static bool isPlayerWon;
    protected static bool isCutScene;

    private void Start()
    {
        isPause = false;
        isPlayerDeath = false;
        isPlayerWon = false;
        isCutScene = false;
       // PlayerPrefs.DeleteAll();
    }

    public void Restart()
    {
        EventController.ResetEvents();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        EventController.ResetEvents();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ToMenu()
    {
        EventController.ResetEvents();
        SceneManager.LoadScene(0);
    }

    public void PausePlay()
    {
        isPause = !isPause;
        if (isPause) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
