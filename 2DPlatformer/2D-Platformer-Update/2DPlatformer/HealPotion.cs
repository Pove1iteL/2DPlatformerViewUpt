using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPotion : MonoBehaviour
{
    private int _healingBuff = 18;

    public int Healing => _healingBuff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            if (playerStats.HealthPoint < playerStats.MaxHealthPoint)
            {
                Destroy(gameObject);
            }
        }
    }
}
