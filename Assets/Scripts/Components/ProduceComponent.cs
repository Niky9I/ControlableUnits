using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(OwnerComponent))]
public class ProduceComponent : MonoBehaviour
{
	public event Action<PopUpTypes, int> AddGold;

	public int Ammount;
	public float ProduceDelay;
	[HideInInspector] public float ProduceTime;

	private OwnerComponent _owner;
	private GameLoopManager _gameManager;
	private void Start()
	{
		_owner = gameObject.GetComponent<OwnerComponent>();
		_gameManager = FindObjectOfType<GameLoopManager>();
	}
	void Update()
    {
		if (_owner.Player == PlayerSide.None)
			return;
		float deltaTime = Time.deltaTime;
		ProduceTime += deltaTime;
		if (ProduceTime >= ProduceDelay)
		{
			_gameManager.AddGold(_owner.Player, Ammount);
			AddGold?.Invoke(PopUpTypes.GoldUp, Ammount);
			ProduceTime = 0;
		}
	}
}
