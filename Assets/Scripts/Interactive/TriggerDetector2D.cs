using UnityEngine;
using UnityEngine.Events;

public class TriggerDetector2D : GameManager
{
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
}
