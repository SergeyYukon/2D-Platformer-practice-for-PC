using System.Collections;
using UnityEngine;
using TMPro;

public class UI : GameManager
{
    [SerializeField] private int levelCoins;
    [SerializeField] private int levelEnemies;
    [SerializeField] private int levelChests;
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text enemiesText;
    [SerializeField] private TMP_Text chestsText;
    [SerializeField] private CoinsCounter coinsCounter;
    [SerializeField] private ApplesCounter applesCounter;
    private int currentEnemy;
    private int currentChest;
    private const int canvasMenu = 0;
    private const int canvasDefeat = 1;
    private const int canvasWon = 2;

    private void Awake()
    {
        coinsCounter = coinsCounter.GetComponent<CoinsCounter>();
        applesCounter = applesCounter.GetComponent<ApplesCounter>();
        EventController.GetChestEvent += ChestCount;
        EventController.EnemyDeathEvent += EnemyCount; 
        EventController.MenuButtonPressedEvent += CanvasMenu;
        EventController.PlayerDeathEvent += CanvasDefeat;
    }

    public void CanvasMenu()
    {
        if (!isPlayerDeath && !isPlayerWon)
        {
            PausePlay();
            if (isPause)
            {
                transform.GetChild(canvasMenu).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(canvasMenu).gameObject.SetActive(false);
            }
        }
    }

    public void FinishLevel()
    {
        isPlayerWon = true;
        PausePlay();
        coinsText.text = $"{coinsCounter.CurrentCoins} / {levelCoins}";
        enemiesText.text = $"{currentEnemy} / {levelEnemies}";
        chestsText.text = $"{currentChest} / {levelChests}";
        transform.GetChild(canvasWon).gameObject.SetActive(true);
    }

    public void SaveCounter()
    {
        coinsCounter.SaveCoins();
        applesCounter.SaveApples();
    }

    private void EnemyCount()
    {
        currentEnemy++;
    }

    private void ChestCount()
    {
        currentChest++;
    }

    private void CanvasDefeat(float lateDeathTime)
    {
        StartCoroutine(WaitDeathTime(lateDeathTime));
    }

    IEnumerator WaitDeathTime(float lateDeathTime)
    {
        yield return new WaitForSeconds(lateDeathTime);
        PausePlay();
        transform.GetChild(canvasDefeat).gameObject.SetActive(true);
    }

}
