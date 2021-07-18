using UnityEngine;

[CreateAssetMenu(fileName = "new Goods IconPicture", menuName = "Shop/IconPicture", order = 51)]
public class IconPicture : Goods
{
	[SerializeField] private Sprite _icon;
	[SerializeField] private Sprite _picture;

	public Sprite IconSprite => _icon;
	public Sprite PictureSprite => _picture;
}
