# Cumin Service Locator

C#およびUnity向けの軽量な Service Locator 実装です。

`Cumin` は、依存オブジェクトの登録と取得をシンプルに行うためのライブラリです。複雑な DI コンテナを導入せずに、アプリケーション全体で共有するサービスやマネージャーを管理できます。

## 特徴

* シンプルな Service Locator パターン
* 単一インスタンス向けの `Locator<T>`
* 複数サービス管理向けの `CompositeLocator`
* インターフェースと実装クラスの登録に対応
* 外部ライブラリ不要

## Locator<T>

単一のサービスを管理するためのロケーターです。

### 登録

```csharp
Locator<GameManager>.Register(new GameManager());
```

### 取得

```csharp
var manager = Locator<GameManager>.Instance;
```

### 存在確認

```csharp
if (Locator<GameManager>.IsValid)
{
    // 使用可能
}
```

### 解放

```csharp
Locator<GameManager>.Dispose();
```

## CompositeLocator

複数のサービスを管理するロケーターです。

### インスタンスを登録

```csharp
CompositeLocator.Register(new AudioManager());
```

### 自動生成して登録

```csharp
CompositeLocator.Register<AudioManager>();
```

### インターフェースと実装を登録

```csharp
CompositeLocator.Register<IAudioManager, AudioManager>();
```

### 解決

```csharp
var audio = CompositeLocator.Resolve<AudioManager>();
```

または

```csharp
var audio = CompositeLocator.Resolve<IAudioManager>();
```

### 登録解除

```csharp
CompositeLocator.Unregister<AudioManager>();
```

### 全削除

```csharp
CompositeLocator.Clear();
```

## 使用例

```csharp
public interface IAudioManager
{
    void Play(string name);
}

public class AudioManager : IAudioManager
{
    public void Play(string name)
    {
        Console.WriteLine(name);
    }
}

CompositeLocator.Register<IAudioManager, AudioManager>();

var audio = CompositeLocator.Resolve<IAudioManager>();

audio?.Play("BGM");
```

## 主な用途

* ゲーム開発
* 小規模アプリケーション
* グローバルサービスの管理
* マネージャークラスの共有
* DI コンテナを導入するほどではないプロジェクト

## 注意事項

`Cumin` は軽量な Service Locator です。

ライフサイクル管理、自動インジェクション、スコープ管理などの高度な DI 機能は提供していません。必要に応じて DI コンテナとの使い分けを推奨します。

## ライセンス

zlib/libpng License
