using UnityEngine;

public abstract class Goods : ScriptableObject
{
	[SerializeField] protected int _price;

	public int Price => _price;

	public bool IsBuyed;

	public void Buy()
	{
		IsBuyed = true;
	}
}
