using UnityEngine;
using UnityEngine.UI;

public class TextView : MonoBehaviour
{
    [SerializeField] private Text _visualHealthPointPlayer;
    [SerializeField] private Text _visualMoney; 
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private PlayerMoney _playerMoney;

    private void Awake()
    {
        _visualHealthPointPlayer.text = _playerStats.HealthPoint.ToString();
        _visualMoney.text = "Money: " + _playerMoney.CountMoney.ToString();
    }

    private void OnEnable()
    {
        _playerStats.HealthChanging += HealthRender;
        _playerMoney.MoneyChanging += MoneyRenderer;
    }

    private void OnDisable()
    {
        _playerStats.HealthChanging -= HealthRender;
        _playerMoney.MoneyChanging -= MoneyRenderer;
    }

    private void HealthRender()
    {
        _visualHealthPointPlayer.text = $"{_playerStats.HealthPoint}/{_playerStats.MaxHealthPoint}";
    }

    private void MoneyRenderer()
    {
        _visualMoney.text = "Money: " + _playerMoney.CountMoney.ToString();
    }
}
