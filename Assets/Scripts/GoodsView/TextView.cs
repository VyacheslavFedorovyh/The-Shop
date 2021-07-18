using TMPro;
using UnityEngine;

public class TextView : MonoBehaviour
{
	[SerializeField] private TMP_Text _label;
	[SerializeField] private TMP_Text _description;

	public void ShowView(string label)
	{
		_label.text = label;
	}

	public void ShowView(string label, string description)
	{
		_label.text = label;
		_description.text = description;
	}
}
