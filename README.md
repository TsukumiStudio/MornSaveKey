# MornSaveKey

## 概要

ゲームの設定値やユーザーデータ（Bool/Int/Float/String）をキー・バリュー形式で永続化し、UI要素と自動的に同期するシステム。

## 依存関係

| 種別 | 名前 |
|------|------|
| 外部パッケージ | UniRx, VContainer, TextMesh Pro |
| Mornライブラリ | MornEnum, MornGlobal |

## 使い方

### セットアップ

1. `MornSaveKeyGlobal` ScriptableObjectでSaveKey名を登録
2. `MornSaveDataBase` でBool/Int/Float/String/Triggerの5種類のテーブルを管理

### データの読み書き

```csharp
// データストアから取得
var userData = _dataStore.Solve().IntTable.GetOrCreateUserData("saveKeyName", defaultValue: 0);

// 値を読み取る
int currentValue = userData.Value;

// 値を書き込む（自動的に永続化と変更通知が発生）
userData.Value = newValue;
```

### データ変更の監視

```csharp
userData.OnValueChanged().Subscribe(newValue => {
    // 値が変更されたときの処理
}).AddTo(this);
```

### UIコンポーネントとの自動同期

| コンポーネント | 機能 |
|---------------|------|
| MornSaveToggleMono | Toggleと Bool値の双方向同期 |
| MornSaveInputFieldMono | InputFieldと String値の双方向同期 |
| MornSaveSliderMono | Sliderと Float/Int値の双方向同期 |
| MornSaveTMPInputFieldMono | TMP InputFieldと String値の双方向同期 |
