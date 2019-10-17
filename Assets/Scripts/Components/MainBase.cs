using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OwnerComponent))]
public class MainBase : MonoBehaviour
{

	[SerializeField] private GameObject[] _startingBuildings;
	private GameLoopManager _gameManager;
	private PlayerSide _owner;
    void Start()
    {
		_gameManager = FindObjectOfType<GameLoopManager>();
		_owner = gameObject.GetComponent<OwnerComponent>().Player;
        foreach (GameObject obj in _startingBuildings)
		{
			var tempOwner = obj.GetComponent<OwnerComponent>();
			if (tempOwner != null)
			{
				tempOwner.Player = _owner;
			}
		}
    }
	private void OnDestroy()
	{
		_gameManager.GameState = GameState.EndGame;
	}
}
