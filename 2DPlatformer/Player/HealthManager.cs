using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Text _visualHealthPointPlayer;
    [SerializeField] private Slider _sliderHealthDynamic;

    [SerializeField] private PlayerStats _playerStats;

    private void Awake()
    {
        _sliderHealthDynamic.maxValue = _playerStats.MaxHealthPoint;
    }

    private void Update()
    {
        _visualHealthPointPlayer.text = $"{_playerStats.HealthPoint}/{_playerStats.MaxHealthPoint}";

        _sliderHealthDynamic.value = _playerStats.HealthPoint;

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
