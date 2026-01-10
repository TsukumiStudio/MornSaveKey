using TMPro;
using UniRx;
using UnityEngine;
using VContainer;

namespace MornLib
{
    [RequireComponent(typeof(TMP_InputField))]
    public sealed class MornSaveTMPInputFieldMono : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private MornSaveKey _saveKey;
        [Inject] private IMornSaveKeyUserDataStore _dataStore;
        private bool _selfChangeLock;

        private void Awake()
        {
            if (!_dataStore.FloatTable.Contains(_saveKey))
            {
                MornSaveKeyLogger.LogError($"SaveKey[{_saveKey}] が登録されていません。適切に初期化してください。");
                return;
            }

            var userData = _dataStore.StringTable.GetOrCreateUserData(_saveKey, string.Empty);
            ApplyValue(userData.Value);
            userData.OnValueChanged().Where(_ => !_selfChangeLock).Subscribe(ApplyValue).AddTo(this);
            _inputField.onValueChanged.AsObservable().Subscribe(x =>
            {
                _selfChangeLock = true;
                userData.Value = x;
                _selfChangeLock = false;
            }).AddTo(this);
        }

        private void Reset()
        {
            _inputField = GetComponent<TMP_InputField>();
        }

        private void ApplyValue(string value)
        {
            _inputField.text = value;
        }
    }
}