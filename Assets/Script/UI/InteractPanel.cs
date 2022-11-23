using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPanel : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private Camera _cam;

    private void Update()
    {
        if(point)
            transform.position = _cam.WorldToScreenPoint(point.position);
    }

    public void Setter(Transform point, Camera cam)
    {
        _cam = cam;
        this.point = point;
    }
}
