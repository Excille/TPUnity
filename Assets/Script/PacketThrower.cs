using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacketThrower : MonoBehaviour
{
    [SerializeField] private Packet packet;
    [SerializeField] private Transform _launchPoint;
    [SerializeField] private float _launchForce;
    [SerializeField] private GameObject _packetOnHand;
    [SerializeField] private Transform _handStart;
    [SerializeField] private Transform _handStop;
    private Vector3 _startHandPos;
    private Vector3 _startHandRot;
    private bool _hasLaunchedPacket;
    private bool _throwing;


    private void Start()
    {
        _startHandPos = _handStart.localPosition;
        _startHandRot = _handStart.localRotation.eulerAngles;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !_throwing)
        {
            Launch();   
            //Instantiate(packet, _launchPoint.position, _launchPoint.rotation).Force(_launchForce);
        }
    }


    private void Launch()
    {
        _throwing = true;
        LeanTween.moveLocal(_handStart.gameObject, _handStop.localPosition, .2f);
        LeanTween.rotateLocal(_handStart.gameObject, _handStop.localRotation.eulerAngles, .2f).setOnUpdate(calc).
            setOnComplete(ResetLaunch);
    }

    private void ResetLaunch()
    {
        LeanTween.moveLocal(_handStart.gameObject, _startHandPos, .2f).setDelay(.5f);
        LeanTween.rotateLocal(_handStart.gameObject, _startHandRot, .2f).setDelay(.5f).setOnComplete(() => 
        { 
            _hasLaunchedPacket = false;
            _packetOnHand.SetActive(true);
            _throwing = false;
        });
    }


    void calc(float x)
    {
        if(x > .45f && !_hasLaunchedPacket)
        {
            _packetOnHand.SetActive(false);
            Instantiate(packet, _launchPoint.position, _launchPoint.rotation).Force(_launchForce);
            _hasLaunchedPacket = true;
        }
    }


}
