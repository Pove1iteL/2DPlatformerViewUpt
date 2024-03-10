using UnityEngine;
using UnityEngine.UI;

public class TextHealthView : MonoBehaviour
{
    [SerializeField] private Text _visualHealthPointPlayer;
    [SerializeField] private PlayerStats _playerStats;

    private void Update()
    {
        _visualHealthPointPlayer.text = $"{_playerStats.HealthPoint}/{_playerStats.MaxHealthPoint}";
    }
}
