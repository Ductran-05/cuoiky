   M S B A M L   `   `   `  ����B  >doanwpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:doanwpfdoanwpf  5   	   #    doanwpf.REPAIR.RepairCustomer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:doanwpf     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      
�������  MaterialDesignFont#���  5       � Title$ RepairCustomer��5   	   $	��450��6    $	��800��6-   .��5      � #��� ��6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   � $��0��6   ���	#FF192537.+�5      �� $��20,0,0,0q�6   $��20(�6'   #��� ��65   $%��Bahnschrift SemiLight Condensed)�6�   .��6�   Thông tin khách hàng5      5      � 5   
   $��1��6   .+�5      �� $��20q�6    �� CornerRadius$ 10��6!   
�������$��1q�6F   
�������._�5      �� .��5       �� $��40q�6!   
�������.+�5"      �� -   5        $��CustomerName��5$      $��20,0,0,0q�61   $��Center=�6C   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên khách hàng��5%       % !MaterialDesignFloatingHintTextBox#��[ 5&      $��13(�6I   ��5#      �� *TenKH+5&   I   	� 5(      -   5         	�Name$ rbNam��5(   &   $	��Nam��5+   &    	� 	GroupName$ Gender��64   $��12(�6G   $��	20,10,0,0q�5,       d� 	IsChecked 5)   &   �� *
Gioitinh+  GenderConverter	 �� 	Converter#	 [ 
 �� ConverterParameter$	
 Nam�� �� Mode$ TwoWay=�5,      	� 5.      -   5        $
 rbNu��5.   &   $
��Nữ��51   &   $ Gender��63   $��12(�6F   $��	20,0,0,10q�52       5/   '   �� *
Gioitinh+#	 [ $

 Nữ��$ TwoWay=�52      �� 54      -   5        $��Address��54   "   $��20,0,0,0q�56   "   $��Center=�64   $ Địa chỉ��57   !   #��[ 58   !   $��13(�6\   ��55   "   �� *Diachi+58   \   �� 5:      -   5        $��PhoneNum��5:   "   $��20,0,0,0q�5<   "   $��Center=�64   $ Số điện thoại��5=   !   #��[ 5>   !   $��13(�6\   ��5;   "   �� *SDT+5>   \   (  "System.Windows.Controls.DatePicker  5@      -   5        $
��Date��5@   %   $
��Left=�5B   %   $��20,0,0,0q�6@   $	��100��5C   '   $ 
Ngày sinh��5D   '   .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  ( $MaterialDesignFloatingHintDatePicker#��[ 5F   '   $��13(�6e      Text 5A   %   �� *
Ngaysinh+5F   e   5G      5H      5I      5K      � 5L   
   $��2��6   .+�5M      �� $��Center=�6    �� Orientation$ 
Horizontal=�66   .+�5N      �� -   5         ��Name$ 	btnrepair��5N      $	��200��6D   $��50��6P   $��10q�6\   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��5O       " MaterialDesignRaisedDarkButton#��[ 5Q       � ToolTip$7 1MaterialDesignRaisedDarkButton with Round Corners��5R      {�5P      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��5S      �� $��Cập nhật��5T      5U      �� 5V      -   5        $	��200��5V      $��50��6%   $��10q�61   $ 25��5W      #��[ 5Y      $7 1MaterialDesignRaisedDarkButton with Round Corners��5Z      {�5X      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�.��5[      �� $��Hủy��5\      5]      5^      5_      5`      5a      