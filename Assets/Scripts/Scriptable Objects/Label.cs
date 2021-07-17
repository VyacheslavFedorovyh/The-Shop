using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Goods Label", menuName = "Shop/Label", order = 51)]
public class Label : Goods
{
	[SerializeField] private string _label;
}
