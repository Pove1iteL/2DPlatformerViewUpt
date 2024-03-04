using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    private int _maxHealthPoint = 100;
    private int _healthPoint = 100;
    private int _damage = 7;

    public int MaxHealthPoint => _maxHealthPoint;
    public int HealthPoint => _healthPoint;
    public int Damage => _damage;

    public void GetDamage( int damage)
    {
        _healthPoint -= damage;

        if (_healthPoint < 0)
            _healthPoint = 0;
    }

    public void TakeHeal(int healingPotion)
    {        
        _healthPoint += healingPotion;

        if (_healthPoint > _maxHealthPoint)
            _healthPoint = _maxHealthPoint;
    }
}
