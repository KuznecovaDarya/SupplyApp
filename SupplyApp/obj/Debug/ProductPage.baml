   M S B A M L   `   `   `  ????D  @SupplyApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SupplyApp	SupplyApp  5          SupplyApp.ProductPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:SupplyApp     5      -   5          N? Title$  SupplierPage??5	       N? 
Background
 ???d?.??5      ?  ? RowDefinitions 5   
   ?? 5      $??* ?6   ?? 5      $??40 ?6   ?? 5      $??30 ?6   .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	DGProduct??5         AutoGenerateColumns .     
IsReadOnly . 
???????   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$! Номер продукта??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6\   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6=   ?? *
Id_Product+6i     5      $ Продукт??6%   $ * 6O   	 66   ?? *Name+6[   4  .System.Windows.Controls.DataGridTemplateColumn  5      $
 auto 6)   
   CellTemplate
 5      ?? 5      .R?5      ??  ??Name$ 
BtnProduct??6%   -   5        $??Перейти??5   9   
????iA?$??18(?6|    J? Effect 5   "   3  -System.Windows.Media.Effects.DropShadowEffect  5   &   5      5      5       5"      ?? 5#   
   -   5        $	 Add??5#      $??ДОБАВИТЬ??6   $??Center=?61   $	??Top=?6N   $	??150??6x   $??30??6?   $??1??6?   $??16(?6?   
???????
????iA?$
??Bold"?6?    5$        5%      5'      ?? 5)   
   -   5         ??Name$ 	TxtSearch??5)      $??16(?6%   $??2??63   $	??540??6@   $??Center=?6M    ? ToolTip$: 4Введите название для поиска.??6j   ?? 5*   
   -   5        $ 	BtnSearch??5*      $??
НАЙТИ??6$   $??2??64   $	??100??6A   
???????$??Right=?6`   $??0,0,10,0q?6?   $??16(?6?   
????iA?$
??Bold"?6?   5+      5,      