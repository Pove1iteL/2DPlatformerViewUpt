using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    private void OnValidate()
    {
        _playerStats ??= GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HealPotion>(out HealPotion healingPotion))
        {
            if ( _playerStats.HealthPoint < _playerStats.MaxHealthPoint)
            {
                _playerStats.TakeHeal(healingPotion.Healing);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
        {
            _playerStats.GetDamage(enemyStats.Damage);
        }
    }
}
