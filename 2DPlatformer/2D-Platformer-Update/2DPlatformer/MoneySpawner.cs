using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private Coin _moneyPrefab;
    [SerializeField] private Transform _spawnPoint;

    private List<Transform> _points;

    private void Start()
    {
        _points = new List<Transform>(_spawnPoint.childCount);

        for (int i = 0; i < _spawnPoint.childCount; i++)
        {
            _points.Add(_spawnPoint.GetChild(i));
        }

        for (int i = 0; i < _points.Count; i++)
        {
            var spawnPoint = Instantiate(_moneyPrefab, _points[i].position, Quaternion.identity);
        }
    }
}
