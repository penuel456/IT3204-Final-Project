﻿#pragma checksum "..\..\..\View\addProduct.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CDE26C76A47CDE28C708D8931C691CDD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using JGP_INVENTORY.View;
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


namespace JGP_INVENTORY.View {
    
    
    /// <summary>
    /// addProduct
    /// </summary>
    public partial class addProduct : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\View\addProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox prodPrice;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\View\addProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox prodName;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\View\addProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button insertBtn;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\View\addProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backBtn;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\View\addProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox prodQty;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\View\addProduct.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock notif;
        
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
            System.Uri resourceLocater = new System.Uri("/JGP_INVENTORY;component/view/addproduct.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\addProduct.xaml"
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
            
            #line 12 "..\..\..\View\addProduct.xaml"
            ((JGP_INVENTORY.View.addProduct)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.prodPrice = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.prodName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.insertBtn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\View\addProduct.xaml"
            this.insertBtn.Click += new System.Windows.RoutedEventHandler(this.insertBtn_Click_1);
            
            #line default
            #line hidden
            return;
            case 5:
            this.backBtn = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\View\addProduct.xaml"
            this.backBtn.Click += new System.Windows.RoutedEventHandler(this.backBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.prodQty = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.notif = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

