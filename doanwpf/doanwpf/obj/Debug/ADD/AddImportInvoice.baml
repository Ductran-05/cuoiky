   M S B A M L   `   `   `  ����B  >doanwpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:doanwpfdoanwpf  5   	   "    doanwpf.ADD.AddImportInvoice   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5       R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:doanwpf     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5      $��Regular"�5	      $��13(�5
      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      
�������  MaterialDesignFont#���  5       � Title$ 
AddProduct��5   	   $	��450��6   $	��800��6)   .��5      � #��� ��6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   � $��0��6   ���	#FF192537.+�5      �� $��20,0,0,0q�6   $��20(�6'   #��� ��65   $%��Bahnschrift SemiLight Condensed)�6�   .��6�   Thông tin đơn nhập hàng5      5      � 5   
   $��1��6   .+�5      �� $��20q�6    �� CornerRadius$ 10��6!   
�������$��1q�6F   
�������._�5      �� .��5      �� $��40q�6!   
�������.+�5       �� -   5        $��manvcbb��5    #   $��	20,0,20,0q�62   $��72��5!      )  #MaterialDesignThemes.Wpf.HintAssist   
FontFamily$ Verdana)�5"         Hint$ Mã nhân viên��5#       & "MaterialDesignFloatingHintComboBox#��[ 5$      .@�5%      �� $	��op1��6+   5&      (  "System.Windows.Controls.DatePicker  5'      -   5        $
��date��5'   %   $
��Left=�61   $��20,0,0,0q�6L   $	��100��5(      $ Ngày hóa đơn��5)      .  (MaterialDesignThemes.Wpf.TextFieldAssist   HasClearButton .  ( $MaterialDesignFloatingHintDatePicker#��[ 5+      $��13(�6W   �� 5,      -   5        $��mancccbb��5,   #   $��	20,0,20,0q�63   $��72��5-      $ Verdana)�5.      $ Mã nhà cung cấp��5/      #��[ 50      51      � 52      .+�53      �� $��Right=�6)    �� Orientation$ 
Horizontal=�6E   .+�54   "   �� -   5        $	��100��54   )   $��30��65   $��10q�6A   +  %MaterialDesignThemes.Wpf.ButtonAssist	   CornerRadius$	 15��55   !    " MaterialDesignRaisedDarkButton#��[ 57   !   
 � ToolTip$7
 1MaterialDesignRaisedDarkButton with Round Corners��58   !   {�56   !   �� *DataContext.ControlsEnabled+ �� RelativeSource �� *FindAncestor+ �� AncestorType$ WindowL�.��59   &   �� $��Thêm��60   5:   #   5;      5<      �� 5=      $	��200��6!   $ 50��5>   !   ._�5?      &   System.Windows.Controls.DataGrid  -   5          Name$ dgproductininvoice��5?   M      
IsReadOnly . $��	20,5,20,5q�6:      AutoGenerateColumns .     CanUserAddRows . ��5@   (   �� *
listcthd+   Columns 5B   "   0  *System.Windows.Controls.DataGridTextColumn  5C   &   ,  &System.Windows.Controls.DataGridColumn   Header$ Mã sản phẩm��69      Width5	  /System.Windows.Controls.DataGridLengthConverter$ *	 6g   1
  +System.Windows.Controls.DataGridBoundColumn 
  Binding 6N   �� *MaSP+6g     5D   &   $ Số Lượng��69   $	 100	 6g    6K   �� *	Soluong+6g     5E   &   $ 
Đơn Giá��69   $	 100	 6e    6J   �� *Dongia+6e     5F   &   $ Giảm giá��69   $	 100	 6g    6K   �� *	Giamgia+6g     5G   &   $ Thành Tiền��69   $	 100	 6k      
IsReadOnly .  6M   �� *	Thanhtien+6w   5I      5J      5L      5M      5N      5P      � 5Q   
   $��2��6   .+�5R      �� $��Center=�6   $ 
Horizontal=�66   .+�5S      �� -   5        $	��200��5S      $��50��6%   $��10q�61   $	 25��5T      #��[ 5V      $7
 1MaterialDesignRaisedDarkButton with Round Corners��5W      {�5U      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�.��5X      �� $��Thêm��5Y      5Z      �� 5[      -   5        $	��200��5[      $��50��6%   $��10q�61   $	 25��5\      #��[ 5^      $7
 1MaterialDesignRaisedDarkButton with Round Corners��5_      {�5]      �� *DataContext.ControlsEnabled+ �� *FindAncestor+$ WindowL�.��5`      �� $��Hủy��5a      5b      5c      5d      5e      5f      