   M S B A M L   `   `   `  ���� F  Bpilot.SCADA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:pilot.SCADA.Viewspilot.SCADA.Views  &     pilot.SCADA.Views.NewProjectView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:pilot.SCADA.Views     S OHandyControl, Version=3.2.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  -   "  HandyControl.Controls.Window   Name$  
thisWindow�� � Title$ 新建工程��$	��200��$	��480��$��Microsoft YaHei)�$��
ExtraLight"� � WindowStartupLocation$ CenterScreen=�
������� � 
ResizeMode$ NoResize=� � DataContext ��    Locator �� Source# [   �� Path$ 
NewProject�   NonClientAreaBackground ��  �� EndPoint$ 1.002,0.498&�	 �� 
StartPoint$	 -0.024,0.502&�.��� 
 � Color$
 #f5f6ff�� � Offset$	 0.1Q�� $
 #aabcff��$	 0.6Q�� $
 #a3b6ff��$
 0.99Q�.��� $��10q� � RowDefinitions �� �� �� .+�� $��0�� � ColumnDefinitions �� $
��Auto ��� $��1* �.+��� $��工程名称：��$��Center=�$��70��$��0���� $��30��$��1������ *
NewPrjName+� $��1�� �� $
��Auto ��� $��1* ��� $
��Auto �.+��� $��创建路径：��$��Center=�$��70��$��0���� $��30��$��1������ *
NewPrjPath+�� $��浏览��$��80��$��30��$��2��$��10,0,0,0q����� *ChoosePathCommand+����  �� ElementName$ 
thisWindow��� $��2�� �� .+��� $��设为项目默认路径��$	��150��$��30��$��	0,0,205,0q�$��0��$
��Left=� d� 	IsChecked �� *IsSetDefaultPrjPath+��  �� Orientation$ 
Horizontal=�$��Right=�$��1��.+��� $��确认��$��80��$��30��$��0,0,10,0q����� *ConfirmCommand+���� $ 
thisWindow���� $��取消��$��80��$��30������ *CancelCommand+���� $ 
thisWindow��