using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace MornLib
{
    [RequireComponent(typeof(InputField))]
    public sealed class MornSaveInputFieldMono : MonoBehaviour
    {
        [SerializeField] private InputField _inputField;
        [SerializeField] private MornSaveKey _saveKey;
        [Inject] private IMornSaveKeyUserDataStore _dataStore;
        private bool _selfChangeLock;

        private void Awake()
        {
            if (!_dataStore.FloatTable.Contains(_saveKey))
            {
                MornSaveKeyGlobal.Logger.LogError($"SaveKey[{_saveKey}] が登録されていません。適切に初期化してください。");
                return;
            }

            var userData = _dataStore.StringTable.GetOrCreateUserData(_saveKey, string.Empty);
            ApplyValue(userData.Value);
            userData.OnValueChanged().Where(_ => !_selfChangeLock).Subscribe(ApplyValue).AddTo(this);
            _inputField.OnValueChangedAsObservable().Subscribe(x =>
            {
                _selfChangeLock = true;
                userData.Value = x;
                _selfChangeLock = false;
            }).AddTo(this);
        }

        private void Reset()
        {
            _inputField = GetComponent<InputField>();
        }

        private void ApplyValue(string value)
        {
            _inputField.text = value;
        }
    }
}