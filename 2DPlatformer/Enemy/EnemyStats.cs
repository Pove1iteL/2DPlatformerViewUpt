using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    private int _healthPoint = 50;
    private int _damage= 10;
    public int Damage => _damage;
    public int Health => _healthPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out PlayerStats playerStats))
        {
            _healthPoint -= playerStats.Damage;
        }
    }
}
