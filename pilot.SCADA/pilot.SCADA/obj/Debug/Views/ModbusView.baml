   M S B A M L   `   `   `  ����F  Bpilot.SCADA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:pilot.SCADA.Viewspilot.SCADA.Views  5   	   =#clr-namespace:pilot.SCADA.Converterpilot.SCADA.Converter  5   	   "    pilot.SCADA.Views.ModbusView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:pilot.SCADA.Views     5   	   2cv#clr-namespace:pilot.SCADA.Converter     5   	   S OHandyControl, Version=3.2.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   -   5        "  HandyControl.Controls.Window   Name$  
thisWindow��5   B    � Title$ Modbus设置��5
   	   $	��270��6   $	��220��6'   $��Microsoft YaHei)�63   $��
ExtraLight"�6P    � WindowStartupLocation$ CenterScreen=�5   	   
������� � 
ResizeMode$ NoResize=�6V    � DataContext 5   	   ��    Locator �� Source# [   �� Path$ Modbus� � 	Resources 5      0   *pilot.SCADA.Converter.InverseBoolConverter  ibc��%   &	         5   
   6"   5         NonClientAreaBackground 5      �� 5   
   	 �� EndPoint$	 1.002,0.498&�5      
 �� 
StartPoint$
 -0.024,0.502&�6$   .��5      �  � Color$ #f5f6ff��6    � Offset$	 0.1Q�6+   � 5      $ #aabcff��6   $	 0.6Q�6+   � 5      $ #a3b6ff��6   $
 0.99Q�6+   5      .��5      � $��5q�6    � ColumnDefinitions 5   
   �� 5      $��70 �6   �� 5       � RowDefinitions 5!   
   �� 5"      $
��Auto �6   �� 5#      $
��Auto �6   �� 5$      $
��Auto �6   �� 5%      $
��Auto �6   �� 5&      $
��Auto �6   �� 5'      $
��Auto �6   .+�5*   
   �� $��从站地址��6   $��0��6    $��0��6-   $��Center=�6=   $��Center=�6X   �� 5+   
   $��0��6   $��1��6   $	��120��6T   $��20��6`   $��5q�6l   ��6/   �� *ModbusModel.SlaveId+6l   �� 5-   
   $��起始地址��6   $��1��6    $��0��6-   $��Center=�6=   $��Center=�6X   �� 5.   
   $��1��6   $��1��6   $	��120��6V   $��20��6b   $��5q�6n   ��6/   �� *ModbusModel.StartAddr+6n   �� 50   
   $��读取数量��6   $��2��6    $��0��6-   $��Center=�6=   $��Center=�6X   �� 51   
   $��2��6   $��1��6   $	��120��6T   $��20��6`   $��5q�6l   ��6/   �� *ModbusModel.ReadNum+6l   �� 53   
   $��	扫描率��6   $��3��6   $��0��6,   $��Center=�6<   $��Center=�6W   �� 54   
   $��3��6   $��1��6   $	��120��6z   $��20��6�   $��5q�6�   ��6/   �� *ModbusModel.ScanRate+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 56   
   $��4��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��5q�6K   $��Center=�6V   .+�57      �� $	��Rtu��6   $��60��6N    d� 	IsChecked 6%   �� *ModbusModel.UseRtu+6N   �� 58      $��Ascii��6   $��60��6q    6'   �� *ModbusModel.UseRtu+ �� 	Converter# [ 6q   59      �� 5;   
   $��确定��6   $��5��6   $��1��6+   $	��120��6;   $��30��6G   $��5q�6S   ��5<      �� *ConfirmCommand+��5=      ��  �� ElementName$ 
thisWindow��5>      5?      