   M S B A M L   `   `   `  ���� F  Bpilot.SCADA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:pilot.SCADA.Viewspilot.SCADA.Views  =#clr-namespace:pilot.SCADA.Converterpilot.SCADA.Converter  "    pilot.SCADA.Views.ModbusView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:pilot.SCADA.Views     2cv#clr-namespace:pilot.SCADA.Converter     S OHandyControl, Version=3.2.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  -   "  HandyControl.Controls.Window   Name$  
thisWindow�� � Title$ Modbus设置��$	��270��$	��220��$��Microsoft YaHei)�$��
ExtraLight"� � WindowStartupLocation$ CenterScreen=�
������� � 
ResizeMode$ NoResize=� � DataContext ��    Locator �� Source# [   �� Path$ Modbus� � 	Resources 0   *pilot.SCADA.Converter.InverseBoolConverter  ibc��%   &	            NonClientAreaBackground �� 	 �� EndPoint$	 1.002,0.498&�
 �� 
StartPoint$
 -0.024,0.502&�.���  � Color$ #f5f6ff�� � Offset$	 0.1Q�� $ #aabcff��$	 0.6Q�� $ #a3b6ff��$
 0.99Q�.��� $��5q� � ColumnDefinitions �� $��70 ���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��从站地址��$��0��$��0��$��Center=�$��Center=��� $��0��$��1��$	��120��$��20��$��5q����� *ModbusModel.SlaveId+�� $��起始地址��$��1��$��0��$��Center=�$��Center=��� $��1��$��1��$	��120��$��20��$��5q����� *ModbusModel.StartAddr+�� $��读取数量��$��2��$��0��$��Center=�$��Center=��� $��2��$��1��$	��120��$��20��$��5q����� *ModbusModel.ReadNum+�� $��	扫描率��$��3��$��0��$��Center=�$��Center=��� $��3��$��1��$	��120��$��20��$��5q����� *ModbusModel.ScanRate+ �� UpdateSourceTrigger$ PropertyChanged=��� $��4��$��1�� �� Orientation$ 
Horizontal=�$��5q�$��Center=�.+��� $	��Rtu��$��60�� d� 	IsChecked �� *ModbusModel.UseRtu+�� $��Ascii��$��60�� �� *ModbusModel.UseRtu+ �� 	Converter# [ �� $��确定��$��5��$��1��$	��120��$��30��$��5q����� *ConfirmCommand+����  �� ElementName$ 
thisWindow��