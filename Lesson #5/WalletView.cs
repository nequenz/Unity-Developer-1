using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))] 
public class WalletView : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    private Text _text;

    private void Awake()
    {
        _text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        if (_wallet != null)
            _wallet.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        if (_wallet != null)
            _wallet.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged()
    {
        _text.text = _wallet.CurrentValue.ToString();
    }

}
