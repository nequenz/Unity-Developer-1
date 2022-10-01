using UnityEngine;
using UnityEngine.UI;

public class UIWeaponEquipperView : MonoBehaviour
{
    [SerializeField] private WeaponEquipper _weaponEquipper;
    [SerializeField] private Image _iconToDraw;

    private void OnEnable()
    {
        if (_weaponEquipper != null)
            _weaponEquipper.WeaponSelected += OnWeaponSelect;
    }

    private void OnDisable()
    {
        if (_weaponEquipper != null)
            _weaponEquipper.WeaponSelected -= OnWeaponSelect;
    }

    private void OnWeaponSelect(WeaponSO equippedWeapon)
    {
        if(_iconToDraw != null)
        {
            _iconToDraw.sprite = equippedWeapon.Icon;
        } 
    }
}
