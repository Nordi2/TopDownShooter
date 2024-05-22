using Assets.CodeBase.Logic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeaponVisual : MonoBehaviour
{
    [SerializeField] private Transform[] _allWeapons;

    [SerializeField] private Transform _rifle;
    [SerializeField] private Transform _shotgun;
    [SerializeField] private Transform _sniper;
    [SerializeField] private Transform _machineGun;

    [Space()]
    [SerializeField] private Transform _leftHand;
    private Transform _currentGun;

    [SerializeField]private float _rigInCreaseStep;
    private bool _rigShouldBeIncreaseStep;

    private Animator _animator;
    private Rig _rig;
    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rig = GetComponentInChildren<Rig>();
    }
    private void Start()
    {
        SwitchOn(_rifle);
    }
    private void Update()
    {
        CheckWeaponSwitch();

        if (Input.GetKeyDown(KeyCode.R))
        {
            _animator.SetTrigger("Reloading");
            _rig.weight = 0;
        }
        if (_rigShouldBeIncreaseStep)
        {
            _rig.weight += _rigInCreaseStep * Time.deltaTime;
            if (_rig.weight >=1)
            {
                _rigShouldBeIncreaseStep = false;
            }
        }
    }
    public void ReturnRigWeightToOne() =>
        _rigShouldBeIncreaseStep = true;
    private void SwitchOn(Transform gunTransform)
    {
        OffGuns();
        gunTransform.gameObject.SetActive(true);
        _currentGun = gunTransform;

        AttachLeftHand();
    }
    private void OffGuns() 
    {
        for (int i = 0; i < _allWeapons.Length; i++)
        {
            _allWeapons[i].gameObject.SetActive(false);
        }
    }
    private void AttachLeftHand() 
    {
        Transform targetTransform = _currentGun.GetComponentInChildren<LeftHandTargetTransform>().transform;

        _leftHand.localPosition = targetTransform.localPosition;
        _leftHand.localRotation = targetTransform.localRotation;
    }
    private void SwitchAnimationLayer(int layerIndex)
    {
        for (int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0);
        }
        _animator.SetLayerWeight(layerIndex, 1);
    }
    private void CheckWeaponSwitch()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SwitchOn(_rifle);
            SwitchAnimationLayer(1);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SwitchOn(_shotgun);
            SwitchAnimationLayer(2);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SwitchOn(_sniper);
            SwitchAnimationLayer(3);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            SwitchOn(_machineGun);
            SwitchAnimationLayer(1);
        }
    }
}
