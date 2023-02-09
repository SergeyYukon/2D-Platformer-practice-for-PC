using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : GameManager
{
    [SerializeField] private GameObject effector;
    [SerializeField] private GameObject loot;
    private Animator anim;
    private BoxCollider2D [] colls;
    private const float effectorTime = 0.2f;
    private bool isOpen;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        colls = GetComponents<BoxCollider2D>();
        EventController.UseButtonPressedEvent += Open;
    }

    private void Open()
    {
        if (isOpen)
        {
            colls[1].enabled = false;
            colls[2].enabled = true;
            anim.SetTrigger("_open");
            effector.SetActive(true);
            loot.SetActive(true);
            StartCoroutine("offEffector");
            EventController.GetChest();
        }
    }

    private IEnumerator offEffector()
    {
        yield return new WaitForSeconds(effectorTime);
        effector.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer) isOpen = true; 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer) isOpen = false;
    }
}
