using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Pnj : MonoBehaviour
{
    private Animator _anim;
    private readonly int _stunnedID = Animator.StringToHash("stunned");
    [SerializeField] private GameObject _starStun;
    private bool _isStun;
    private float _timeStunned;
    private Rigidbody rb;
    public bool isAlive;

    private void Awake()
    {
        if (TryGetComponent(out Animator anim)) _anim = anim;
        if (TryGetComponent(out Rigidbody rb)) this.rb = rb;
    }

    private void Update()
    {
        if (!_isStun)
            return;

        _timeStunned -= Time.deltaTime;
        if(_timeStunned <= 0)
        {
            _anim.SetBool(_stunnedID, false);
            _starStun.SetActive(false);
            _isStun = false;
        }
    }

    public void Stunned(float time)
    {
        _anim.enabled = false;
        isAlive = false;
        if (TryGetComponent(out CapsuleCollider cap))
            cap.enabled = false;
        _starStun.SetActive(true);

        return;
        //_anim.SetBool(_stunnedID, true);
        //_starStun.SetActive(true);
        //_timeStunned = time;
        //_isStun = true;

    }

}
