using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace MornLib
{
    [RequireComponent(typeof(Slider))]
    public sealed class MornSaveSliderMono : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
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

            var userData = _dataStore.FloatTable.GetOrCreateUserData(_saveKey, 0f);
            ApplyValue(userData.Value);
            userData.OnValueChanged().Where(x => !_selfChangeLock).Subscribe(ApplyValue).AddTo(this);
            _slider.OnValueChangedAsObservable().Subscribe(x =>
            {
                _selfChangeLock = true;
                userData.Value = x;
                _selfChangeLock = false;
            }).AddTo(this);
        }

        private void Reset()
        {
            _slider = GetComponent<Slider>();
        }

        private void ApplyValue(float value)
        {
            _slider.value = value;
        }
    }
}