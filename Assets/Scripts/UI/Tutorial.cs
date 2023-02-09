using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Tutorial : GameManager
{
    [SerializeField] private TMP_Text showText;
    [SerializeField] private string tutorialText;
    [SerializeField] private UnityEvent TriggerEnter;
    [SerializeField] private UnityEvent TriggerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
            TriggerEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
            TriggerExit.Invoke();
    }

    public void ShowText()
    {
       showText.text = tutorialText;
    }
}
