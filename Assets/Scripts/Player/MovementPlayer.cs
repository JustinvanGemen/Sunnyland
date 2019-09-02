using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour {

	[SerializeField] private MovementController _movementController;

	private float _movementSpeed = 15f;

	private float _horizontalMove = 0f;
	private bool _jumping = false;
	private bool _crouching = false;
	
	private void Update () {

		_horizontalMove = Input.GetAxisRaw("Horizontal") * _movementSpeed;

		if (Input.GetKeyDown(KeyCode.W))
		{
			_jumping = true;
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			if(!_crouching)
			{
			_crouching = true;
			}
			else{
				_crouching = false;
			}
		}

	}

	private void FixedUpdate ()
	{
		_movementController.Move(_horizontalMove * Time.fixedDeltaTime, _crouching, _jumping);
		_jumping = false;
	}
}