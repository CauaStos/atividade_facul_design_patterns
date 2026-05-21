namespace BridgePattern;

public interface IDevice
{
    string Name { get; }
    bool IsEnabled { get; }
    int Volume { get; }
    void Enable();
    void Disable();
    void SetVolume(int volume);
}

public sealed class Tv : IDevice
{
    public string Name => "TV";
    public bool IsEnabled { get; private set; }
    public int Volume { get; private set; } = 20;

    public void Enable()
    {
        IsEnabled = true;
    }

    public void Disable()
    {
        IsEnabled = false;
    }

    public void SetVolume(int volume)
    {
        Volume = Math.Clamp(volume, 0, 100);
    }
}

public sealed class Radio : IDevice
{
    public string Name => "Radio";
    public bool IsEnabled { get; private set; }
    public int Volume { get; private set; } = 10;

    public void Enable()
    {
        IsEnabled = true;
    }

    public void Disable()
    {
        IsEnabled = false;
    }

    public void SetVolume(int volume)
    {
        Volume = Math.Clamp(volume, 0, 100);
    }
}

public sealed class RemoteControl
{
    private readonly IDevice _device;

    public RemoteControl(IDevice device)
    {
        _device = device;
    }

    public void Power()
    {
        if (_device.IsEnabled)
        {
            _device.Disable();
            return;
        }

        _device.Enable();
    }

    public void VolumeUp()
    {
        _device.SetVolume(_device.Volume + 10);
    }

    public void Status()
    {
        string power = _device.IsEnabled ? "ligado" : "desligado";
        Console.WriteLine($"{_device.Name} esta {power} com volume {_device.Volume}");
    }
}

internal static class Program
{
    private static void Main()
    {
        RemoteControl tvRemote = new(new Tv());
        RemoteControl radioRemote = new(new Radio());

        tvRemote.Power();
        tvRemote.VolumeUp();

        radioRemote.Power();
        radioRemote.VolumeUp();
        radioRemote.VolumeUp();

        tvRemote.Status();
        radioRemote.Status();
    }
}
