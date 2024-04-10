using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBehavior : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    private float cooldownTimer = Mathf.Infinity;

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //attck only when player in sight ?
        if (PlayerInSight())
        {

        }
        if (cooldownTimer >= attackCooldown)
        {
            //attack
        }
    }

    private bool PlayerInSight()
    {
        return false;
    }
}
