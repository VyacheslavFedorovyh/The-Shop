using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GoodsView : MonoBehaviour
{
	public TMP_Text Number;
	[SerializeField] private Button _sellButton;
	[SerializeField] private TMP_Text _price;

	[SerializeField] private GameObject _goodsLabel;
	[SerializeField] private GameObject _goodsLabelDescription;
	[SerializeField] private GameObject _goodsIcon;
	[SerializeField] private GameObject _goodsIconLabel;
	[SerializeField] private GameObject _goodsIconPicture;

	//[SerializeField] private TMP_Text _label;
	//[SerializeField] private TMP_Text _description;
	//[SerializeField] private Image _icon;
	//[SerializeField] private Image _picture;
	[SerializeField] Color _colorButton;

	private Goods _goods;

	public event UnityAction<Goods, GoodsView> SellButtonClick;

	private void OnEnable()
	{
		_sellButton.onClick.AddListener(OnButtonClick);
		_sellButton.onClick.AddListener(TryLockItem);
	}

	private void OnDisable()
	{
		_sellButton.onClick.RemoveListener(OnButtonClick);
		_sellButton.onClick.RemoveListener(TryLockItem);
	}

	public void Render(Goods goods)
	{
		_goods = goods;

		AddPriceButton(_goods);

		Label label = _goods as Label;
		if (label != null)
		{
			_goodsLabel.SetActive(true);
			_goodsLabel.GetComponent<TextView>().ShowView(label.LabelText);
			return;
		}

		LabelDescription labelDescription = _goods as LabelDescription;
		if (labelDescription != null)
		{
			_goodsLabelDescription.SetActive(true);
			_goodsLabelDescription.GetComponent<TextView>().ShowView(labelDescription.LabelText, labelDescription.DescriptionText);			
			return;
		}

		Icon icon = _goods as Icon;
		if (icon != null)
		{
			_goodsIcon.SetActive(true);			
			_goodsIcon.GetComponent<IconView>().ShowView(icon.IconSprite);
			return;
		}

		IconLabel iconLabel = _goods as IconLabel;
		if (iconLabel != null)
		{
			_goodsIconLabel.SetActive(true);
			_goodsIconLabel.GetComponent<IconView>().ShowView(iconLabel.IconSprite);
			_goodsIconLabel.GetComponent<TextView>().ShowView(iconLabel.LabelText);
			return;
		}

		IconPicture iconPicture = _goods as IconPicture;
		if (iconPicture != null)
		{
			_goodsIconPicture.SetActive(true);
			_goodsIconPicture.GetComponent<IconView>().ShowView(iconPicture.IconSprite, iconPicture.PictureSprite);
			return;
		}
	}

	private void AddPriceButton(Goods goods)
	{
		if (goods.Price > 0)
			_price.text = goods.Price.ToString();
		else if (goods.Price < 0)
		{
			ColorBlock cb = _sellButton.colors;
			cb.normalColor = _colorButton;
			_sellButton.colors = cb;

			_price.text = goods.Price.ToString();
		}
	}

	private void TryLockItem()
	{
		if (_goods.IsBuyed)
			gameObject.SetActive(false);
	}

	private void OnButtonClick()
	{
		SellButtonClick?.Invoke(_goods, this);
	}
}
