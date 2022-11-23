using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _clampLook;
    private Animator _anim;
    private CharacterController _controller;
    private float xRotation = 0f;

    

    #region AnimID

    private readonly int _velocityZ = Animator.StringToHash("velocityZ");
    private readonly int _velocityX = Animator.StringToHash("velocityX");

    #endregion

    [Header("Debug")]
    [SerializeField] private float _rayLengh;
    
    private void Awake()
    {
        if (TryGetComponent(out CharacterController charc)) 
            _controller = charc;
        if (TryGetComponent(out Animator anim)) 
            _anim = anim;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        LookAround();
        Move();
    }

    private void LookAround()
    {
        float x = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        float z = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;


        xRotation -= z;
        xRotation = Mathf.Clamp(xRotation, -_clampLook, _clampLook);

        _camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * x);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(_camera.transform.position, _camera.transform.forward * _rayLengh);
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        var direction = _camera.transform.right * x + _camera.transform.forward * z;
        direction.y = 0;
        direction.Normalize();
        _controller.Move(direction * _moveSpeed * Time.deltaTime);

        UpdateAnimator();

        void UpdateAnimator()
        {
            _anim.SetFloat(_velocityX, z);
            _anim.SetFloat(_velocityZ, x);
        }
    }
}
