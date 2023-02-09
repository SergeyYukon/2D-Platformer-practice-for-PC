using UnityEngine;

public class DeathTrigger : GameManager
{
    private const float lateDeathTime = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == playerLayer)
        {
            isPlayerDeath = true;
            EventController.PlayerDeath(lateDeathTime);
        }
    }
}
