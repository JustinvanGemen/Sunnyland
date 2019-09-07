using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private float _velocity;
	[SerializeField] private GameObject _target;
	private Vector3 _offset;
	private Vector3 _targetPosition;

	void Start () {
		_targetPosition = transform.position;
	}

	void Update () {
		if (_target)
		{
			Vector3 positionZTarget = transform.position;
			positionZTarget.z = _target.transform.position.z;

			Vector3 targetDirection = (_target.transform.position - positionZTarget);

			_velocity = targetDirection.magnitude * 15f;

			_targetPosition = transform.position + (targetDirection.normalized * _velocity * Time.deltaTime); 

			transform.position = Vector3.Lerp( transform.position, _targetPosition + _offset, 0.25f);

		}
	}
}