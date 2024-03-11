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
        if (collision.TryGetComponent(out HealPotion healPotion))
        {
            if ( _playerStats.HealthPoint < _playerStats.MaxHealthPoint)
            {
                _playerStats.TakeHeal(healPotion.Healing);
                Destroy(healPotion.gameObject);
            }
        }

        if (collision.TryGetComponent(out Coin coin))
        {
            Destroy(coin.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out EnemyStats enemyStats))
        {
            _playerStats.GetDamage(enemyStats.Damage);
        }
    }
}
