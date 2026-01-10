using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace MornLib
{
    [RequireComponent(typeof(Toggle))]
    public sealed class MornSaveToggleMono : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;
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

            var userData = _dataStore.BoolTable.GetOrCreateUserData(_saveKey, false);
            ApplyValue(userData.Value);
            userData.OnValueChanged().Where(_ => !_selfChangeLock).Subscribe(ApplyValue).AddTo(this);
            _toggle.OnValueChangedAsObservable().Subscribe(x =>
            {
                _selfChangeLock = true;
                userData.Value = x;
                _selfChangeLock = false;
            }).AddTo(this);
        }

        private void Reset()
        {
            _toggle = GetComponent<Toggle>();
        }

        private void ApplyValue(bool value)
        {
            _toggle.isOn = value;
        }
    }
}