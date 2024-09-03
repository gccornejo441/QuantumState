using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Runner;
/// <summary>
/// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
///
/// Step 1a) Using this custom control in a XAML file that exists in the current project.
/// Add this XmlNamespace attribute to the root element of the markup file where it is 
/// to be used:
///
///     xmlns:MyNamespace="clr-namespace:QuantumState"
///
///
/// Step 1b) Using this custom control in a XAML file that exists in a different project.
/// Add this XmlNamespace attribute to the root element of the markup file where it is 
/// to be used:
///
///     xmlns:MyNamespace="clr-namespace:QuantumState;assembly=QuantumState"
///
/// You will also need to add a project reference from the project where the XAML file lives
/// to this project and Rebuild to avoid compilation errors:
///
///     Right click on the target project in the Solution Explorer and
///     "Add Reference"->"Projects"->[Browse to and select this project]
///
///
/// Step 2)
/// Go ahead and use your control in the XAML file.
///
///     <MyNamespace:UnitStatusBar/>
///
/// </summary>
public class UnitStatusBar : System.Windows.Controls.Primitives.StatusBar
{
    #region Properties

    private object? currentItem;

    #endregion

    static UnitStatusBar()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(UnitStatusBar),new FrameworkPropertyMetadata(typeof(UnitStatusBar)));
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
