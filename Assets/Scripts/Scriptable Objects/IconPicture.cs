using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Goods IconPicture", menuName = "Shop/IconPicture", order = 51)]
public class IconPicture : Goods
{
	[SerializeField] private Sprite _icon;
	[SerializeField] private Sprite _picture;
}
