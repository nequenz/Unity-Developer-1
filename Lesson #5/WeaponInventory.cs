using System.Collections.Generic;
using UnityEngine;

public class WeaponInventory : MonoBehaviour
{
    private List<WeaponSO> _weaponList = new List<WeaponSO>();

    public int WeaponCount => _weaponList.Count;

    private int SafeSelect( int index )
    {
        if (_weaponList.Count == 0)
            return 0;

        if (index < 0)
            index = _weaponList.Count - 1;

        index = index % _weaponList.Count;

        return index;
    }

    public void AddWeapon(WeaponSO newWeapon) => _weaponList.Add(newWeapon);

    public WeaponSO GetWeaponByIndex(int index) => _weaponList[SafeSelect(index)];

}
