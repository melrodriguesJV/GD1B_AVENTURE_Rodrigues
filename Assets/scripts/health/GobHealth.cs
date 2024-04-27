using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float startingGobHealth;
    [SerializeField] private float currentGobHealth;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentGobHealth = startingGobHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void GobTakeDamage(float _damage)
    {

    }
}
