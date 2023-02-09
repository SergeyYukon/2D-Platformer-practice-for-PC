using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CutScenesTrigger : GameManager
{
    [SerializeField] private Animator anim;
    [SerializeField] private TMP_Text showText;
    [SerializeField] private float waitNextText;
    [SerializeField] private string [] cutSceneText;
    [SerializeField] private UnityEvent TriggerEnter;
    [SerializeField] private UnityEvent TriggerExit;

    private void Awake()
    {
        anim = anim.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            TriggerEnter.Invoke();
            CutScene();
        }
    }

    private void CutScene()
    {
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        isCutScene = true;
        EventController.CutScene();
        anim.SetBool("isOn", true);
        for (int i = 0; i < cutSceneText.Length; i++)
        {
            yield return new WaitForSeconds(waitNextText / 2);
            showText.text = cutSceneText[i];
            yield return new WaitForSeconds(waitNextText);
        }
        showText.text = "";
        anim.SetBool("isOn", false);
        TriggerExit.Invoke();
        yield return new WaitForSeconds(waitNextText / 2);
        isCutScene = false;
        Destroy(gameObject);
    }
}
