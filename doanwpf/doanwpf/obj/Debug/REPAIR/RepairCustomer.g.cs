﻿#pragma checksum "..\..\..\REPAIR\RepairCustomer.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E6C6DCC5B8D8B8159D2AF87DA8884945A14E1D0D4B19DA5FDB7A19A4EEC5BE07"
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
using doanwpf;


namespace doanwpf.REPAIR {
    
    
    /// <summary>
    /// RepairCustomer
    /// </summary>
    public partial class RepairCustomer : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\..\REPAIR\RepairCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox CustomerName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\REPAIR\RepairCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbNam;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\REPAIR\RepairCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbNu;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\REPAIR\RepairCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Address;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\REPAIR\RepairCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PhoneNum;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\REPAIR\RepairCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Date;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\REPAIR\RepairCustomer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnrepair;
        
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
            System.Uri resourceLocater = new System.Uri("/doanwpf;component/repair/repaircustomer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\REPAIR\RepairCustomer.xaml"
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
            this.CustomerName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.rbNam = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 3:
            this.rbNu = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.Address = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.PhoneNum = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Date = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.btnrepair = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\REPAIR\RepairCustomer.xaml"
            this.btnrepair.Click += new System.Windows.RoutedEventHandler(this.btnrepair_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 90 "..\..\..\REPAIR\RepairCustomer.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
