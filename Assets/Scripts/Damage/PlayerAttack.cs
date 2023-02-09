using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    [SerializeField] private Transform attackPoint;
    private float startTime;
    private float stopTime;
    private GameObject currentSword;

    public void Attacking(float stopAttackTime)
    {          
        startTime = stopAttackTime / 2;          
        stopTime = stopAttackTime / 2;          
        StartCoroutine("startAttack");
    }

    private IEnumerator startAttack()
    {
        yield return new WaitForSeconds(startTime);
        currentSword = Instantiate(sword, attackPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(stopTime);
        Destroy(currentSword);
    }
}
