﻿#pragma checksum "..\..\..\ADD\CTHDwindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E3A4A03A93DCB75A3A940AE3D77AE5539BB845E9871B5B864B3A3D928ED72CD6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using doanwpf.controls;


namespace doanwpf.controls {
    
    
    /// <summary>
    /// CTHDwindow
    /// </summary>
    public partial class CTHDwindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\ADD\CTHDwindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgproductininvoice;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\ADD\CTHDwindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn mahd;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\ADD\CTHDwindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn masp;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\ADD\CTHDwindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn soluong;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\ADD\CTHDwindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn dongia;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\ADD\CTHDwindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn giamgia;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\ADD\CTHDwindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn thanhtien;
        
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
            System.Uri resourceLocater = new System.Uri("/doanwpf;component/add/cthdwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ADD\CTHDwindow.xaml"
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
            this.dgproductininvoice = ((System.Windows.Controls.DataGrid)(target));
            
            #line 34 "..\..\..\ADD\CTHDwindow.xaml"
            this.dgproductininvoice.Loaded += new System.Windows.RoutedEventHandler(this.dgproductininvoice_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mahd = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 3:
            this.masp = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 4:
            this.soluong = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 5:
            this.dongia = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 6:
            this.giamgia = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 7:
            this.thanhtien = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
