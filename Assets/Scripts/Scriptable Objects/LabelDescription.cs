using UnityEngine;

[CreateAssetMenu(fileName = "new Goods LabelDescription", menuName = "Shop/LabelDescription", order = 51)]
public class LabelDescription : Goods
{
	[SerializeField] private string _label;
	[SerializeField] private string _description;

	public string LabelText => _label;
	public string DescriptionText => _description;
}
