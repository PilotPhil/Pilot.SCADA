   M S B A M L   `   `   `  ����   pilot.SCADA"    pilot.SCADA.Views.SerialView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     S OHandyControl, Version=3.2.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  -   "  HandyControl.Controls.Window   Name$  
thisWindow�� � Title$ 串口设置��$	��280��$	��200��$��Microsoft YaHei)�$��
ExtraLight"� � WindowStartupLocation$ CenterScreen=�
������� � 
ResizeMode$ NoResize=� � DataContext ��    Locator �� Source# [   �� Path$ 	SerialCom�   NonClientAreaBackground ��  �� EndPoint$ 1.002,0.498&�	 �� 
StartPoint$	 -0.024,0.502&�.��� 
 � Color$
 #f5f6ff�� � Offset$	 0.1Q�� $
 #aabcff��$	 0.6Q�� $
 #a3b6ff��$
 0.99Q�.��� $��5q� � ColumnDefinitions �� $��50 ���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��端口��$��Center=�$��Center=��� -    ��Name$
 Port��$��0��$��1��$	��120��$��20��$��5q����� *SerialModel.PortList+ �� SelectedItem �� *SerialModel.PortName+�� $��	波特率��$��1��$��0��$��Center=�$��Center=��� -   $ BaudRate��$��1��$��1��$	��120��$��20��$��5q����� *SerialModel.BaudRateList+ �� *SerialModel.BaudRate+�� $��	数据位��$��2��$��0��$��Center=�$��Center=��� -   $ DataBit��$��2��$��1��$	��120��$��20��$��5q����� *SerialModel.DataBitList+ �� *SerialModel.DataBit+�� $��	校验位��$��3��$��0��$��Center=�$��Center=��� -   $ Parity��$��3��$��1��$	��120��$��20��$��5q����� *SerialModel.ParityList+ �� *SerialModel.Parity+�� $��	停止位��$��4��$��0��$��Center=�$��Center=��� -   $ StopBit��$��4��$��1��$	��120��$��20��$��5q����� *SerialModel.StopBitList+ �� *SerialModel.StopBit+�� $��确定��$��5��$��1��$��5q�$	��120��$��30������ *ConfirmCommand+����  �� ElementName$ 
thisWindow��