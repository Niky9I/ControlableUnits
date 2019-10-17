using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OwnerComponent))]
public class CaptureProcessComponent : MonoBehaviour
{
	public float CaptureSpeed;
	public float CurrentCapture;
	public float CaptureTreshold;
	public Color[] PlayersColors;
	public float CaptureRadius;

	private OwnerComponent _owner;
	private Dictionary<PlayerSide, float> _capturers;

    void Start()
    {
		CaptureSpeed = 0;
		CurrentCapture = 0;
		_owner = gameObject.GetComponent<OwnerComponent>();
		_capturers = new Dictionary<PlayerSide, float>();
    }
    void Update()
    {
		CheckCapturers();
		if (_capturers.Keys.Count == 0)
			return;
		if (_owner.Player == PlayerSide.None && _capturers.Keys.Count == 1)
		{
			foreach (PlayerSide playerSide in _capturers.Keys)
			{
				SetOwner(playerSide);
			}
			return;
		}
		if (_owner.Player == PlayerSide.None && _capturers.Keys.Count > 1)
			return;
		float deltaTime = Time.deltaTime;
		CurrentCapture += CalculateCaptureSpeed() * deltaTime;
		if (CurrentCapture >= CaptureTreshold)
		{
			SetOwner(PlayerSide.None);
		}
    }
	private void SetOwner (PlayerSide playerSide)
	{
		_owner.Player = playerSide;
		gameObject.GetComponent<MeshRenderer>().material.color = PlayersColors[(int)_owner.Player];
		CurrentCapture = 0;
	}

	private float CalculateCaptureSpeed()
	{
		float resultCaptureSpeed = 0;
		foreach (PlayerSide playerSide in _capturers.Keys)
		{
			if (playerSide != _owner.Player)
			{
				resultCaptureSpeed = _capturers[playerSide];
			}
		}		
		return resultCaptureSpeed;
	}
	private void CheckCapturers()
	{
		_capturers.Clear();
		var caprurersArray = FindObjectsOfType<CaptureComponent>();
		foreach (CaptureComponent capturer in caprurersArray)
		{
			var testDist = Vector3.Distance(capturer.gameObject.transform.position, gameObject.transform.position);
			var capturerOwner = capturer.GetComponent<OwnerComponent>().Player;
			if (testDist <= CaptureRadius)
			{
				if (_capturers.ContainsKey(capturerOwner))
				{
					_capturers[capturerOwner] += capturer.CapturePoints;
				}
				else
				{
					_capturers.Add(capturerOwner, capturer.CapturePoints);
				}
				if (capturerOwner != _owner.Player && _owner.Player != PlayerSide.None)
				{
					capturer.CapturingBuilding = gameObject;
				}
				else
				{
					capturer.CapturingBuilding = null;
				}
			}
		}
	}
}
