   M S B A M L   `   `   `  ����M  IFantasyManager.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:FantasyManager.WPF.ControlsFantasyManager.WPF.Controls  5      C&clr-namespace:FantasyManager.WPF.EnumsFantasyManager.WPF.Enums  5      M+clr-namespace:FantasyManager.WPF.ViewModelsFantasyManager.WPF.ViewModels  5	      T PFantasyManager.WPF.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null~Uclr-namespace:FantasyManager.WPF.Common.Converters;assembly=FantasyManager.WPF.Common$FantasyManager.WPF.Common.Converters 5
      /    )FantasyManager.WPF.Controls.NavigationBar   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:FantasyManager.WPF.Controls     5      6nav&clr-namespace:FantasyManager.WPF.Enums     5      :vm+clr-namespace:FantasyManager.WPF.ViewModels     5	      l
convertersUclr-namespace:FantasyManager.WPF.Common.Converters;assembly=FantasyManager.WPF.Common     5
        � 	Resources  5      I  CFantasyManager.WPF.Common.Converters.EqualValueToParameterConverter "  EqualValueToParameterConverter��%   &	          5   
   64   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6    �� EdgeMode$ Aliased=�6!    �� Padding$
 10 7q�5      $��25(�6#     BrushTextPrimary1#��[ 61   $��Fantasy Manager��6a     	NavHeader#��[ 5      � 5   
   $��1��6     BrushPrimary2#��[ 5        5       �� 
TargetType  NavRadioButton �� BasedOn��%0   '	�       7  �� 5      " 	�6   8   61   5        � ColumnDefinitions 5!      �� 5"      $
��auto �6#   �� 5#      $
��auto �6#   �� 5$      $
��auto �6#   �� 5%      $
��auto �6#   �� 5&      $��* �6#   .+�5)      	� '   !FantasyManager.WPF.Enums.ViewType   Home#��Z 6L   $��0��5+      $
��Home��6*   ��5)      �� *UpdateCurrentViewModelCommand+ d� 	IsChecked 5*      �� *Navigator.CurrentViewModel+	 �� Mode$	 OneWay=�
 �� 	Converter#
 [   �� ConverterParameter1   +FantasyManager.WPF.ViewModels.HomeViewModel"  5+   *   	� 5-         
CreateTeam#��Z 6L   $��1��5/      $��Create Team��6*   ��5-      �� *UpdateCurrentViewModelCommand+ 5.      �� *Navigator.CurrentViewModel+$	 OneWay=�#
 [  7   1FantasyManager.WPF.ViewModels.CreateTeamViewModel"  5/   *   	� 51         	DraftTeam#��Z 6L   $��2��53      $��
Draft Team��6*   ��51      �� *UpdateCurrentViewModelCommand+ 52      �� *Navigator.CurrentViewModel+$	 OneWay=�#
 [  6   0FantasyManager.WPF.ViewModels.DraftTeamViewModel"  53   *   	� 55         
PlaySeason#��Z 6L   $��3��57      $��Play Season��6*   ��55      �� *UpdateCurrentViewModelCommand+ 56      �� *Navigator.CurrentViewModel+$	 OneWay=�#
 [  7   1FantasyManager.WPF.ViewModels.PlaySeasonViewModel"  57   *   	� 59      $�� ��6.   $��4��5:      $��Logout��6*   $��Right=�6;   ��59      �� 5:   ;   5;      5<      5=      