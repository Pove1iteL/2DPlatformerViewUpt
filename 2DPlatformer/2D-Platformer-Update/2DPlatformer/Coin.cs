using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private int _money = 1;

    public int Money => _money;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMoney>(out PlayerMoney player))
        {
            Destroy(gameObject);
        }
    }
}
