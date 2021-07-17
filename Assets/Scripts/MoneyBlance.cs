using TMPro;
using UnityEngine;

public class MoneyBlance : MonoBehaviour
{
	[SerializeField] private Player _player;
	[SerializeField] private TMP_Text _textBlance;

	private void OnEnable()
	{
		_textBlance.text = _player.Money.ToString();
		_player.MoneyChanged += OnMoneyMoneyChanged;
	}

	private void OnDisable()
	{
		_player.MoneyChanged -= OnMoneyMoneyChanged;
	}

	private void OnMoneyMoneyChanged(int money)
	{
		_textBlance.text = money.ToString();
	}
}
