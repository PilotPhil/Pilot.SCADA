   M S B A M L   `   `   `  ����  pilot.SCADA"    pilot.SCADA.Views.SerialView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   S OHandyControl, Version=3.2.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   -   5        "  HandyControl.Controls.Window   Name$  
thisWindow��5	   .    � Title$ 串口设置��5   	   $	��280��6   $	��200��6#   $��Microsoft YaHei)�6/   $��
ExtraLight"�6L    � WindowStartupLocation$ CenterScreen=�5	   	   
������� � 
ResizeMode$ NoResize=�5
   	    � DataContext 5   	   ��    Locator �� Source# [   �� Path$ 	SerialCom�   NonClientAreaBackground 5      �� 5   
    �� EndPoint$ 1.002,0.498&�5      	 �� 
StartPoint$	 -0.024,0.502&�6$   .��5      � 
 � Color$
 #f5f6ff��6    � Offset$	 0.1Q�6+   � 5      $
 #aabcff��6   $	 0.6Q�6+   � 5      $
 #a3b6ff��6   $
 0.99Q�6+   5      .��5      � $��5q�6    � ColumnDefinitions 5   
   �� 5      $��50 �6   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $
��Auto �6   �� 5!      $
��Auto �6   �� 5"      $
��Auto �6   �� 5#      $
��Auto �6   .+�5&   
   �� $��0��6   $��0��6!   $��端口��61   $��Center=�6;   $��Center=�6V   �� 5'   
   -   5         ��Name$
 Port��5'   0   $��0��6   $��1��6    $	��120��6>   $��20��6J   $��5q�6V   ��5(   !   �� *SerialModel.PortList+ �� SelectedItem 5)   !   �� *SerialModel.PortName+�� 5+   
   $��	波特率��6   $��1��6   $��0��6,   $��Center=�6<   $��Center=�6W   �� 5,   
   -   5        $ BaudRate��5,   0   $��1��6   $��1��6    $	��120��6B   $��20��6N   $��5q�6Z   ��5-   !   �� *SerialModel.BaudRateList+ 5.      �� *SerialModel.BaudRate+�� 50   
   $��	数据位��6   $��2��6   $��0��6,   $��Center=�6<   $��Center=�6W   �� 51   
   -   5        $ DataBit��51   0   $��2��6   $��1��6    $	��120��6A   $��20��6M   $��5q�6Y   ��52   !   �� *SerialModel.DataBitList+ 53      �� *SerialModel.DataBit+�� 55   
   $��	校验位��6   $��3��6   $��0��6,   $��Center=�6<   $��Center=�6W   �� 56   
   -   5        $ Parity��56   0   $��3��6   $��1��6    $	��120��6@   $��20��6L   $��5q�6X   ��57   !   �� *SerialModel.ParityList+ 58      �� *SerialModel.Parity+�� 5:   
   $��	停止位��6   $��4��6   $��0��6,   $��Center=�6<   $��Center=�6W   �� 5;   
   -   5        $ StopBit��5;   0   $��4��6   $��1��6    $	��120��6A   $��20��6M   $��5q�6Y   ��5<   !   �� *SerialModel.StopBitList+ 5=      �� *SerialModel.StopBit+�� 5?   
   $��确定��6   $��5��6   $��1��6+   $��5q�6;   $	��120��6F   $��30��6R   ��5@      �� *ConfirmCommand+��5A      ��  �� ElementName$ 
thisWindow��5B      5C      