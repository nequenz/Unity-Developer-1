using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Actor))]
public class AttackAbilityAdvanced : MonoBehaviour
{
    [SerializeField] private WeaponSO _equippedWeapon;
    [SerializeField] private Transform _worldAim;
    private Actor _attacker;
    private Coroutine _delayCoroutine;

    private bool _isReadyToShoot => _delayCoroutine == null;

    public WeaponSO CurrentWeapon => _equippedWeapon;

    private void Awake() => _attacker = GetComponent<Actor>();

    private IEnumerator Delay()
    {
        WaitForSeconds wait = new WaitForSeconds(_equippedWeapon.MaxDelay);

        yield return wait;

        _delayCoroutine = null;
    }

    public void CustomShootTo(Vector3 point)
    {
        Projectile projectile;

        if (_isReadyToShoot == false || _equippedWeapon == null)
            return;

        _delayCoroutine = StartCoroutine(Delay());
        projectile = Instantiate(_equippedWeapon.Projectile, transform.position, Quaternion.identity);
        projectile.SetAttacker(_attacker);
        projectile.SetTarget(point);
    }

    public void Shoot() => CustomShootTo(_worldAim.position);

    public void EquipWeapon(WeaponSO weaponSO) => _equippedWeapon = weaponSO;

}
