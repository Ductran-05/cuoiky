   M S B A M L   `   `   `  ����B  >doanwpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:doanwpf.controlsdoanwpf.controls  5   	       doanwpf.controls.CTNhap   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:doanwpf.controls     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   !      MaterialDesignBody#���   5      $��Regular"�5	      $��13(�5
      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      
�������  MaterialDesignFont#���  5       � Title$ Detail��5   	   $	��450��6   $	��800��6%   .��5      � #��� ��6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   � $��0��6   ���	#FF192537.+�5      �� $��20,0,0,0q�6   $��20(�6'   #��� ��65   $%��Bahnschrift SemiLight Condensed)�6�   .��6�   Chi tiết hóa đơn5      5      � 5   
   $��1��6   .+�5      �� $��20q�6    �� CornerRadius$ 10��6!   
�������$��1q�6F   
�������._�5      �� .��5      �� $ 50��5       ._�5!      &   System.Windows.Controls.DataGrid  -   5          Name$ dgproductininvoice��5!   7   $��	20,5,20,5q�6$      AutoGenerateColumns .     CanUserAddRows . ��5"      �� *
ctnhaplist+   Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$   "   -   5        mahd��,  &System.Windows.Controls.DataGridColumn	   Header$	 Mã hóa đơn��5$   C   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6p   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6W   �� *MaHD+6p     5%   "   -   5        masp��$	 Mã sản phẩm��5%   C   $
 * 6q    6X   �� *MaSP+6q     5&   "   -   5        soluong��$	 Số Lượng��5&   F   $	
 100 6t    6X   �� *	Soluong+6t     5'   "   -   5        
dongia��$	 
Đơn Giá��5'   E   $	
 100 6q    6V   �� *Dongia+6q     5(   "   -   5        giamgia��$	 Giảm giá��5(   F   $	
 100 6t    6X   �� *	Giamgia+6t     5)   "   -   5        	thanhtien��$	 Thành Tiền��5)   H   $	
 100 6z      
IsReadOnly .  6\   �� *	Thanhtien+6�   5+      5,      5-      5.      50      51      52      