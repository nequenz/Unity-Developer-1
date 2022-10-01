using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIWeaponSlotView : MonoBehaviour
{
    [SerializeField] private WeaponSO _weapon;
    [SerializeField] private Text _weaponNameText;
    [SerializeField] private Text _weaponDescriptionText;
    [SerializeField] private Text _weaponPriceText;
    [SerializeField] private Image _weaponIcon;

    private void Start()
    {
        if(_weapon == null)
            Destroy(gameObject);
        else
        {
            _weaponNameText.text = _weapon.Name;
            _weaponDescriptionText.text = _weapon.Descprition;
            _weaponIcon.sprite = _weapon.Icon;
            _weaponPriceText.text = _weapon.Price.ToString();
        }
    }
}
