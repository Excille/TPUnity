using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    private Interactable currentInteractable;
    [SerializeField] private float _rayLenght;

    private void Update()
    {
        Ray ray = new Ray(_camera.position, _camera.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _rayLenght))
        {
            if (hit.transform.TryGetComponent(out Interactable inte))
            {
                if (currentInteractable != inte)
                {
                    currentInteractable = inte;
                    currentInteractable.Outline(true);
                }

            }
            else
            {
                
                if (currentInteractable != null)
                {
                    currentInteractable.Outline(false);
                    currentInteractable = null;
                }
            }
        }
        else
        {
           
            if (currentInteractable != null)
            {
                currentInteractable.Outline(false);
                currentInteractable = null;
            }

        }


        if(Input.GetKeyDown(KeyCode.E)&& currentInteractable != null)
        {
            currentInteractable.OnUse();
        }
    }

    private void OnDrawGizmos()
    {
        Ray ray = new Ray(_camera.position, _camera.forward);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(_camera.position, _camera.forward * _rayLenght);
    }
}
