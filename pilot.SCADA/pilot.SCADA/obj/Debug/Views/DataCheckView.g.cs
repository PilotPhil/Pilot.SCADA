﻿#pragma checksum "..\..\..\Views\DataCheckView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DFF8A12EBA8593B170C3150C8EB2012346DB78D924562A7546298E3D96EB99C9"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Expression.Media;
using HandyControl.Expression.Shapes;
using HandyControl.Interactivity;
using HandyControl.Media.Animation;
using HandyControl.Media.Effects;
using HandyControl.Properties.Langs;
using HandyControl.Themes;
using HandyControl.Tools;
using HandyControl.Tools.Converter;
using HandyControl.Tools.Extension;
using LiveCharts.Wpf;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using pilot.SCADA.Converter;
using pilot.SCADA.Views;


namespace pilot.SCADA.Views {
    
    
    /// <summary>
    /// DataCheckView
    /// </summary>
    public partial class DataCheckView : HandyControl.Controls.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\Views\DataCheckView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal pilot.SCADA.Views.DataCheckView thisWindow;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Views\DataCheckView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton ToggleButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Views\DataCheckView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combox_select;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Views\DataCheckView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_freq;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Views\DataCheckView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_num;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Views\DataCheckView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.CartesianChart chart;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Views\DataCheckView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal LiveCharts.Wpf.Axis axisx;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/pilot.SCADA;component/views/datacheckview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\DataCheckView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.thisWindow = ((pilot.SCADA.Views.DataCheckView)(target));
            return;
            case 2:
            this.ToggleButton = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 3:
            this.combox_select = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.tb_freq = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.tb_num = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.chart = ((LiveCharts.Wpf.CartesianChart)(target));
            return;
            case 7:
            this.axisx = ((LiveCharts.Wpf.Axis)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

