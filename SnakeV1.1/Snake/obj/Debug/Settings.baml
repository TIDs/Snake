   M S B A M L   `   `   `  ����	  Snake    ProgramSnake.Settings   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Settings��5   	   $	��271��6   $	��251��6'   .��5      � $��0,0,2,2q�6   #��� ��6    � ColumnDefinitions 5   
   �� 5      $	��21* �6   �� 5      $
��185* �6   �� 5	      $��0* �6   .+�5   
   �� $��Settings��6   $
��Left=�6#   $	��Top=�6>   $��	10,10,0,0q�6V   $��Showcard Gothic)�6i   $��36(�6�   $	��200��6�   $��55��6�   $��1��6�   �� 5   
   $��Speed of Snake��6   $
��Left=�6)   $��	27,97,0,0q�6D   $	��Top=�6W    J� RenderTransformOrigin$ -1.289,-1.308&�6o   $��32��6�   $	��147��6�   $��1��6�   $��Showcard Gothic)�6�   $��18(�6�    � Cursor$
 Hand��6�   z�5      V� 5      .~�5      �� �� 5       �� AngleX$
 6.71Q�6$   �� 5      T� 5       T� X$ -4.924Q�6)   5      5      �� 5   
   -   5         ��Name$ 
SnakeSpeed��5      $
��Left=�6%   $��
27,134,0,0q�6@   $	��Top=�6T   $	��153��6l   $��25��6x   $��1��6�   $ 0.529,1.529&�6�    J� OpacityMask �	#FFF0F0F0���	#FFB29C9C���	#FFBB1111#��� ��6�    � Minimum$ 1Q�6K  	 � Value$	 5Q�6W  
 � SmallChange$
 1Q�6a  6q  �� 5   
   -   5         ��Name$ ApplySettingButton��5      $��Apply��6-   $
��Left=�6=   $��120,179,0,0q�6X   $	��Top=�6m   $��75��6�   $��20��6�   $��1��6�   6�   �� 5   
   -   5        $ CancelButton��5      $��Cancel��6'   $
��Left=�68   $��
10,179,0,0q�6S   $	��Top=�6g   $��75��6   $��20��6�   ���	#FFC1C1C1 �� IsCancel . $��1��6�   6�   5      5      