using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySmothHealth : MonoBehaviour
{
    [SerializeField] private EnemyStats _enemyrStats;
    [SerializeField] private Slider _sliderSmoothHealthEnemy;

    [SerializeField] private float _currentVelocity = 0;
    [SerializeField] private float _smoothTime = 100;

    private void Awake()
    {
        _sliderSmoothHealthEnemy.maxValue = _enemyrStats.Health;
    }

    private void Update()
    {
        if (_sliderSmoothHealthEnemy.value != _enemyrStats.Health)
        {
            _sliderSmoothHealthEnemy.value = Mathf.SmoothDamp(_sliderSmoothHealthEnemy.value, _enemyrStats.Health, ref _currentVelocity, _smoothTime * Time.deltaTime);
        }
    }
}
