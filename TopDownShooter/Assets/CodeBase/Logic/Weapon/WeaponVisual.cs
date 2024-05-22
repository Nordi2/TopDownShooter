using Assets.CodeBase.Logic;
using UnityEngine;

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
    private void Start()
    {
        SwitchOn(_rifle);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            SwitchOn(_rifle);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            SwitchOn(_shotgun);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            SwitchOn(_sniper);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            SwitchOn(_machineGun);
        }
    }
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
}
