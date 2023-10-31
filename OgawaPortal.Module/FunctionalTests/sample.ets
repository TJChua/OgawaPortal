;#DropDB OgawaPortalEasyTest

#Application OgawaPortalWin
;#Application OgawaPortalWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef OgawaPortalWin

*Action About...
 
*Action OK

#EndIf

#IfDef OgawaPortalWeb
*Action Navigation(My Details)
#EndIf
