   M S B A M L   `   `   `  ���� G  CGranitInvest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:GranitInvest.CustomControlsGranitInvest.CustomControls  (    "GranitInvest.View.RegistrationView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     DcustomControls)clr-namespace:GranitInvest.CustomControls     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$  RegistrationView��$	��900��$	��850�� � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � WindowStyle$
 None=�.����  �� CornerRadius$ 35������  j� 
AlignmentX$
 Left=� �� ImageSource$, &/Resources/Images/background_image.jpg�� j� Stretch$ UniformToFill=�._��� $��4q�$ 25��	 J� Opacity$
	 0.95Q����� 
 �� 
StartPoint$

 0, 0&� �� EndPoint$
 1, 1&�.���  � Offset$ 0Q� � Color$ #f2c506��� $	 0.7Q�$ #f8ca0a��� $ 1Q�$ #fbe68c������ $

 0, 1&�$
 1, 0&�.��� $ 0Q�$ #152245��� $
 0.15Q�$ #152238��� $	 0.7Q�$ #192841��� $ 1Q�$ #1c2e4a��._��  � RowDefinitions �� $��35 ��� .+��  � ColumnDefinitions �� �� $��25 ��� $��25 ��� $��5 �.+��� $��0��$��20,0,0,0q�$��Center=�$��
Montserrat)�$��14(����#f8ca0a$��REGISTRACIJA���� -    ��Name$ BtnMinimize��$��1��$��0q� � Cursor$
 Hand��$��
Montserrat)�$��12(�
���   �����  �� 
TargetType" ��.���  �� Property � �� �� Value �#f8ca0a �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 � �������  �� 
TargetType" ��.R��� $��18��$��18��#��z��$ 9��._��� $��Center=�$��Center=��� -   $ BtnClose��$��2��$��0q�$
 Hand��$��
Montserrat)�$��12(�
���   ����� " ��.���  � ��
 � E�� P�  �@J�IsMouseOver . . ���  � ��
 �  ������ " ��.R��� $��18��$��18��#��z��$ 9��._��� $��Center=�$��Center=��� $��1��$	��250��$��0,50,0,0q� �� Orientation$ Vertical=�.+��� $	��150��$��80��$ ��/Resources/Images/logo.png���� $��0,10,0,0q�$��
Montserrat)�$��12(�$��Medium"����#f8ca0a$5��/Skupovi za mlade na temu pravoslavne duhovnosti�� �� TextAlignment$ Center=�$
��Wrap=��� $��0,30,0,0q�$��
Montserrat)�$��12(�$��Medium"����#f8ca0a$��Korisničko ime��$
��Wrap=��� -    ��Name$ TxtUser��$��28��$��0,5,0,0q�$��30,0,0,0q�$��Center=�$��0,0,0,1q� �� 
CaretBrush �#f8ca0a$��
Montserrat)�$��13(�$��Medium"����#f8ca0a���� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�.������ $
 Left=�$  /Resources/Images/user.png��$
 None=�.���� $��0,30,0,0q�$��
Montserrat)�$��12(�$��Medium"����#f8ca0a$��Lozinka��5   /GranitInvest.CustomControls.BindablePasswordBox  -     Name$ TxtPassword��$��28��$��0,5,0,0q�   Password �� *
Password+  �� Mode$  TwoWay=�$ PropertyChanged=��� $��0,30,0,0q�$��
Montserrat)�$��12(�$��Medium"����#f8ca0a$��Potvrdite Lozinku��  -   $ TxtPasswordConfirm��$��28��$��0,5,0,0q� �� *
Password+$  TwoWay=�$ PropertyChanged=��� $��0,30,0,0q�$��
Montserrat)�$��12(�$��Medium"����#f8ca0a$��E-mail��$
��Wrap=��� -   $ TxtEmail��$��28��$��0,5,0,0q�$��30,0,0,0q�$��Center=�
������ $��0,0,0,1q� �#f8ca0a$��
Montserrat)�$��13(�$��Medium"����#f8ca0a���� *Email+$ PropertyChanged=��� $��0,30,0,0q�$��
Montserrat)�$��12(�$��Medium"����#f8ca0a$	��Ime��$
��Wrap=��� -   $ TxtIme��$��28��$��0,5,0,0q�$��30,0,0,0q�$��Center=�
������ $��0,0,0,1q� �#f8ca0a$��
Montserrat)�$��13(�$��Medium"����#f8ca0a���� *Name+$ PropertyChanged=��� $��0,30,0,0q�$��
Montserrat)�$��12(�$��Medium"����#f8ca0a$��Prezime��$
��Wrap=��� -	   $ 
TxtPrezime��$��28��$��0,5,0,0q�$��30,0,0,0q�$��Center=�
������ $��0,0,0,1q� �#f8ca0a$��
Montserrat)�$��13(�$��Medium"����#f8ca0a���� *	Surname+$ PropertyChanged=��� -
   $��TxtErrorMessage��$��0,30,0,0q�$��
Montserrat)�$��12(�$��Medium"�
���  ��$
��Wrap=����� *ErrorMessage+�� -   $ BtnLogin��$��0,15,0,0q�$��0q�$��PRIJAVITE SE��$
 Hand��$��
Montserrat)�$��12(�$��Medium"����#152238���� " ��.���  � ��
 ���p� P�  �@J�IsMouseOver . . ���  � �� �#f8ca0a���� " ��.R��� $	��150��$��25��#��z��$ 12��._��� $��Center=�$��Center=��� $��0,35,0,0q�$��Center=�$��
Montserrat)�$��Medium"��� -   $��12(�.����� ! �� BasedOn#! [B��" ��.���  � ��
 ����� P�  �@��IsMouseOver . . ���  � �� �#f8ca0a.�,*Odustali ste od kreacije? Pritisnite ovde.