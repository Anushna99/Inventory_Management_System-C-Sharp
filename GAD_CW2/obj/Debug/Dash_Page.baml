   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5      B >GAD_CW2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:GAD_CW2GAD_CW2 5         GAD_CW2.Dash_Page   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      'localclr-namespace:GAD_CW2     5        N� Title$  	Dash_Page��5
       N� 
Background �	#FFF3E3E3.��5      � -   5        .+�5   
   �� $��	Dashboard��6   $
��Left=�6$   $��
10,-14,0,0q�6?   $	��Top=�6S   $	��205��6k   $��74��6w   $��36(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ 
pie_border��5      
�������
���   �$��1,1,1,1q�6L    �� CornerRadius$ 30,30,30,30��6f   $��10,37,698,366.6q�6�   ._�5         LiveCharts.Wpf.PieChart  -   5        &    LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�5         	Hoverable . $��1.2,15.2,9.2,19.6q�6y      DataTooltip 6b   Z�    Series 5         LiveCharts.Wpf.PieSeries  -   5          Name$ tyres��5   $      LiveCharts.Wpf.Series	   Title$	 Tyres��63   
   Values;   5LiveCharts.Wpf.Converters.NumericChartValuesConverter$
 5 6A      
DataLabels .    
LabelPoint 5       �� *
PointLabel+  5      -   5        $ alloy��5   $   $	 Alloy Wheels��63   $
 5 6H    .  5       �� *
PointLabel+  5      -   5        $ lights��5   $   $	 Lights��64   $
 5 6C    .  5       �� *
PointLabel+  5      -   5        $	 oil��5   $   $		 Oil��61   $
 5 6=    .  5       �� *
PointLabel+5      5      �� 5   
   -   5        $ graph_border��5   $   
�������
���   �$��1,1,1,1q�6N   $ 30,30,30,30��6h   $��10,360,10,9.6q�6�   ._�5      #   LiveCharts.Wpf.CartesianChart  $
 Left=�6E   $��0.2,-0.8,0.2,0.4q�6[    6!   �� *SeriesCollection+   AxisX 5          LiveCharts.Wpf.Axis     Title$
 Date��6      Labels 6,   �� *Labels+6H      AxisY 5#        $ Income(Rs.)��6      LabelFormatter 63   �� *	Formatter+6Z   5%      5&      �� 5'   
   -	   5        $��lbl_pie��5'      $��Month Sales��6   $
��Left=�65   $��	65,31,0,0q�6P   $	��Top=�6c   $
��Bold"�6{   $��14(�6�   �� 5(   
   -
   5         ��Name$ lbl_date��5(      $�� ��6"   $
��Left=�6-   $��
331,48,0,0q�6H   $	��Top=�6\    J� RenderTransformOrigin$ 0.323,0.489&�6t   $
��Bold"�6�   $��36(�6�   ���	#FFC50D0D��6�   Z� 6�   �� 5)   
   -   5        $ lbl_day��5)      $�� ��6!   $
��Left=�6,   $��
759,48,0,0q�6G   $	��Top=�6[   $��36(�6s   $
��Bold"�6�   ���	#FFC50D0D6�   �� 5*   
   $��,��6   $
��Left=�6   $��
749,48,0,0q�67   $	��Top=�6K   $
��Bold"�6c   $��36(�6u   ���	#FFC50D0D6�   �� 5+   
   -   5        $ 	lbl_graph��5+      $"��Daily Income Of Last 30 Days��6#   $
��Left=�6J   $��467,323,0,0q�6e   $	��Top=�6z   $
��Bold"�6�   $��18(�6�   �� 5,   
   $��,��6   $
��Left=�6   $��
522,48,0,0q�67   $	��Top=�6K   $��36(�6c   $
��Bold"�6q   ���	#FFB404046�   5/      50      