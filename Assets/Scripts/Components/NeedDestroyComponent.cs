using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedDestroyComponent : MonoBehaviour
{
	public PlayerSide Destroyer;
	private GameLoopManager _gameManager;

	void Start()
	{
		_gameManager = FindObjectOfType<GameLoopManager>();
	}
    void Update()
    {
		if(Destroyer != PlayerSide.None)
		{
			if (gameObject.TryGetComponent<CostComponent>(out var tempCost))
			{
				_gameManager.AddGold(Destroyer, tempCost.RewardGold);
			}
		}
		Debug.Log($"{gameObject.name} died.");
		Destroy(gameObject);
    }
}
