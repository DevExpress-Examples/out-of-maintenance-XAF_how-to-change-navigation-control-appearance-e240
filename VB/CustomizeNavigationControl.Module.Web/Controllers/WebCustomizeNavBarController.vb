Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Web
Imports DevExpress.ExpressApp.Web.Templates.ActionContainers
Imports DevExpress.ExpressApp.SystemModule

Namespace CustomizeNavigationControl.Module.Web.Controllers
    Public Class WebCustomizeNavBarController
        Inherits WindowController

        Public Sub New()
            TargetWindowType = WindowType.Main
        End Sub
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            AddHandler Frame.GetController(Of ShowNavigationItemController)().ShowNavigationItemAction.CustomizeControl, AddressOf ShowNavigationItemAction_CustomizeControl
        End Sub
        Private Sub ShowNavigationItemAction_CustomizeControl(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.Actions.CustomizeControlEventArgs)
            Dim navBar As ASPxNavBar = TryCast(e.Control, ASPxNavBar)
            If navBar IsNot Nothing Then
                ' Customize the main ASPxNavBar control.
                navBar.EnableAnimation = True
                For Each group As NavBarGroup In navBar.Groups
                    For Each item As NavBarItem In group.Items
                        If TypeOf item Is NavBarTreeViewItem Then
                            Dim innerTreeView As ASPxTreeView = CType(item, NavBarTreeViewItem).TreeViewNavigationControl.Control
                            ' Customize the inner ASPxTreeView control inside the navigation group.
                            innerTreeView.ShowExpandButtons = False
                        End If
                    Next item
                Next group
            Else
                Dim mainTreeView As ASPxTreeView = TryCast(e.Control, ASPxTreeView)
                If mainTreeView IsNot Nothing Then
                    ' Customize the main ASPxTreeView control.
                    mainTreeView.ShowExpandButtons = False
                End If
            End If
        End Sub
        Protected Overrides Sub OnDeactivated()
            MyBase.OnDeactivated()
            RemoveHandler Frame.GetController(Of ShowNavigationItemController)().ShowNavigationItemAction.CustomizeControl, AddressOf ShowNavigationItemAction_CustomizeControl
        End Sub
    End Class
End Namespace
