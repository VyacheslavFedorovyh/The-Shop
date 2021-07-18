using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
	[SerializeField] private int _startMoney = 300;

	public int Money { get; private set; }

	public event UnityAction<int> MoneyChanged;

	private void Start()
	{
		AddMoney(_startMoney);
	}

	public void AddMoney(int money)
	{
		Money += money;
		MoneyChanged?.Invoke(Money);
	}

	public void BuyGoods(Goods goods)
	{
		Money += goods.Price;
		MoneyChanged?.Invoke(Money);
	}
}