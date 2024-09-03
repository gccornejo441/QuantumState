using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuantumState;

public class UnitStatusBar : System.Windows.Controls.Primitives.StatusBar
{
    #region Properties

    private object? currentItem;

    #endregion
    static UnitStatusBar()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(UnitStatusBar),new FrameworkPropertyMetadata(typeof(UnitStatusBar)));
    }

    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        var isItemItsOwnContainerOverride = item is UnitStatusBarComponent || item is Separator;

        if (isItemItsOwnContainerOverride == false)
        {
            this.currentItem = item;
        }

        return isItemItsOwnContainerOverride;
    }

    public static readonly DependencyProperty StatusMessageProperty =
    DependencyProperty.Register("StatusMessage",typeof(string),typeof(UnitStatusBar),new PropertyMetadata("Ready"));

    public static readonly DependencyProperty IsBusyProperty =
    DependencyProperty.Register(
        nameof(IsBusy),
        typeof(bool),
        typeof(UnitStatusBar),
        new PropertyMetadata(false,OnIsBusyChanged));

    private static void OnIsBusyChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
    {
        var control = (UnitStatusBar)d;
        bool newValue = (bool)e.NewValue;
        // Log or debug here
        Console.WriteLine($"IsBusy changed to {newValue}");
    }

    public bool IsBusy
    {
        get { return (bool)GetValue(IsBusyProperty); }
        set { SetValue(IsBusyProperty,value); }
    }

    public string StatusMessage
    {
        get { return (string)GetValue(StatusMessageProperty); }
        set { SetValue(StatusMessageProperty,value); }
    }

    public static readonly DependencyProperty ProgressValueProperty =
        DependencyProperty.Register("ProgressValue",typeof(double),typeof(UnitStatusBar),new PropertyMetadata(0.0));

    public double ProgressValue
    {
        get { return (double)GetValue(ProgressValueProperty); }
        set { SetValue(ProgressValueProperty,value); }
    }

    public static readonly DependencyProperty IsProgressVisibleProperty =
        DependencyProperty.Register("IsProgressVisible",typeof(bool),typeof(UnitStatusBar),new PropertyMetadata(false));

    public bool IsProgressVisible
    {
        get { return (bool)GetValue(IsProgressVisibleProperty); }
        set { SetValue(IsProgressVisibleProperty,value); }
    }
}
