using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTransaction : MonoBehaviour
{
    [SerializeField] private WeaponSO _weapon;
    [SerializeField] private Wallet _dealWallet;
    [SerializeField] private WeaponInventory _weaponInventory;

    public void Buy()
    {
        if (_dealWallet == null || _weaponInventory == null)
            return;

        if(_dealWallet.CanTransit(_weapon.Price))
        {
            _dealWallet.Transit(_weapon.Price);
            _weaponInventory.AddWeapon(_weapon);
        }
    }
}
