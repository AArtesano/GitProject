   M S B A M L   `   `   `  ????E  AGitProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:GitProject
GitProject  5   	       GitProject.GuardianWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:GitProject     5   	     ? Title$  GuardianWindow??5   	   $	??430??6    $	??443??6-   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   ?? 5      $??35 ?6   .+?5   
   ?? $??
First Name??6   $??3q?6%   ?? 5   
   -   5         ??Name$ txtFirstname??5      $??1??6(   $??3q?65   ?? 5   
   $??Middle Name??6   $??2??6&   $??3q?63   ?? 5   
   -   5        $ txtMiddlename??5      $??3??6)   $??3q?66   ?? 5   
   $??	Last Name??6   $??4??6$   $??3q?61   ?? 5   
   -   5        $ txtLastname??5      $??5??6'   $??3q?64   ?? 5!   
   $??Birthday??6   $??6??6#   $??3q?60   (  "System.Windows.Controls.DatePicker  5"   
   -   5          Name$ dtpBirthday??5"      $??7??6*   $??3q?67   ?? 5$   
   $??Relationship??6   $??8??6'   $??3q?64   ?? 5%   
   -   5        $ txtRelationship??5%      $??9??6+   $??3q?68   ?? 5'   
    ?? Orientation$ 
Horizontal=?6   $??Center=?6.   $??10??6K   .+?5(      ?? -   5         ??Name$ btnSave??5(      $
??Save??6&   $??3q?65   $??80??6@   6K   ?? 5)      -   5        $ 	btnCancel??5)      $??Cancel??6(   $??3q?69   $??80??6D   6O   5*      5,      5-      