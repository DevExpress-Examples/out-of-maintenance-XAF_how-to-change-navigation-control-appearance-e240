Imports DevExpress.ExpressApp
Imports DevExpress.XtraNavBar
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.XtraTreeList

Namespace CustomizeNavigationControl.Module.Win.Controllers
    Public Class WinCustomizeNavBarController
        Inherits WindowController

        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            Dim navigationController As ShowNavigationItemController = Frame.GetController(Of ShowNavigationItemController)()
            If navigationController IsNot Nothing Then
                AddHandler Frame.GetController(Of ShowNavigationItemController)().ShowNavigationItemAction.CustomizeControl, AddressOf ShowNavigationItemAction_CustomizeControl
            End If
        End Sub
        Private Sub ShowNavigationItemAction_CustomizeControl(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.Actions.CustomizeControlEventArgs)
            Dim navBar As NavBarControl = TryCast(e.Control, NavBarControl)
            If navBar IsNot Nothing Then
                ' Customize NavBar
                For Each group As NavBarGroup In navBar.Groups
                    If group.ControlContainer IsNot Nothing AndAlso group.ControlContainer.Controls.Count = 1 Then
                        Dim treeList As TreeList = TryCast(group.ControlContainer.Controls(0), TreeList)
                        ' Customize embedded TreeList
                    End If
                Next group
            Else
                Dim treeList As TreeList = TryCast(e.Control, TreeList)
                If treeList IsNot Nothing Then
                    ' Customize TreeList
                End If
            End If
        End Sub
        Protected Overrides Sub OnDeactivated()
            Dim navigationController As ShowNavigationItemController = Frame.GetController(Of ShowNavigationItemController)()
            If navigationController IsNot Nothing Then
                RemoveHandler Frame.GetController(Of ShowNavigationItemController)().ShowNavigationItemAction.CustomizeControl, AddressOf ShowNavigationItemAction_CustomizeControl
            End If
            MyBase.OnDeactivated()
        End Sub
    End Class
End Namespace
