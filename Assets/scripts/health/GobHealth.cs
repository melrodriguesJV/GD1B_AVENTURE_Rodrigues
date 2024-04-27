using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GobHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float gobHealth;
    [SerializeField] private new GameObject gameObject;

    public void GobTakeDamage(float _damage)
    {
        gobHealth -= _damage;

        if (gobHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
