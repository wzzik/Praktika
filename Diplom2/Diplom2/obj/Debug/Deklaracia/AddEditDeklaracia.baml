   M S B A M L   `   `   `  ����B  >Diplom2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Diplom2.DeklaraciaDiplom2.Deklaracia  5   	   *    $Diplom2.Deklaracia.AddEditDeklaracia   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Diplom2.Deklaracia     5   	     � Title$  Декларация��5   	   $	��550��6   $	��650��6)   .��5	      �� ���	#FF842E2E.+�5
   
   �� $��	0,100,0,0q�6    �� Orientation$ 
Horizontal=�6(   $��Center=�6A   .+�5      �� $��Реестр��6   $	��161��6&   $��20(�62   
�������6@   �� 5      -   5         ��Name$ 	CmbPeectr��5   W    �� DisplayMemberPath$ СоставНетто��67   $	��200��6j   
���   �$��20(�6�    �� SelectedItem 6   �� *Реестр+6�   5      �� 5   
   $��0,15,0,0q�6   $ 
Horizontal=�6'   $��Center=�6@   .+�5      �� $��Страна��6   $	��161��6&   $��20(�62   
�������6@   �� 5      -   5        $��	CmbStrana��5   Z   $" НазваниеСтраны��67   $	��200��6k   
���   �$��20(�6�    6   �� *Страна+6�   5      �� 5   
   $��0,15,0,0q�6   $ 
Horizontal=�6'   $��Center=�6@   .+�5      �� $$��Грузополучатель��6   $	��161��60   $��20(�6<   
�������6J   �� 5      -   5        $��CmbGruzopoluch��5   g   $&  Грузополучатеель��6B   $	��200��6}   
���   �$��20(�6�    6   �� * Грузополучатель+6�   5      �� 5   
   $��0,15,0,0q�6   $ 
Horizontal=�6'   $��Center=�6@   .+�5      �� $��ВПД��6   $	��161��6$   $��20(�60   
�������6>   �� 5      -   5        $��CmbVPD��5   R   $ МаркаУгля��64   $	��200��6`   
���   �$��20(�6�    6   �� *ВПД+6�   5      �� 5   
   $��0,15,0,0q�6   $ 
Horizontal=�6'   $��Center=�6@   .+�5      �� $��ВТД��6   $	��161��6$   $��20(�60   
�������6>   �� 5      -   5        $��CmbVTD��5   a   $&  Количество_по_ВТД��6;   $	��200��6o   
���   �$��20(�6�    6   �� *Анализ_ВТД+6�   5      �� 5   
   $��0,15,0,0q�6   $ 
Horizontal=�6'   $��Center=�6@   .+�5      �� $��Склады��6   $	��161��6'   $��20(�63   
�������6A   �� 5       -   5        $��CmbOtchetSklad��5    _   $ ИмяСклада��6A   $	��200��6u   
���   �$��20(�6�    6   �� * Отчет_по_складам+6�   5!      �� 5"   
   $��0,15,0,0q�6   $ 
Horizontal=�6'   $��Center=�6@   .+�5#      �� $��Контакт №��6   $	��161��6*   $��20(�66   
�������6D   �� 5$      -   5        $��TxbKontactn��5$   5   $	��200��6H   
���   �$��20(�6h   ��6   �� *Контакт_номер+6h   5%      �� 5&   
   $��0,15,0,0q�6   $ 
Horizontal=�6'   $��Center=�6@   .+�5'      �� $��Контакт дата��6   $	��161��6-   $��20(�69   
�������6G   �� 5(      -   5        $��TxbKontaktd��5(   4   $	��200��6G   
���   �$��20(�6g   ��6   �� *Контакт_дата+6g   5)      �� 5*   
   .+�5+      �� -	   5         ��Name$ 	BtnCreate��5+      $��Подтвердить��6(   $��40��6>   $	��172��6J   $��10,15,10,10q�6V   $��16(�6k   ���	#FF5F5C5C
����������	#FF842E2E6�   5,      5-      5.      