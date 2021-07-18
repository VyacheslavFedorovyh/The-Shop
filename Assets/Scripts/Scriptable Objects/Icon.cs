using UnityEngine;

[CreateAssetMenu(fileName = "new Goods Icon", menuName = "Shop/Icon", order = 51)]
public class Icon : Goods
{
	[SerializeField] private Sprite _icon;

	public Sprite IconSprite => _icon;
}
