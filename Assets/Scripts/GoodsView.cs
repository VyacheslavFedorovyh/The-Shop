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

	[SerializeField] private Color _colorButton;
	[SerializeField] private Color _colorViewEvenNumbers;
	[SerializeField] private Color _colorViewOddNumbers;

	private Goods _goods;

	public event UnityAction<Goods, GoodsView> SellButtonClick;

	private void OnEnable()
	{
		_sellButton.onClick.AddListener(OnButtonClick);
	}

	private void OnDisable()
	{
		_sellButton.onClick.RemoveListener(OnButtonClick);
	}

	public void Render(Goods goods)
	{
		_goods = goods;
		_goods.IsBuyed = false;
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
			_price.text = goods.Price.ToString() + '$';
		else if (goods.Price < 0)
		{
			ColorButton();
			_price.text = goods.Price.ToString() + '$';
		}
	}

	private void ColorButton()
	{
		ColorBlock cb = _sellButton.colors;
		cb.normalColor = _colorButton;
		_sellButton.colors = cb;
	}

	public void ColorViewEvenNumbers(int number)
	{
		if ((number % 2) == 0)
			GetComponent<Image>().color = _colorViewEvenNumbers;
		else
			GetComponent<Image>().color = _colorViewOddNumbers;
	}

	private void OnButtonClick()
	{
		SellButtonClick?.Invoke(_goods, this);
	}
}
