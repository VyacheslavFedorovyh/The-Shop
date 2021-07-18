using UnityEngine;

[CreateAssetMenu(fileName = "new Goods Label", menuName = "Shop/Label", order = 51)]
public class Label : Goods
{
	[SerializeField] private string _label;

	public string LabelText => _label;
}
