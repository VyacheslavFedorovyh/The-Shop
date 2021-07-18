using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	[SerializeField] private Player _player;
	[SerializeField] private List<Goods> _goodsList;
	[SerializeField] private GoodsView _teamlate;
	[SerializeField] private GameObject _itemContainer;
	[SerializeField] private MessagePanel _message;

	private Goods _goods;
	private GoodsView _view;

	private int _numberGoods;
	private List<GoodsView> _goodsViewList;

	private void Start()
	{
		_numberGoods = 0;
		_goodsViewList = new List<GoodsView>();

		foreach (Goods good in _goodsList)
		{
			AddItem(good);
		}
	}

	private void AddItem(Goods goods)
	{
		GoodsView view = Instantiate(_teamlate, _itemContainer.transform);
		view.SellButtonClick += OnSellButtonClick;
		view.Render(goods);

		_numberGoods++;
		_goodsViewList.Add(view);
		view.ColorViewEvenNumbers(_numberGoods);
		view.Number.text = _numberGoods.ToString();
	}

	private void OnSellButtonClick(Goods goods, GoodsView view)
	{
		_goods = goods;
		_view = view;

		if (_goods.Price >= 0)
		{
			BuyGoods();
			return;
		}

		TrySellGoods();
	}

	private void TrySellGoods()
	{
		if ((_player.Money + _goods.Price) >= 0)
		{
			_message.Transaction();
			_message.SellButtonClickOk += BuyGoods;
		}
		else
			_message.NotEnoughMoney();
	}

	private void BuyGoods()
	{
		_goods.Buy();
		_player.BuyGoods(_goods);
		_goodsViewList.Remove(_view);
		ReevaluateNumberGoodsView();
		_view.gameObject.SetActive(false);
		_view.SellButtonClick -= OnSellButtonClick;
		_message.SellButtonClickOk -= BuyGoods;
	}

	private void ReevaluateNumberGoodsView()
	{
		foreach (GoodsView view in _goodsViewList)
		{
			int newNumber = _goodsViewList.IndexOf(view);
			newNumber++;
			view.ColorViewEvenNumbers(newNumber);
			view.Number.text = newNumber.ToString();
		}
	}
}
