   M S B A M L   `   `   `  ����B  >GAD_CW2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:GAD_CW2GAD_CW2  5          GAD_CW2.Add_Supplier   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:GAD_CW2     5        N� Title$  Add_Supplier��5	       N� 
Background �	#FFE7E49F.��5      � .+�5   
   �� $��Add Supplier��6   $
��Left=�6'   $	��Top=�6B   $��36(�6Z   $
��Bold"�6h   �� 5   
   $��Supplier's name��6   $
��Left=�6*   $��
28,108,0,0q�6E   $	��Top=�6Y   $��24(�6q   $
��Bold"�6   �� 5   
   $��Email��6   $
��Left=�6    $��
28,297,0,0q�6;   $	��Top=�6O   $��24(�6g   $
��Bold"�6u   �� 5   
   $��Telephone No.��6   $
��Left=�6(   $��
28,227,0,0q�6C   $	��Top=�6W   $��24(�6o   $
��Bold"�6}   �� 5   
   $��Address��6   $
��Left=�6"   $��
28,167,0,0q�6=   $	��Top=�6Q   $��24(�6i   $
��Bold"�6w   �� 5   
   -   5         ��Name$ txt_name��5      $
��Left=�6$   $��31��6?   $��256,108,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��154��6�   .��6�   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property �@��CharacterCasing �� Value$ Lower=�68    �� Triggers 5      �� 5       �� Binding 6&   �� *Text.Length+	 �� RelativeSource	 �� *Self+
 �� Value
 06k   .a�5      ��  �@��CharacterCasing$ Upper=�6@   5      5      .��5      5      �� 5   
   -   5        $ txt_mail��5      $
��Left=�6$   $��31��6?   $��256,297,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��154��6�   6�   �� 5   
   -   5        $ txt_tp��5      $
��Left=�6"   $��31��6=   $��256,227,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $	��154��6�   6�   �� 5   
   -   5        $ txt_address��5      $
��Left=�6'   $��31��6B   $��256,167,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $	��154��6�   6�   �� 5    
   -   5         ��Name$ 
btn_submit��5       $��Submit��6%   $
��Left=�66   $��470,362,0,0q�6Q   $	��Top=�6f   $��92��6~   $��20(�6�   ���	#FF89D4676�   �� 5!   
   -   5         ��Name$ lbl_address��5!      $�� ��6%   $
��Left=�60   $��457,172,0,0q�6K   $	��Top=�6`   ���	#FFF707076x   �� 5"   
   -   5        $ lbl_tp��5"      $�� ��6    $
��Left=�6+   $��457,232,0,0q�6F   $	��Top=�6[   ���	#FFFA0B0B6s   �� 5#   
   -   5        $ lbl_mail��5#      $�� ��6"   $
��Left=�6-   $��457,302,0,0q�6H   $	��Top=�6]   ���	#FFF908086u   �� 5$   
   -	   5        $ lbl_name��5$      $�� ��6"   $
��Left=�6-   $��457,113,0,0q�6H   $	��Top=�6]   ���	#FFFA0A0A6u   5&      5'      