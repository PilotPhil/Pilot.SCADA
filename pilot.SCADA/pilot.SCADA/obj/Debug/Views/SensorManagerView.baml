   M S B A M L   `   `   `  ����F  Bpilot.SCADA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:pilot.SCADA.Viewspilot.SCADA.Views  5   	   )    #pilot.SCADA.Views.SensorManagerView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:pilot.SCADA.Views     5   	   S OHandyControl, Version=3.2.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   -   5        "  HandyControl.Controls.Window   Name$  
thisWindow��5
   A    � Title$ 传感器管理��5	   	   $	��420��6   $	��550��6$   $��Microsoft YaHei)�60   $��Normal"�6M    � WindowStartupLocation$ CenterScreen=�5
   	   
������� � 
ResizeMode$ NoResize=�5       � DataContext 6"   ��    Locator �� Source# [   �� Path$ SensorManager�   NonClientAreaBackground 5      �� 5   
    �� EndPoint$ 1.002,0.498&�5      	 �� 
StartPoint$	 -0.024,0.502&�6$   .��5      � 
 � Color$
 #f5f6ff��6    � Offset$	 0.1Q�6+   � 5      $
 #aabcff��6   $	 0.6Q�6+   � 5      $
 #a3b6ff��6   $
 0.99Q�6+   5      .��5      �  � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid��5      $��0��6%   
�������   AutoGenerateColumns .     CanUserAddRows .     RowHeaderWidth$ 0Q�5      $��Center=�5         HorizontalGridLinesBrush �#c2c3c9$��Center=�5!         VerticalGridLinesBrush
 �����$��5q�5#      ��5$      �� *
SensorList+   Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ 序号��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *ID+6H     5'      $ 传感器名��6%   $ * 6L    63   �� *Name+6L     5(      $ 安装位置��6%   $ * 6P    63   �� *
Location+6P     5)      $ 类型��6%   $ * 6K    62   �� *Type+6K     5*      $ 单位��6%   $ * 6K    62   �� *Unit+6K     5+      $ 	源索引��6%   $
 Auto 6V    62   �� *DataSourceIndex+6V   4  .System.Windows.Controls.DataGridCheckBoxColumn  5,      $ 启用��6)   $
 Auto 6R    65   �� *
IsEnable+6R   5.      �� 50   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��5q�6;   .+�51      �� $��90��6   $��30��6    $��5q�6,   $��新建��67   $��CreateSensorView��53      ��52      �� *NewSensorCommand+53      �� 55      $��90��6   $��30��6    $��5q�6,   $��编辑��67   ��56      �� *EditSensorCommand+��57      ��  �� ElementName$ dataGrid��$ SelectedIndex��� 59      $��90��6   $��30��6    $��5q�6,   $��删除��67   ��5:      �� *DeleteOneSensorCommand+��5;      �� $ dataGrid��$ SelectedIndex�5=      5>      5@      