using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Text _visualHealthPointPlayer;
    [SerializeField] private Slider _sliderHealthDynamic;
    [SerializeField] private Slider _sliderSmoothHealthPlayer;
    [SerializeField] private Slider _sliderSmoothHealthEnemy;

    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private EnemyStats _enemyrStats;

    [SerializeField] private float _currentVelocity = 0;
    [SerializeField] private float _smoothTime = 100;

    private void Awake()
    {
        _sliderHealthDynamic.maxValue = _playerStats.MaxHealthPoint;
        _sliderSmoothHealthPlayer.maxValue = _playerStats.MaxHealthPoint;
        _sliderSmoothHealthEnemy.maxValue = _enemyrStats.Health;
    }

    private void Update()
    {
        _visualHealthPointPlayer.text = $"{_playerStats.HealthPoint}/{_playerStats.MaxHealthPoint}";

        _sliderHealthDynamic.value = _playerStats.HealthPoint;

        _sliderSmoothHealthPlayer.value = Mathf.SmoothDamp(_sliderSmoothHealthPlayer.value, _playerStats.HealthPoint, ref _currentVelocity, _smoothTime * Time.deltaTime);
        _sliderSmoothHealthEnemy.value = Mathf.SmoothDamp(_sliderSmoothHealthEnemy.value, _enemyrStats.Health, ref _currentVelocity, _smoothTime * Time.deltaTime);
    }

    public void TakeDamage()
    {
        int damage = 16;
        _playerStats.GetDamage(damage);
    }

    public void GetHeal()
    {
        int heal = 10;
        _playerStats.TakeHeal(heal);
    }
}
