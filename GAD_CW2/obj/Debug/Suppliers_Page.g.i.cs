﻿#pragma checksum "..\..\Suppliers_Page.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AA43CCFB0372288DF22A04D9F24C53820B099C05D2098A7E80850E725FFE11E5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GAD_CW2;
using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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


namespace GAD_CW2 {
    
    
    /// <summary>
    /// Suppliers_Page
    /// </summary>
    public partial class Suppliers_Page : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\Suppliers_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.Tile tile_add;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Suppliers_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.Tile tile_view;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Suppliers_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.Tile tile_update;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Suppliers_Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame pages;
        
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
            System.Uri resourceLocater = new System.Uri("/GAD_CW2;component/suppliers_page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Suppliers_Page.xaml"
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
            this.tile_add = ((MahApps.Metro.Controls.Tile)(target));
            
            #line 16 "..\..\Suppliers_Page.xaml"
            this.tile_add.Click += new System.Windows.RoutedEventHandler(this.tile_add_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tile_view = ((MahApps.Metro.Controls.Tile)(target));
            
            #line 17 "..\..\Suppliers_Page.xaml"
            this.tile_view.Click += new System.Windows.RoutedEventHandler(this.tile_view_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tile_update = ((MahApps.Metro.Controls.Tile)(target));
            
            #line 18 "..\..\Suppliers_Page.xaml"
            this.tile_update.Click += new System.Windows.RoutedEventHandler(this.tile_update_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.pages = ((System.Windows.Controls.Frame)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

