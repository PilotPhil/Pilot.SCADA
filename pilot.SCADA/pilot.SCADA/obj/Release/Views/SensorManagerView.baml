   M S B A M L   `   `   `  ���� F  Bpilot.SCADA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:pilot.SCADA.Viewspilot.SCADA.Views  )    #pilot.SCADA.Views.SensorManagerView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:pilot.SCADA.Views     S OHandyControl, Version=3.2.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  -   "  HandyControl.Controls.Window   Name$  
thisWindow�� � Title$ 传感器管理��$	��420��$	��550��$��Microsoft YaHei)�$��Normal"� � WindowStartupLocation$ CenterScreen=�
������� � 
ResizeMode$ NoResize=� � DataContext ��    Locator �� Source# [   �� Path$ SensorManager�   NonClientAreaBackground ��  �� EndPoint$ 1.002,0.498&�	 �� 
StartPoint$	 -0.024,0.502&�.��� 
 � Color$
 #f5f6ff�� � Offset$	 0.1Q�� $
 #aabcff��$	 0.6Q�� $
 #a3b6ff��$
 0.99Q�.���  � RowDefinitions �� $��1* ��� $
��Auto �.+�&   System.Windows.Controls.DataGrid  -     Name$ dataGrid��$��0��
�������   AutoGenerateColumns .     CanUserAddRows .     RowHeaderWidth$ 0Q�$��Center=�   HorizontalGridLinesBrush �#c2c3c9$��Center=�   VerticalGridLinesBrush
 �����$��5q����� *
SensorList+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 序号��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *ID+  $ 传感器名��$ *  �� *Name+  $ 安装位置��$ *  �� *
Location+  $ 类型��$ *  �� *Type+  $ 单位��$ *  �� *Unit+  $ 	源索引��$
 Auto  �� *DataSourceIndex+4  .System.Windows.Controls.DataGridCheckBoxColumn  $ 启用��$
 Auto  �� *Use+��  �� Orientation$ 
Horizontal=�$��1��$��5q�.+��� $��保存��$��90��$��30��$��5q����� *SaveCommand+�� $��90��$��30��$��5q�$��新建��$��CreateSensorView������ *NewSensorCommand+�� $��90��$��30��$��5q�$��编辑������ *EditSensorCommand+����  �� ElementName$ dataGrid��$ SelectedIndex��� $��90��$��30��$��5q�$��删除������ *DeleteOneSensorCommand+���� $ dataGrid��$ SelectedIndex�