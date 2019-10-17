using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameLoopManager : MonoBehaviour
{
	/// <summary>
	/// 
	/// </summary>
	public GameState GameState;

	/// <summary>
	/// 
	/// </summary>
	public Player[] Players;

	/// <summary>
	/// 
	/// </summary>
	public Camera Camera;
	private CameraController _cameraController;
	private InputSystem _inputSystem;


    /// <summary>
    /// 
    /// </summary>
    private Dictionary<PlayerSide, Player> _players = new Dictionary<PlayerSide, Player>();

	private void Awake()
	{
		_inputSystem = new InputSystem();
		_cameraController = new CameraController(Camera, _inputSystem.Camera);
	}

	private void Start()
	{
        

        _cameraController.Enable();

		for (int i = 0; i < Players.Length; i++)
		{
			_players.Add(Players[i].PlayerSide, Players[i]);
		}
	}
	private void Update()
	{
		//Временно для простой индикации
		for (int i = 0; i < Players.Length; i++)
		{
			Players[i].GoldIndicator.text = Players[i].Gold.ToString();
		}

		if (GameState == GameState.EndGame)
		{
			_cameraController.Disable();
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit ();
#endif
		}
	}

	private void FixedUpdate()
	{
		if (GameState == GameState.Play)
		{
			_cameraController.Update();
		}
	}

	public bool HaveGold (PlayerSide playerSide, int ammount)
	{
		if (_players[playerSide].Gold >= ammount)
			return true;
		return false;
	}

	public bool GetGold (PlayerSide playerSide, int ammount)
	{
		if (HaveGold(playerSide, ammount))
		{
			_players[playerSide].Gold -= ammount;
			return true;
		}
		return false;
	} 

	public void AddGold (PlayerSide playerSide, int ammount)
	{
		_players[playerSide].Gold += ammount;
		if (_players[playerSide].Gold >= _players[playerSide].GoldMax)
			_players[playerSide].Gold = _players[playerSide].GoldMax;
	}

}
