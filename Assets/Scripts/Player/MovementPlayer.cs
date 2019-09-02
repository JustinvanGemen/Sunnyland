using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour {

	[SerializeField] private MovementController _movementController;

	private float _movementSpeed = 15f;

	private float hMove = 0f;
	private bool _jumping = false;
	private bool _crouching = false;
	
	private void Update () {

		hMove = Input.GetAxisRaw("Horizontal") * _movementSpeed;

		if (Input.GetKeyDown(KeyCode.W))
		{
			_jumping = true;
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			_crouching = true;
		} else if (Input.GetKeyDown(KeyCode.S))
		{
			_crouching = false;
		}

	}

	private void FixedUpdate ()
	{
		_movementController.Move(hMove * Time.fixedDeltaTime, _crouching, _jumping);
		_jumping = false;
	}
}