using Avalonia;
using Avalonia.Controls;

namespace ToDo.Desktop.Components;

public partial class InputComponent : UserControl
{
    public static readonly StyledProperty<object> LabelContentProperty =
        AvaloniaProperty.Register<InputComponent, object>(nameof(LabelContent));

    public static readonly StyledProperty<string> InputTextProperty =
        AvaloniaProperty.Register<InputComponent, string>(nameof(InputText));
    public static readonly StyledProperty<string> PlaceholderProperty =
        AvaloniaProperty.Register<InputComponent, string>(nameof(Placeholder));
    public static readonly StyledProperty<bool> IsReadOnlyProperty =
        AvaloniaProperty.Register<InputComponent, bool>(nameof(IsReadOnly));
    public object LabelContent
    {
        get => GetValue(LabelContentProperty);
        set => SetValue(LabelContentProperty, value);
    }

    public string InputText
    {
        get => GetValue(InputTextProperty);
        set => SetValue(InputTextProperty, value);
    }

    public string Placeholder
    {
        get => GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public bool IsReadOnly
    {
        get => GetValue(IsReadOnlyProperty);
        set => SetValue(IsReadOnlyProperty, value);
    }

    public InputComponent()
    {
        InitializeComponent();
    }
}
