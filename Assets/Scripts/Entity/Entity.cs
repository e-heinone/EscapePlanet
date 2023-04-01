using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Parent class for all objects and creatures
/// </summary>
public class Entity : MonoBehaviour
{
    [SerializeField]
    private float MaxHealth;
    private float CurrentHealth;
    [SerializeField]
    public float Height;

    [SerializeField]
    public Dictionary<Resources, int> Price = new Dictionary<Resources, int>();
    /// <summary>
    /// Is triggered when health reaches zero
    /// </summary>
    protected UnityAction Death;

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth < 0)
        {
            CurrentHealth = 0;
            Death();
        }
    }
}
