   M S B A M L   `   `   `  ����T  PFantasyManager.WPF.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null�]clr-namespace:FantasyManager.WPF.Common.Behaviors.DragDrop;assembly=FantasyManager.WPF.Common,FantasyManager.WPF.Common.Behaviors.DragDrop  5      M IFantasyManager.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:FantasyManager.WPF.ControlsFantasyManager.WPF.Controls 5      ~Uclr-namespace:FantasyManager.WPF.Common.Converters;assembly=FantasyManager.WPF.Common$FantasyManager.WPF.Common.Converters  5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089_ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a "  ListViewItemContainerTextBlock  �� 
TargetType �� Property �� Value  BrushTextPrimary1  FontSizeSmall  LeagueContainer �� 
TargetType ��Name �� CornerRadius  BrushPrimary1  BrushSecondary2 � ColumnDefinitions  ImageMedium �� Triggers P� Property	 P� Value
 �� 
TargetName  BrushPrimary2  LogoContainer 	 
ImageSmall 
 BrushPrimary3  PlayerContainer � RowDefinitions�� 5      H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml     5      3i+http://schemas.microsoft.com/xaml/behaviors  5      k	behaviors]clr-namespace:FantasyManager.WPF.Common.Behaviors.DragDrop;assembly=FantasyManager.WPF.Common  5      6controls)clr-namespace:FantasyManager.WPF.Controls  5      d
convertersUclr-namespace:FantasyManager.WPF.Common.Converters;assembly=FantasyManager.WPF.Common  5      %w
  &	        7  7  &	 �    7  7  7  7   7  7  &	 �    7  7  7 	 7 
 7 
 &	 �    7  7 
 7 	 �� 5	      "  ��63   .�5
   
   ��  � ��$ Center=�6.   �� 5   
    � ��$
 auto��6"   �� 5   
    �@��Padding$ 10 0 3 0q�6$   �� 5   
    � ��8   6'   �� 5   
    � ��8  6%   �� 5   
    � ��$
 Bold"�6'   �� 5   
    �@��TextAlignment$
 Left=�6*   �� 5   
    � ��$ Bahnhof Condensed)�6'   �� 5   
    � ��$
 Wrap=�6)   5      �� 5      "  ��6$   .�5   
   ��  �@J�SnapsToDevicePixels$
 True��60   �� 5   
    � ��$
 auto��6"   �� 5   
    � ��$ 50��6#   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      �� $ LeagueBorder��6   $��1q�5      $ 10��6(   $��1 0 0 1q�6:   8��  8�� ._�5       �  5!      �� 5"   "   $��* �63   �� 5#   "   $��3* �63   .+�5&      �� $��0��6$   8�� ��5'   $   �� *Logo+5(   $   �� 5*      8�� $��1��5+   (   ��5*   (   �� *Name+5+   (   5,      5-       5.      P� 5/       �@J�IsMouseOver$
	 True��69   . �50      �� $
 LeagueBorder��6%   8   � ��6U   51      P� 52       �@��
IsSelected$
	 True��68   . �53      �� $
 LeagueBorder��6%   8   � ��6U   54      56      58      59      �� 5;      "  ��6"   .�5<   
   ��  �@J�SnapsToDevicePixels$
 True��60   �� 5=   
    � ��$
 auto��6"   �� 5>   
    � ��$ 70��6#   �� 5?   
    � �� 5@      �� 5A      " ��6"   .R�5B      �� $ LeagueBorder��6   $��1q�5C      $ 10��6(   $��1 0 0 1q�6:   8��  8�� ._�5F      �� $��0��6    8�� ��5G       �� *Logo+5H       5I       5J      P� 5K       �@J�IsMouseOver$
	 True��69   . �5L      �� $
 LeagueBorder��6%   8   � ��6U   5M      P� 5N       �@��
IsSelected$
	 True��68   . �5O      �� $
 LeagueBorder��6%   8   � ��6U   5P      5R      5T      5U      �� 5W      "  ��6$   .�5X   
   ��  � �� 5Y      �� 5Z      " ��6"   .R�5[      �� $ PlayerBorder��6   $��1q�5\      $ 10��6(   $��1 0 0 1q�6:   8��  8�� ._�5_      �  5`      �� 5a   "   $��* �63   �� 5b   "   $��5* �63   .+�5e      �� $��0��6$   8�� ��5f   $   �� *Image+5g   $   � 5i      $��1��6#    5j   "   �� 5k   &   $��* �64   �� 5l   &   $��* �64   .+�5o   "   �� $��0��5p   ,   ��5o   ,   �� *Header.MainInfo+5p   ,   �� 5r   "   $��1��5s   ,   ��5r   ,   �� *SubHeader.MainInfo+5s   ,   5t      5u      5v      5w      5y      5z      5{      