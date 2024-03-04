using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsView : MonoBehaviour
{
    [SerializeField] private Text _visualHealthPoint;
    private int _healthPoint = 100;
    private int _damage = 7;

    public int Damage => _damage;

    private void Update()
    {
        _visualHealthPoint.text = _healthPoint.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HealPotion>(out HealPotion healingPotion))
        {
            _healthPoint += healingPotion.Healing;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<EnemyStats>(out EnemyStats enemyStats))
        {
            _healthPoint -= enemyStats.Damage;
        }
    }
}
