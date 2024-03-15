using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private Coin _moneyPrefab;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        for (int i = 0; i < _spawnPoint.childCount; i++)
        {
            var spawnPoint = Instantiate(_moneyPrefab, _spawnPoint.GetChild(i).position, Quaternion.identity);
        }
    }
}
