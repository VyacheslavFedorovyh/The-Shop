using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Goods IconLabel", menuName = "Shop/IconLabel", order = 51)]
public class IconLabel : Goods
{
	[SerializeField] private Sprite _icon;
	[SerializeField] private string _label;
}
