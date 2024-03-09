using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private Text _visualMoney; 

    private int _countMoney;

    private void Update()
    {
        _visualMoney.text = "Money: " + _countMoney.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Coin>(out Coin coin))
        {
            _countMoney += coin.Money;
        }
    }
}
