   M S B A M L   `   `   `  ���� F  Bpilot.SCADA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:pilot.SCADA.Viewspilot.SCADA.Views  )    #pilot.SCADA.Views.RecentProjectView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     1localclr-namespace:pilot.SCADA.Views     S OHandyControl, Version=3.2.0.0, Culture=neutral, PublicKeyToken=45be8712787a1e5b0hc'https://handyorg.github.io/handycontrol    � 	Resources   �� 
TargetType   hyperLinkStyle �� Property �� Value �� Triggers P� Property P� Value }� Location��%�   &	        �� " ��.���  � �� �#209AC2��  � �� Z�  P�  �@��IsMouseOver . . ���  � �� �#F27D00��  � �� |� }� $ 	Underline=�.���  � ColumnDefinitions �� $��1* ��� $
��Auto ��� $��1* �	 � RowDefinitions	 �� $��1* ��� $��4* ��� $��1* �.+��� $��1��$��1��.+��  �� �� .+��� $��0��.+��� .+��� $!��Data Acquisition Processing��$��26(�$��Normal"����#616161�� $��采集进化��$��20(�$��Normal"����#717186�� 
 �� Orientation$
 Vertical=�$��1��$��1��$	��0,5q�.+��� $��启动��$��20(�$��Normal"����#81869f$��0,0,0,5q��� $��15(�$��Normal"����#3b71b3$	��5,0q��� #��[   �� Command �� *NewProjectCommand+.�新建工程�� $��15(�$��Normal"����#3b71b3$	��5,0q��� #��[   �� *OpenProjectCommand+.�打开工程�� $
 Vertical=�$��1��$��1��$	��0,5q�.+��� $��最近��$��20(�$��Normal"����#81869f$��0,0,0,5q��� .���� -    ��Name$ 
stackPanel��$  HandyControl.Controls.Carousel     IsCenter .    AutoRun . $��1��$��2��$	��400��$	��280��.  (HandyControl.Controls.SimpleItemsControl   Items. �� $
 
Horizontal=�$��1��$��2��.+��� $ ��../Assets/img/letter-d.png��$	��130��$��Center=��� $ ��../Assets/img/letter-a.png��$	��130��$��Center=��� $ ��../Assets/img/letter-p.png��$	��130��$��Center=��� $��../Assets/img/handou.png��$	��400���� $��../Assets/img/JUST.png��$	��400��