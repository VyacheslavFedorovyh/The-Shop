using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private List<Goods> _goods;    

    private void Start()
    {
		foreach (var good in _goods)
		{
            
        }
    }
}
