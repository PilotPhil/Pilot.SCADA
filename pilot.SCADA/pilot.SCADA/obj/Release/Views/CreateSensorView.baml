   M S B A M L   `   `   `  ���� F  Bpilot.SCADA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:pilot.SCADA.Viewspilot.SCADA.Views  (    "pilot.SCADA.Views.CreateSensorView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:pilot.SCADA.Views     S OHandyControl, Version=3.2.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  -   "  HandyControl.Controls.Window   Name$  
thisWindow�� � Title$ 新建传感器��$	��400��$	��650��$��Microsoft YaHei)�$��Normal"� � WindowStartupLocation$ CenterScreen=�
������� � DataContext ��    Locator �� Source# [   �� Path$ CreateSensor�   NonClientAreaBackground ��  �� EndPoint$ 1.002,0.498&� �� 
StartPoint$ -0.024,0.502&�.��� 	 � Color$	 #f5f6ff��
 � Offset$	
 0.1Q�� $	 #aabcff��$	
 0.6Q�� $	 #a3b6ff��$

 0.99Q�.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��1* � � ColumnDefinitions �� $	��200 ��� $��1* ��� $
��Auto ��� $��1* �.+��� $��基础信息��$��0��$��0��$��5q�
�������.���  �� �� $��9* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��1* �.+���  �� Orientation$ 
Horizontal=�$��0��$��2��.+��� $��序号��$��50��$��Center=�$��Center=��� $	��120��$��20��$��5q����� *SensorModel.ID+�� $ 
Horizontal=�$��1��$��2��.+��� $��传感器名��$��50��$��Center=�$��Center=��� $	��120��$��20��$��5q����� *SensorModel.Name+�� $ 
Horizontal=�$��2��$��2��.+��� $��位置��$��50��$��Center=�$��Center=��� $	��120��$��20��$��5q����� *SensorModel.Location+�� $ 
Horizontal=�$��3��$��2��.+��� $��类型��$��50��$��Center=�$��Center=��� -    ��Name$ cbx_type��$	��120��$��20��$��5q����� *SensorModel.TypeList+ �� SelectedItem �� *SensorModel.Type+�� $ 
Horizontal=�$��4��$��2��.+��� $��单位��$��50��$��Center=�$��Center=��� -   $ cbx_unit��$	��120��$��20��$��5q����� *SensorModel.UnitList+ �� *SensorModel.Unit+�� $ 
Horizontal=�$��5��$��2��.+��� $��启用��$��50��$��Center=�$��Center=��� $��Center=�$	��120��$��20��$��5q� d� 	IsChecked �� *SensorModel.Use+�� $��1��$��0��$
��Left=�$	��120��$��30��$��5q����� *
ButtonText+���� *NewSensorCommand+����  �� ElementName$ 
thisWindow���� $��1��$��已指派的任务��
�������$��5q�.���� -    ��Name$ list_task_selected��
�������$��0q����� *SensorModel.TaskList+ �� UpdateSourceTrigger$ PropertyChanged=� �� View �� .P��� $��模块名称�� �� Width$
 Auto�� �� DisplayMemberBinding �� *
ModuleName+�� $��版本��$
 Auto�� �� *ModuleVersion+�� $ Vertical=�$��2��$��Center=�.+��� $��36��$��36��$��5q����� *RemoveOneTaskCommand+���� $ list_task_selected��$ SelectedIndex�.���� $	����$��22(�$��../Assets/ttf/#iconfont)�
����  �$��Center=�$��Center=��� $��36��$��36��$��5q����� *AddOneTaskCommand+���� $ list_task_loaded��$ SelectedIndex�.���� $	����$��22(�$��../Assets/ttf/#iconfont)�
����  �$��Center=�$��Center=��� $��3��$��已加载的任务��
�������$��5q�.���� -   $ list_task_loaded��
�������$��0q����� *LoadedTaskList+ �� .P��� $��模块名称�� �� *
ModuleName+�� $��版本��$
 Auto�� �� *ModuleVersion+ � ContextMenu �� $	��100��.@�m� $��详情��$	��100�� m� Command �� *DetailsAcountCmd+ m� CommandParameter �� $ listView��$ SelectedItem�m� $��编辑��$	��100�� �� *EditAcountCmd+ �� $ listView��$ SelectedItem�m� $��删除��$	��100�� �� *DeleteAcountCmd+ �� $ listView��$ SelectedItem�