Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Web.ASPxNavBar
Imports DevExpress.ExpressApp.Web.Templates.ActionContainers
Imports DevExpress.Web.ASPxTreeView

Namespace CustomizeNavigationControl.Module.Web.Controllers
    Public Class WebCustomizeNavBarController
        Inherits WindowController

        Public Sub New()
            TargetWindowType = WindowType.Main
        End Sub
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            AddHandler Frame.ProcessActionContainer, AddressOf Frame_ProcessActionContainer
        End Sub
        Private Sub Frame_ProcessActionContainer(ByVal sender As Object, ByVal e As ProcessActionContainerEventArgs)
            If TypeOf e.ActionContainer Is NavigationActionContainer Then
                Dim navBar As ASPxNavBar = TryCast(CType(e.ActionContainer, NavigationActionContainer).NavigationControl, ASPxNavBar)
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
                    Dim mainTreeView As ASPxTreeView = TryCast(CType(e.ActionContainer, NavigationActionContainer).NavigationControl, ASPxTreeView)
                    If mainTreeView IsNot Nothing Then
                        ' Customize the main ASPxTreeView control.
                        mainTreeView.ShowExpandButtons = False
                    End If
                End If
            End If
        End Sub
        Protected Overrides Sub OnDeactivated()
            MyBase.OnDeactivated()
            RemoveHandler Frame.ProcessActionContainer, AddressOf Frame_ProcessActionContainer
        End Sub
    End Class
End Namespace
