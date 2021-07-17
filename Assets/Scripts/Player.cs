using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
	public int Money { get; private set; }

	public event UnityAction<int> MoneyChanged;

	private void Start()
	{
		AddMoney(30000);
	}

	public void AddMoney(int money)
	{
		Money += money;
		MoneyChanged?.Invoke(Money);
	}

	public void BuyProduct(Goods goods)
	{
		Money -= goods.Price;
		MoneyChanged?.Invoke(Money);
	}
}