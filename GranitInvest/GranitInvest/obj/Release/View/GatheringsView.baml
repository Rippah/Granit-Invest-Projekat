   M S B A M L   `   `   `  ���� G  CGranitInvest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:GranitInvest.ViewModelGranitInvest.ViewModel  &     GranitInvest.View.GatheringsView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     :	viewModel$clr-namespace:GranitInvest.ViewModel     -     � Title$  RegistrationView��$
��1280��$	��720�� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=� � DataContext 0   *GranitInvest.ViewModel.GatheringsViewModel  .����  �� CornerRadius$ 35������  j� 
AlignmentX$
 Left=� �� ImageSource$, &/Resources/Images/background_image.jpg��	 j� Stretch$	 UniformToFill=�._��� $��4q�$ 25��
 J� Opacity$

 0.95Q�����  �� 
StartPoint$
 0, 0&� �� EndPoint$
 1, 1&�.���  � Offset$ 0Q� � Color$ #f2c506��� $	 0.7Q�$ #f8ca0a��� $ 1Q�$ #fbe68c������ $
 0, 1&�$
 1, 0&�.��� $ 0Q�$ #152245��� $
 0.15Q�$ #152238��� $	 0.7Q�$ #192841��� $ 1Q�$ #1c2e4a��._��  � RowDefinitions �� $��35 ��� $��* ��� $��4* ��� $��* �.+��  � ColumnDefinitions �� �� $��25 ��� $��25 ��� $��5 �.+��� $��0��$��20,0,0,0q�$��Center=�$��
Montserrat)�$��16(����#f8ca0a$��SKUPOVI���� -    ��Name$ BtnMinimize��$��1��$��0q� � Cursor$
 Hand��$��
Montserrat)�$��12(�
���   �����  �� 
TargetType" ��.���  �� Property � �� �� Value �#f2c506 �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 � �������  �� 
TargetType" ��.R��� $��18��$��18��#��z��$ 9��._��� $��Center=�$��Center=��� -   $ BtnClose��$��2��$��0q�$
 Hand��$��
Montserrat)�$��12(�
���   ����� " ��.���  � ��
 � E�� P�  �@J�IsMouseOver . . ���  � ��
 �  ������ " ��.R��� $��18��$��18��#��z��$ 9��._��� $��Center=�$��Center=�� $��2�� �� $��* ��� $��3* �.+��� $��30q�.+��� -   $ 
BtnContact��$��0,15,0,0q�$��0q�$��KONTAKT��$
 Hand��$��
Montserrat)�$��19(�$��Medium"�
���iii����� " ��.���  � �� �#f8ca0a P�  �@J�IsMouseOver . . ���  � �� �#f2b500���� " ��.R��� $	��250��$��45��#��z��$ 12��._��� $��Center=�$��Center=��� -   $ 	BtnLogout��$��0,15,0,0q�$��0q�$��ODJAVITE SE��$
 Hand��$��
Montserrat)�$��19(�$��Medium"�
���iii����� " ��.���  � �� �#f8ca0a P�  �@J�IsMouseOver . . ���  � �� �#f2b500���� " ��.R��� $	��250��$��45��#��z��$ 12��._��� $��Center=�$��Center=��� -   $ BtnAddGatherings��$��0,15,0,0q�$��0q�$��DODAJTE NOVI SKUP��$
 Hand��$��
Montserrat)�$��19(�$��Medium"�
���iii����� " ��.���  � �� �#f8ca0a P�  �@J�IsMouseOver . . ���  � �� �#f2b500���� " ��.R��� $	��250��$��45��#��z��$ 12��._��� $��Center=�$��Center=��� -   $ 
BtnAddUser��$��0,15,0,0q�$��0q�$��DODAJTE NOVOG ADMINA��$
 Hand��$��
Montserrat)�$��19(�$��Medium"�
���iii����� " ��.���  � �� �#f8ca0a P�  �@J�IsMouseOver . . ���  � �� �#f2b500���� " ��.R��� $	��250��$��45��#��z��$ 12��._��� $��Center=�$��Center=�&   System.Windows.Controls.DataGrid  -   $��MainDataGrid��$��1��$��15q�   AutoGenerateColumns .  ���#152238   CanUserAddRows .  $��16(�$
��Bold"����#f8ca0a   HeadersVisibility$ Column=�   HorizontalGridLinesBrush
 � ���   RowBackground
 ����    VerticalGridLinesBrush
 � ������� *	Skupovi+    	CellStyle  �� *  $System.Windows.Controls.DataGridCell"  .���  � �� �#152238 P�  �@ 
IsSelected . . ���  � �� �#f8ca0a��  � �� �#152238!   RowStyle! �� )  #System.Windows.Controls.DataGridRow"  .���  � ��$ 40��" � 	Resources" =  7System.Windows.Controls.Primitives.DataGridColumnHeader# �� BasedOn��%X   '        7 �� 8#   "  .���  � �� �#f8ca0a��  � �� �#152238$   Columns$ 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn%   Width5  /System.Windows.Controls.DataGridLengthConverter$
% Auto &   Header$& Naziv��'   
IsReadOnly' . 1	  +System.Windows.Controls.DataGridBoundColumn( 	  Binding( �� ) �� Path$
) Name�* 	  ElementStyle* �� " ��.���  � ��$
 Wrap=���  � ��$ Center=�  $% * $
& Opis��' . ( �� $) Description�* �� " ��.���  � ��$
 Wrap=�  $
% Auto $& Datum��' . ( �� $
) Date�* �� " ��.���  � ��$
 Wrap=���  � ��$ Center=�  $
% Auto $& Lokacija��' . ( �� $) Location�* �� " ��.���  � ��$
 Wrap=���  � ��$ Center=�5
  /System.Windows.Controls.DataGridHyperlinkColumn
  $
% Auto $& 	Instagram��' . ( �� $) Profile�* �� " ��.�-	   ��  � ��$
 Wrap=���  � ��$ Center=�
  $
% Auto $& Učestvujte i vi��' . ( �� $
) Link�* �� " ��.�-
   ��  � ��$
 Wrap=���  � ��$ Center=�� $��3��.+��� $��0��$��20,0,0,0q�$��Center=�$��
Montserrat)�$��30(����#f8ca0a���� *LoadCurrentUsername+�� $	��250��$��0,20,-1100,0q�+ �� Orientation$+ Vertical=�.+��� $��75��$��75��$ ��/Resources/Images/icon.png��