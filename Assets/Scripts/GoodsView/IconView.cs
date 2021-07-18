using UnityEngine;
using UnityEngine.UI;

public class IconView : MonoBehaviour
{
	[SerializeField] private Image _icon;
	[SerializeField] private Image _picture;

	public void ShowView(Sprite icon)
	{
		_icon.sprite = icon;
	}

	public void ShowView(Sprite icon, Sprite picture)
	{
		_icon.sprite = icon;
		_picture.sprite = picture;
	}
}
