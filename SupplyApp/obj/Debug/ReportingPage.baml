   M S B A M L   `   `   `  ????D  @SupplyApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SupplyApp	SupplyApp  5          SupplyApp.ReportingPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:SupplyApp     5        N? Title$  ReportingPage??5	       N? 
Background
 ?????.??5      ?  ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??50 ?6    ? ColumnDefinitions 5   
   ?? 5      $	??300 ?6   ?? 5      $??* ?6   .+?5   
   ?? $2??,Введите даты для отчета:??6   $??0??64   $??0??6A   $??20(?6Q   $??	Underline{?6_   $??Center=?6{   $??Center=?6?    J? Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ 	#FFF9ECEC??6#   5      ?? 5   
   $,??&Выберите поставщика:??6   $??1??60   $??0??6=   $??20(?6M   $??	Underline{?6[   $??Center=?6w   $??Center=?6?    5        5      $ 	#FFF9ECEC??6#   5      ?? 5    
   $"??Выберите товар:??6   $??2??6+   $??0??68   $??20(?6H   $??	Underline{?6V   $??Center=?6r   $??Center=?6?    5!        5"      $ 	#FFF9ECEC??6#   5$      (  "System.Windows.Controls.DatePicker  5&   
   -   5          Name$ date1??5&   [   $??20(?6   $??0??6#   $??1??60   $
??Left=?6@   $	??240??6j   $??Center=?6v     5'   
   -   5        $ date2??5'   @   $??20(?6   $??0??6#   $??1??60   $??Center=?6O   $??Right=?6j   $	??240??6?   ?? 5(   
   -   5         ??Name$ ComboSupplier??5(   C   $??20(?6    ?? DisplayMemberPath$
 Name??6Z   $??1??6s   $??1??6?   $??Center=?6?   	 ?? 
IsEditable	 . 
 ?? 
IsReadOnly
 .   ?? StaysOpenOnEdit . ???	#FF0E40EC ?? SelectedItem 6!   ?? *
Supplier+6  ?? 5)   
   -   5        $ ComboProduct??5)   B   $??20(?6   $
 Name??6X   $??2??6q   $??1??6~   $??Center=?6?   	 . 
 .   . ???	#FF0E40EC 6!   ?? *	Product+6?   ?? 5+   
   -   5         ??Name$ Ok??5+      $??3??6   $??2??6*   
????iA?
???????$
??Bold"?6h   $??СОЗДАТЬ ОТЧЕТ??6z   $??20(?6?    5,        5-      5/      50      51      