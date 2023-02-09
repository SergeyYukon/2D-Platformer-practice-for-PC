using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : GameManager
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float fireHorizontal;
    [SerializeField] private float fireUp;
    [SerializeField] private Transform firePoint;
    private ApplesCounter applesCounter;
    private bool leftDirection;

    private void Awake()
    {
        applesCounter = gameObject.GetComponent<ApplesCounter>();
        EventController.Fire2ButtonPressedEvent += Shoot;
        EventController.LeftDirectionEvent += Left;
        EventController.RightDirectionEvent += Right;
    }

    private void Shoot()
    {
        if (applesCounter.AllApples > 0)
        {
            GameObject currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
            Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();
            Destroy(currentBullet, 3);

            if (!leftDirection)
                currentBulletVelocity.velocity = new Vector2(fireHorizontal, fireUp);
            else
                currentBulletVelocity.velocity = new Vector2(-fireHorizontal, fireUp);

            applesCounter.SpentApples();
        }
    }

    private void Left()
    {
        leftDirection = true;
    }

    private void Right()
    {
        leftDirection = false;
    }
}
