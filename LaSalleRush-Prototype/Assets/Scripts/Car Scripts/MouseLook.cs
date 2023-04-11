using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseLook : MonoBehaviour
{
   [SerializeField] private CinemachineFreeLook _freeLookCamera;
   [SerializeField] private float _mouseSensitivityX = 1f;
   [SerializeField] private float _mouseSensitivityY = 1f;
   [SerializeField] private float _lerpSpeed = 5f;

    private float _xRotation = 0f;
    private float _yRotation = 0f;
    private float _defaultXValue;
    private float _defaultYValue;
    private void Start()
    {
       _defaultXValue = _freeLookCamera.m_XAxis.Value;
        
       _defaultYValue = _freeLookCamera.m_YAxis.Value;
    }
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {

            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivityX;
            float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivityY;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -30f, 30f);

            _yRotation += mouseX;
            
            transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
            
            _freeLookCamera.m_XAxis.Value = _yRotation;//mouseX;
            _freeLookCamera.m_YAxis.Value = _xRotation;//mouseY;
          
        }
        else if(Input.GetMouseButtonUp(1))
        {
            ResetCameraPosition();
        }
    }

     private void ResetCameraPosition()
    {
        StartCoroutine(ResetCamPosition());
    }

    private IEnumerator ResetCamPosition()
    {
        float elapsedTime = 0f;
        float currentXValue = _freeLookCamera.m_XAxis.Value;
        float currentYValue = _freeLookCamera.m_YAxis.Value;
        
        Quaternion currentRotation = transform.localRotation;

        while (elapsedTime < 1f / _lerpSpeed)
        {
            float newXValue = Mathf.Lerp(currentXValue, _defaultXValue, elapsedTime * _lerpSpeed);
            float newYValue = Mathf.Lerp(currentYValue, _defaultYValue, elapsedTime * _lerpSpeed);
            
            _freeLookCamera.m_XAxis.Value = newXValue;
            _freeLookCamera.m_YAxis.Value = newYValue;

            Quaternion newRotation = Quaternion.Slerp(currentRotation, Quaternion.identity, elapsedTime * _lerpSpeed);
            transform.localRotation = newRotation;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _freeLookCamera.m_XAxis.Value = _defaultXValue;
        _freeLookCamera.m_YAxis.Value = _defaultYValue;

        _xRotation = _defaultYValue;
        _yRotation = _defaultXValue;

        transform.localRotation = Quaternion.identity;
    }

}
