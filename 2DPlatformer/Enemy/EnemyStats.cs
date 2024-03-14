using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStats : MonoBehaviour
{
    private int _healthPoint = 50;
    private int _damage = 10;

    public int Damage => _damage;
    public int Health => _healthPoint;

    public event UnityAction HealthChanging;

    public void GetDamage(int damage)
    {
        if (damage <= 0)
            return;

        _healthPoint -= damage;

        if (_healthPoint < 0)
            _healthPoint = 0;

        HealthChanging?.Invoke();
    }
}
