   M S B A M L   `   `   `  ����F  Bpilot.SCADA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:pilot.SCADA.Viewspilot.SCADA.Views  5   	   &     pilot.SCADA.Views.NewProjectView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:pilot.SCADA.Views     5   	   S OHandyControl, Version=3.2.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol  5   	   -   5        "  HandyControl.Controls.Window   Name$  
thisWindow��5
   .    � Title$ 新建工程��5	   	   $	��200��6   $	��480��6#   $��Microsoft YaHei)�6/   $��
ExtraLight"�6L    � WindowStartupLocation$ CenterScreen=�5
   	   
������� � 
ResizeMode$ NoResize=�5   	    � DataContext 5   	   ��    Locator �� Source# [   �� Path$ 
NewProject�   NonClientAreaBackground 5      �� 5   
    �� EndPoint$ 1.002,0.498&�5      	 �� 
StartPoint$	 -0.024,0.502&�6$   .��5      � 
 � Color$
 #f5f6ff��6    � Offset$	 0.1Q�6+   � 5      $
 #aabcff��6   $	 0.6Q�6+   � 5      $
 #a3b6ff��6   $
 0.99Q�6+   5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5       $
��Auto �6#   �� 5!      $��1* �6#   .+�5$      �� $��工程名称：��6   $��Center=�6%   $��70��6@   $��0��6K   �� 5%      $��30��63   $��1��6?   ��6   �� *
NewPrjName+6?   5&      � 5(   
   $��1��6    5)      �� 5*      $
��Auto �6#   �� 5+      $��1* �6#   �� 5,      $
��Auto �6#   .+�5/      �� $��创建路径：��6   $��Center=�6%   $��70��6@   $��0��6K   �� 50      $��30��62   $��1��6>   ��6   �� *
NewPrjPath+6>   �� 51      $��浏览��6   $��80��6"   $��30��6-   $��2��69   $��10,0,0,0q�6I   ��52      �� *ChoosePathCommand+��6;   ��  �� ElementName$ 
thisWindow��53      � 55   
   $��2��6    56      �� 57      .+�5:      �� $��设为项目默认路径��6   $	��150��6*   $��30��66   $��	0,0,205,0q�6B   $��0��6U   $
��Left=�6e    d� 	IsChecked 5;      �� *IsSetDefaultPrjPath+�� 5=       �� Orientation$ 
Horizontal=�6   $��Right=�62   $��1��6N   .+�5>      �� $��确认��6   $��80��6&   $��30��61   $��0,0,10,0q�6=   ��5?      �� *ConfirmCommand+��6<   �� $ 
thisWindow���� 5@      $��取消��6   $��80��6&   $��30��61   ��5A      �� *CancelCommand+��6;   �� $ 
thisWindow��5B      5D      5F      5G      