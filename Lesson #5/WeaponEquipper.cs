using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponEquipper : MonoBehaviour
{
    private const int NextWeaponSelector = 1;
    private const int PrevWeaponSelector = -1;

    [SerializeField] private AttackAbilityAdvanced _attackAbilityAdvanced;
    [SerializeField] private WeaponInventory _weaponInventory;
    private int selectedIndex = 0;

    public event Action<WeaponSO> WeaponSelected;

    private void MoveSelectIndex(int target)
    {
        WeaponSO equippedWeapon;

        selectedIndex += Mathf.Clamp(target,-1,1);
        equippedWeapon = _weaponInventory.GetWeaponByIndex(selectedIndex);
        _attackAbilityAdvanced.EquipWeapon(equippedWeapon);
        WeaponSelected?.Invoke(equippedWeapon);
        OnWeaponSelect(equippedWeapon);
    }

    public void SelectNextWeapon() => MoveSelectIndex(NextWeaponSelector);

    public void SelectPrevWeapon() => MoveSelectIndex(PrevWeaponSelector);

    private void OnWeaponSelect( WeaponSO equippedWeapon )
    {

    }
}
