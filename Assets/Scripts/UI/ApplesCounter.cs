using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ApplesCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text applesText;
    private int allApples;

    public int AllApples { get => allApples; }

    private void Start()
    {
        allApples = PlayerPrefs.GetInt("allApples"); 
        applesText.text = allApples.ToString();
    }

    public void GetApples(int apples)
    {
        allApples += apples;
        applesText.text = allApples.ToString();
    }

    public void SpentApples()
    {
        allApples--;
        applesText.text = allApples.ToString();
    }

    public void SaveApples()
    {
        PlayerPrefs.SetInt("allApples", allApples);
    }
}
