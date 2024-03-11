using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private Coin _moneyPrefab;
    [SerializeField] private Transform _spawnPoint;


    private void Start()
    {
        List<Transform> points = new List<Transform>(_spawnPoint.childCount);

        for (int i = 0; i < _spawnPoint.childCount; i++)
        {
            points.Add(_spawnPoint.GetChild(i));
        }

        for (int i = 0; i < points.Count; i++)
        {
            var spawnPoint = Instantiate(_moneyPrefab, points[i].position, Quaternion.identity);
        }
    }
}
