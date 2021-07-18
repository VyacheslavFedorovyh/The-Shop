using UnityEngine;

public abstract class Goods : ScriptableObject
{
	[SerializeField] protected int _price;

	public int Price => _price;

	public bool IsBuyed = false;

	public void Buy()
	{
		IsBuyed = true;
	}
}
