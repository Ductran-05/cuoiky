   M S B A M L   `   `   `  ����B  >doanwpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:doanwpfdoanwpf  5          doanwpf.ProductsControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:doanwpf     5      _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5         MaterialDesignBody#���   5      $��Regular"�5	      $��13(�5
      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5      
�������  MaterialDesignFont#���  5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��4* �6   .+�5   
   � $��0��6   .+�5      �� -   5        $��Thêm sản phẩm��5      $��30��6.   $	��150��6:   ���	#FF192537$��Right=�5      $��Center=�6(   $��0,5,20,5q�6C   6U   �� 5      $
��Left=�6   $��Products��6/   $��Center=�6B   $��20,20,20,20q�6]   $%��Bahnschrift SemiLight Condensed)�5      $��24(�64   ���	#FF192537#��� ��6Y   5      � 5   
   $��1��6   .+�5       #  MaterialDesignThemes.Wpf.Card  .��5!      �� $
��Left=�6   .@�5"      �� $��10,0,0,0q�6   $��Danh sách sản phẩm��60   .��5#      �  5$      �� 5%   "   $
��auto �60   �� 5&   "   .+�5)      �� -   5        $��sptxt��5)   &   $��10,0,0,0q�6S   $��30��6e   $	��150��6q   $	��Top=�6}   $
��Left=�6�    % !MaterialDesignFloatingHintTextBox#��[ 5*      .��6<   )  #MaterialDesignThemes.Wpf.HintAssist   Hint 5+   "   �� 5,   &    �� Orientation$ 
Horizontal=�61   $	��140��6J   .+�5.   *   '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Magnify=�6B   �� 50   *   $��Tìm sản phẩm��64   $��Center=�6H   51   '   .��52   B   53      &   System.Windows.Controls.DataGrid  56      -   5        $��	dgproduct��56   '   $��1��68      AutoGenerateColumns .  $��10q�57   9   -  'MaterialDesignThemes.Wpf.DataGridAssist   CellPadding$ 4 2 2 2q�58         ColumnHeaderPadding$ 4 2 2 2q�59      ��56   E   �� *sanphamlist+	 � ContextMenu	 5:   "   �� 5;   &   -   5        
 ��Name$
 DataGridContextMenu��5;   2   .@�5<   *   m� -   5        $��Chỉnh sửa��5<   3   6F   m� 5=   *   -   5        $	��xoa��5=   3   $
��Xóa��6>   6K   5>   '      Columns 5@   "   0  *System.Windows.Controls.DataGridTextColumn  5A   &   ,  &System.Windows.Controls.DataGridColumn   Header$ Mã Sản Phẩm��69   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6N   �� *MaSP+  5B   &   $ Tên Sản Phẩm��69    6O   �� *TenSP+  5C   &   $ 
Mã loại��69    6J   �� *MaLoai+  5D   &   $ Mã NCC��69    6I   �� *MaNCC+  5E   &   $ 	Giá bán��69    6J   �� *Giaban+  5F   &   $ 
Giá gốc��69    6J   �� *Giagoc+  5G   &   $
 Size��69    6G   �� *Size+  5H   &   $ Mã chất liệu��69    6O   �� *MaCL+4
  .System.Windows.Controls.DataGridTemplateColumn
  5I   &   $ Ảnh��6=    
  CellTemplate 5J   *   �� 5K   .   .R�5L   2   �� $��50��6T   $��50��6_   ��68   �� *
FilePath+6_   5M   /   5O   '   5Q      5T      5U      �� 5V      $��10,0,0,0q�6   $��
Danh mục��60   .��5X      �  5Y      �� 5Z   "   �� 5[   "   $
��auto �60   .+�5]        -   5          Name$ 	dgcatalog��5]   '   $��0��6:    .  $��10q�5^   E   $ 4 2 2 2q�5_   )   $ 4 2 2 2q�5`   )   ��5]   G   �� *loaisanphamlist+	 5a   "   �� 5b   &   .@�5c   *   m� -   5        $��
xoadanhmuc��5c   3   $
��Xóa��6E   6R   5d   '    5f   "     5g   &   $ Mã loại Sản Phẩm��69    6S   �� *Maloai+  5h   &   $ Tên loại Sản Phẩm��69    6T   �� *TenLSP+5k      � 5l      $��1��6#   .+�5m   "   �� -	   5        $��Thêm danh mục��5m   *   $��30��6B   $	��150��6N   ���	#FF192537$��Right=�5n      $��Center=�6   $��0,5,20,5q�68   6J   5o      5p      5r      �� 5s      $��10,0,0,0q�6   $��Chất liệu��60   .��5v      �  5w      �� 5x   "   �� 5y   "   $
��auto �60   .+�5{        -
   5        $ 	dgmateial��5{   '   $��0��6:    .  $��10q�5|   C   $ 4 2 2 2q�5}   '   $ 4 2 2 2q�5~   '   ��5{   G   �� *chatlieulist+	 5   "   �� 5�   &   .@�5�   *   m� -   5        $��xoachatlieu��5�   3   $
��Xóa��6F   6S   5�   '    5�   "     5�   &   $ Mã chất liệu��69    6O   �� *MaCL+  5�   &   $ Tên chất liệu��69    6P   �� *Tenchatlieu+5�      � 5�      $��1��6#   .+�5�   "   �� -   5        $��Thêm chất liệu��5�   *   $��30��6C   $	��150��6O   ���	#FF192537$��Right=�5�      $��Center=�6   $��0,5,20,5q�68   6J   5�      5�      5�      5�      5�      5�      5�      5�      