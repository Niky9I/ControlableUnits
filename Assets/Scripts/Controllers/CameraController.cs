using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : InputSystem.ICameraActions
{
	private InputSystem.CameraActions _cameraActions;
	private Camera _camera;

	private float _speed = 25.0f;
	private Vector2 _direction = Vector2.zero;

	public CameraController(Camera camera, InputSystem.CameraActions inputSystem)
	{
		_camera = camera;
		_cameraActions = inputSystem;

		_cameraActions.SetCallbacks(this);
	}

	public void Enable()
	{
		_cameraActions.Enable();
	}

	public void Disable()
	{
		_cameraActions.Disable();
	}

	// Update is called once per frame
	public void Update()
	{
		if (_direction.sqrMagnitude < 0.01)
			return;

		var move = new Vector3(_direction.x, _direction.y, 0.0f);
		_camera.transform.Translate(move * Time.deltaTime * _speed);
	}

	public void OnZoom(InputAction.CallbackContext context)
	{
		Debug.Log(context);
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		if (context.started)
			return;

		_direction = context.ReadValue<Vector2>();

		Debug.Log(_direction);
		Debug.Log(context);
	}
}
