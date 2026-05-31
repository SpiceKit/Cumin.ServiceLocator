# Cumin Service Locator

A lightweight Service Locator implementation for C# and Unity.

`Cumin` provides a simple way to register and resolve shared services without introducing a full dependency injection container. It is suitable for managing global services and managers in small to medium-sized applications.

[日本語はこちら](README.ja.md)

## Features

* Simple Service Locator pattern
* `Locator<T>` for managing a single service instance
* `CompositeLocator` for managing multiple services
* Supports interface-to-implementation registration
* No external dependencies

## Locator<T>

A locator for managing a single service instance.

### Register

```csharp
Locator<GameManager>.Register(new GameManager());
```

### Access

```csharp
var manager = Locator<GameManager>.Instance;
```

### Check Availability

```csharp
if (Locator<GameManager>.IsValid)
{
    // Available
}
```

### Dispose

```csharp
Locator<GameManager>.Dispose();
```

## CompositeLocator

A locator for managing multiple services.

### Register an Existing Instance

```csharp
CompositeLocator.Register(new AudioManager());
```

### Create and Register Automatically

```csharp
CompositeLocator.Register<AudioManager>();
```

### Register an Interface and Implementation

```csharp
CompositeLocator.Register<IAudioManager, AudioManager>();
```

### Resolve

```csharp
var audio = CompositeLocator.Resolve<AudioManager>();
```

or

```csharp
var audio = CompositeLocator.Resolve<IAudioManager>();
```

### Unregister

```csharp
CompositeLocator.Unregister<AudioManager>();
```

### Clear All Registrations

```csharp
CompositeLocator.Clear();
```

## Example

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

## Use Cases

* Game development
* Small applications
* Managing global services
* Sharing manager classes
* Projects that do not require a full DI container

## Notes

`Cumin` is a lightweight Service Locator implementation.

It does not provide advanced dependency injection features such as automatic injection, lifetime management, or scoped services. For larger projects, consider using a dedicated DI container where appropriate.

## License

zlib/libpng License
