using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject sword;
    [SerializeField] private Transform attackPoint;
    private float startAttackTime;
    private float stopAttackTime;
    private GameObject currentSword;

    public void Attacking(float stopTime)
    {
        startAttackTime = stopTime / 6 * 5;
        stopAttackTime = stopTime / 6;
        StartCoroutine("StartAttack");
    }

    public IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(startAttackTime);
        currentSword = Instantiate(sword, attackPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(stopAttackTime);
        Destroy(currentSword);
    }
}
