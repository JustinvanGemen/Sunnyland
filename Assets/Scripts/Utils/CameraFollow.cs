using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Camera Velocity
    private float _velocity;
    //The target to follow with the camera
    [SerializeField] private GameObject _target;
    //Offset from the target
    private Vector3 _offset;
    //Position of the transform
    private Vector3 _transformPosition;

    ///<summary>
    ///Sets the transform position variable equal to the transform position
    ///</summary>
    void Start()
    {
        _transformPosition = transform.position;
    }

    ///<summary>
    ///Follows the target with the camera
    ///</summary>
    void Update()
    {
        //Checks if there is a target
        if (_target)
        {
            //Create a vector3 thats equal to the transform position
            Vector3 positionZTarget = transform.position;
            //Set the vector 3 to equal the targets Z position
            positionZTarget.z = _target.transform.position.z;
            //Create a vector3 equal to the transform.position - the targets Z position
            Vector3 targetDirection = (_target.transform.position - positionZTarget);
            //Calculate velocity
            _velocity = targetDirection.magnitude * 15f;
            //Calculates and smoothly lerps the camera
            _transformPosition = transform.position + (targetDirection.normalized * _velocity * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, _transformPosition + _offset, 0.25f);

        }
    }
}