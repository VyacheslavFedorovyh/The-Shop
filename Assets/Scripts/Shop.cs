using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	[SerializeField] private Player _player;
	[SerializeField] private List<Goods> _goods;
	[SerializeField] private GoodsView _teamlate;
	[SerializeField] private GameObject _itemContainer;

	private int _numberGoods;
	private List<GoodsView> _goodsViewList;

	private void Start()
	{
		_numberGoods = 0;
		_goodsViewList = new List<GoodsView>();

		foreach (Goods good in _goods)
		{
			AddItem(good);
		}
	}

	private void AddItem(Goods goods)
	{
		var view = Instantiate(_teamlate, _itemContainer.transform);
		view.SellButtonClick += OnSellButtonClick;
		view.Render(goods);

		_numberGoods++;
		_goodsViewList.Add(view);
		view.Number.text = _numberGoods.ToString();
	}

	private void OnSellButtonClick(Goods goods, GoodsView view)
	{
		TrySellGoods(goods, view);
	}

	private void TrySellGoods(Goods goods, GoodsView view)
	{
		if ((_player.Money + goods.Price) >= 0)
		{
			// Диалог о покупке
			_player.BuyGoods(goods);
			goods.Buy();
			view.SellButtonClick -= OnSellButtonClick;
			_goodsViewList.Remove(view);
			ReevaluateNumberGoodsView();
		}
		else
		{
			// Не хватает денег
		}
	}

	private void ReevaluateNumberGoodsView()
	{
		foreach (GoodsView goodsView in _goodsViewList)
		{
			int newNumber = _goodsViewList.IndexOf(goodsView);
			newNumber++;
			goodsView.Number.text = newNumber.ToString();
		}
	}
}
