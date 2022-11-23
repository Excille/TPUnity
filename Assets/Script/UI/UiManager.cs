using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private InteractPanel _interactPanel;
    private InteractPanel _currentInteractPanel;
    public static UiManager instance;
    [SerializeField] private Camera _cam;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void CreateInteractPanel(Transform tf, bool state)
    {
        if(!state)
        {
            if(_currentInteractPanel.gameObject)
            {
                Destroy(_currentInteractPanel.gameObject);
                return;
            }
        }

        

        var screenPosition = _cam.WorldToScreenPoint(tf.position);
        _currentInteractPanel = Instantiate(_interactPanel, screenPosition, Quaternion.identity,transform);
        _currentInteractPanel.Setter(tf, _cam);
    }

    public void DestroyPanel()
    {
        if (_currentInteractPanel.gameObject)
        {
            Destroy(_currentInteractPanel.gameObject);
            return;
        }
    }
}
