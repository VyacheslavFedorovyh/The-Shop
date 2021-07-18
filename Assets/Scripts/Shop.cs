using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	[SerializeField] private Player _player;
	[SerializeField] private List<Goods> _goods;
	[SerializeField] private GoodsView _teamlate;
	[SerializeField] private GameObject _itemContainer;

	private GoodsView[] _goodsView;

	private void Start()
	{		
		_goodsView = new GoodsView[_goods.Count];

		foreach (var good in _goods)
		{
			AddItem(good);
		}
	}

	private void AddItem(Goods goods)
	{
		var view = Instantiate(_teamlate, _itemContainer.transform);
		view.SellButtonClick += OnSellButtonClick;
		view.Render(goods);
	}

	private void OnSellButtonClick(Goods goods, GoodsView view)
	{
		TrySellProduct(goods, view);
	}

	private void TrySellProduct(Goods goods, GoodsView view)
	{
		if (goods.Price <= _player.Money)
		{
			_player.BuyProduct(goods);
			//goods.Buy(); Скрывать товар
			view.SellButtonClick -= OnSellButtonClick;
		}
	}
}
