   M S B A M L   `   `   `  ����B  >doanwpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:doanwpfdoanwpf  5   	   #    doanwpf.REPAIR.RepairEmployee   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:doanwpf     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5      $��Regular"�5	      $��13(�5
      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      
�������  MaterialDesignFont#���  5       � Title$ RepairEmployee��5   	   $	��450��6    $	��800��6-   .��5      � #��� ��6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   � $��0��6   ���	#FF192537.+�5      �� $��20,0,0,0q�6   $��20(�6'   #��� ��65   $%��Bahnschrift SemiLight Condensed)�6�   .��6�   Thông tin nhân viên5      5      � 5   
   $��1��6   .+�5      �� $��20q�6    �� CornerRadius$ 10��6!   
�������$��1q�6F   
�������._�5      �� .��5      �� $��40q�6!   
�������.+�5       �� -   5         ��Name$ emplname��5    "   $��20,0,0,0q�5"   "   $��Center=�64   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tên nhân viên��5#       % !MaterialDesignFloatingHintTextBox#��[ 5$      $��13(�6I   ��5!   "   �� *TenNV+5$   I   	� 5%      -   5         	�Name$ rbNam��5%   &   $	��Nam��5(   &    	� 	GroupName$ Gender��64   $��12(�6G   $��	20,10,0,0q�5)      	 d� 	IsChecked	 5&   /   �� *
Gioitinh+  GenderConverter
 �� 	Converter#
 [  �� ConverterParameter$	 Nam�� �� Mode$ TwoWay=�5)      	� 5*      -   5        $
 rbNu��5*   &   $
��Nữ��5-   &   $ Gender��63   $��12(�6F   $��	20,0,0,10q�5.      	 5+   /   �� *
Gioitinh+#
 [ $
 Nữ��$ TwoWay=�5.      �� 5/      -   5        $ address��5/   "   $��20,0,0,0q�51   "   $��Center=�64   $ Địa chỉ��52      #��[ 53      $��13(�6<   ��50   "   �� *Diachi+53   <   �� 54      -   5        $ phonenum��54   "   $��20,0,0,0q�56   "   $��Center=�64   $ Số điện thoại��57      #��[ 58      $��13(�6<   ��55   "   �� *	Dienthoai+58   <   (  "System.Windows.Controls.DatePicker  59      -   5        $
��date��59   %   $
��Left=�5;   %   $��20,0,0,0q�6@   $	��100��5<      $ 
Ngày sinh��5=      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  ( $MaterialDesignFloatingHintDatePicker#��[ 5?      $��13(�6A      Text 5:   %   �� *
Ngaysinh+5?   A   5@      5A      5B      5D      � 5E   
   $��2��6   .+�5F      �� $��Center=�6    �� Orientation$ 
Horizontal=�66   .+�5G      �� -   5         ��Name$ repair��5G      $	��200��6>   $��50��6J   $��10q�6V   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 25��5H       " MaterialDesignRaisedDarkButton#��[ 5J       � ToolTip$7 1MaterialDesignRaisedDarkButton with Round Corners��5K      {�5I      �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��5L      �� $��Cập nhật��5M      5N      �� 5O      -   5        $	��200��5O      $��50��6&   $��10q�62   $ 25��5P      #��[ 5R      $7 1MaterialDesignRaisedDarkButton with Round Corners��5S      {�5Q      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�.��5T      �� $��Hủy��5U      5V      5W      5X      5Y      5Z      