using UnityEngine;

[CreateAssetMenu(fileName = "new Goods IconLabel", menuName = "Shop/IconLabel", order = 51)]
public class IconLabel : Goods
{
	[SerializeField] private Sprite _icon;
	[SerializeField] private string _label;

	public string LabelText => _label;
	public Sprite IconSprite => _icon;
}
