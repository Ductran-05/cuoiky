   M S B A M L   `   `   `  ����B  >doanwpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:doanwpfdoanwpf  5   	       doanwpf.InfoAccount   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:doanwpf     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   &      MaterialDesignBody#���   5      $��Regular"�5	      $��13(�5
      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      
�������  MaterialDesignFont#���  5       � Title$ InfoAccount��5   	   $	��500��6   $	��400��6*   .��5      �  � RowDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $
��auto �6   .+�5   
   � $��0��6   ���	#FF192537.+�5      #  MaterialDesignThemes.Wpf.Chip  
�������$��50��65   $��20,0,0,0q�6A     MaterialDesignOutlineChip#��[ 5   *   ��6   �� *SelectedAccount.Ten+   Icon 5      '  !MaterialDesignThemes.Wpf.PackIcon  5         Kind$ AccountOutline=�6.   $��25��6D   $��25��6P   5      5      �� 5    
   #��� ��6   $��1��5!      }�.  �� CornerRadius$ 20��6.   $��1q�6@   $��20,20,20,14q�6T   ._�5"      �  5#      �� 5$      �� 5%      �� 5&      �� 5'      �� 5(       � ColumnDefinitions 5*      �� 5+      $
��auto �6'   �� 5,      .+�5.      �� $��20,0,0,0q�6   $��0��6*   $��0��67   $��Tên đăng nhập��6G   $��Right=�6_   $��Center=�5/      �� 50      $��1��6   $��0��6%   $
��Tên��65   $��Right=�6C   $��Center=�51      �� 52      $��2��6   $��0��6%   $��Số điện thoại��65   $��Right=�6M   $��Center=�53      �� 54      $��3��6   $��0��6%   $��Giới tính��65   $��Right=�6I   $��Center=�55      �� 56      $��4��6   $��0��6%   $��
Ngày sinh��65   $��Right=�6I   $��Center=�57      �� 58      -   5         ��Name$ tendangnhap��58      $��0��6/   $��1��6<   $��15q�6L   )  #MaterialDesignThemes.Wpf.HintAssist	   HelperTextFontSize$	 16Q�59      ��58   X   �� *SelectedAccount.TenDangNhap+59      �� 5:      -   5        $	 ten��5:      $��1��6'   $��1��64   $��15q�6D   $	 16Q�5;   
   ��5:   P   �� *SelectedAccount.Ten+5;   
   �� 5<      -   5        $ sodienthoai��5<      $��2��6/   $��1��6<   $��15q�6L   $	 16Q�5=   
   ��5<   X   �� *SelectedAccount.SDT+5=   
   �� 5>      $��3��6   $��1��6*   
 �� Orientation$
 
Horizontal=�6;   .+�5?      	� -   5         	�Name$ rbnam��5?   "    	� 	GroupName$ 1��61   $	��Nam��6?   $��	20,0,20,0q�5A       d� 	IsChecked 5?   M   �� *SelectedAccount.Gioitinh+  GenderConverter �� 	Converter# [  �� ConverterParameter$	 Nam�� �� Mode$ TwoWay=�5A      	� 5B      -   5        $
 rbnu��5B   "   $ 1��60   $
��Nữ��6>    6K   �� *SelectedAccount.Gioitinh+# [ $
 Nữ��$ TwoWay=�5D      (  "System.Windows.Controls.DatePicker  5F      -   5        $
��date��5F      $��4��6)   $��1��66   $
��Left=�5H      $��20,10,15,10q�6(   $	��100��5I         Hint$ 
Ngày sinh��5J      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  ( $MaterialDesignFloatingHintDatePicker#��[ 5L      $��13(�6M      Text 5G      �� *SelectedAccount.Ngaysinh+5L   M   5N      5P      � 5R   
   $��2��6   .+�5S      �� -   5         ��Name$
 save��5S      $��10q�6#   $	��100��60   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��6<    " MaterialDesignRaisedDarkButton#��[ 5U       � ToolTip$7 1MaterialDesignRaisedDarkButton with Round Corners��5V      {�5T      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��5W      �� $
��Lưu��5X      5Y      5Z      5[      5\      