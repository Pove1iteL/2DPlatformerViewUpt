using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Slider _sliderSmoothHealthPlayer;
    [SerializeField] private PlayerStats _playerStats;

    [SerializeField] private float _currentVelocity = 0;
    [SerializeField] private float _smoothTime = 100;

    private void Awake()
    {
        _sliderSmoothHealthPlayer.maxValue = _playerStats.MaxHealthPoint;
    }

    private void Update()
    {
        if (_sliderSmoothHealthPlayer.value != _playerStats.HealthPoint)
        {
            _sliderSmoothHealthPlayer.value = Mathf.SmoothDamp(_sliderSmoothHealthPlayer.value, _playerStats.HealthPoint, ref _currentVelocity, _smoothTime * Time.deltaTime);
        }
    }
}
