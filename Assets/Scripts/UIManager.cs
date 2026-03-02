using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;

    [Header("UI Elements")]
    public TMP_Text _healthText;
    public TMP_Text _selectNote;

    void Start()
    {
    }
    
    public void OnEnable()
    {
        _playerHealth.OnHealthUpdated.AddListener(OnHealthUpdated);
    }
    public void OnDisable()
    {
        _playerHealth.OnHealthUpdated.RemoveListener(OnHealthUpdated);
    }

    public void OnSelectableNote(string str)
    {
        _selectNote.text = str;
    }
    public void OnClearSelectableNote()
    {
        _selectNote.text = "";
    }

    public void OnHealthUpdated(float health)
    {
        _healthText.text = $"{health}";
    }
}