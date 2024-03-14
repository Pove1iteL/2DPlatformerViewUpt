using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthSlider : MonoBehaviour
{
    [SerializeField] private GameObject _cheracterStats;
    [SerializeField] private Slider _sliderSmoothHealt;

    [SerializeField] private float _currentVelocity = 0;
    [SerializeField] private float _smoothTime = 100;
    [SerializeField] private float _waitTime = .5f;

    private EnemyStats _enemyStats;
    private PlayerStats _playerStats;

    private void Awake()
    {
        if (_cheracterStats.TryGetComponent(out EnemyStats enemyStats))
        {
            _enemyStats = enemyStats;
            SetStartHealth(_enemyStats);
        }
        
        if (_cheracterStats.TryGetComponent(out PlayerStats playerStats))
        {
            _playerStats = playerStats;
            SetStartHealth(_playerStats);
        }
    }

    private void OnEnable()
    {
        if (_enemyStats != null)
        {
            _enemyStats.HealthChanging += StartEnemyHealthChange;
        }

        if (_playerStats != null)
        {
            _playerStats.HealthChanging += StartPlayerHealthChangea;
        }
    }

    private void OnDisable()
    {
        if (_enemyStats != null)
        {
            _enemyStats.HealthChanging -= StartEnemyHealthChange;
        }

        if (_playerStats != null)
        {
            _playerStats.HealthChanging -= StartPlayerHealthChangea;
        }
    }

    private void StartEnemyHealthChange()
    {
        if (_enemyStats == null)
        {
            return;
        }

        StartCoroutine(ChangeSlider(_enemyStats));

        StopCoroutine(ChangeSlider(_enemyStats));
    }

    private void StartPlayerHealthChangea()
    {
        if (_playerStats == null)
        {
            return;
        }

        StartCoroutine(ChangeSlider(_playerStats));

        StopCoroutine(ChangeSlider(_playerStats));
    }

    private IEnumerator ChangeSlider(EnemyStats enemyStats)
    {
        while (_sliderSmoothHealt.value != enemyStats.Health)
        {
            _sliderSmoothHealt.value = Mathf.SmoothDamp(_sliderSmoothHealt.value, enemyStats.Health, ref _currentVelocity, _smoothTime * Time.deltaTime);
            yield return new WaitForSeconds(_waitTime);
        }
    }

    private IEnumerator ChangeSlider(PlayerStats playerStats)
    {
        while (_sliderSmoothHealt.value != playerStats.HealthPoint)
        {
            _sliderSmoothHealt.value = Mathf.SmoothDamp(_sliderSmoothHealt.value, playerStats.HealthPoint, ref _currentVelocity, _smoothTime * Time.deltaTime);
            yield return new WaitForSeconds(_waitTime);

        }
    }

    private void SetStartHealth(EnemyStats enemyStats)
    {
        _sliderSmoothHealt.maxValue = enemyStats.Health;
        _sliderSmoothHealt.value = enemyStats.Health;
    }

    private void SetStartHealth(PlayerStats playerStats)
    {
        _sliderSmoothHealt.maxValue = playerStats.HealthPoint;
        _sliderSmoothHealt.value = playerStats.HealthPoint;
    }
}
