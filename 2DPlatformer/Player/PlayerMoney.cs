using UnityEngine;
using UnityEngine.Events;

public class PlayerMoney : MonoBehaviour
{
    private int _countMoney;

    public int CountMoney => _countMoney;

    public event UnityAction MoneyChanging;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _countMoney += coin.Money;
            MoneyChanging?.Invoke();
        }
    }
}
