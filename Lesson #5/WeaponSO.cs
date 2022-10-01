using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon", order = 51)]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private string _name = "Безымянное оружие";
    [SerializeField] private string _description = "Без описания";
    [SerializeField] private int _price = 0;
    [SerializeField] private float _maxDelay = 1.0f;
    [SerializeField] private float _damage = 0.0f;
    [SerializeField] private int _projectileCount = 1;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Projectile _projectile;

    public string Name => _name;
    public string Descprition => _description;

    public int Price => _price;
    public float MaxDelay => _maxDelay;
    public float Damage => _damage;
    public int ProjectileCount => _projectileCount;
    public Sprite Icon => _icon;
    public Projectile Projectile => _projectile;
}
