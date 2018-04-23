Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp.Win.Templates.ActionContainers
Imports DevExpress.ExpressApp
Imports DevExpress.XtraNavBar

Namespace CustomizeNavigationControl.Module.Win.Controllers
    Public Class WinCustomizeNavBarController
        Inherits WindowController

        Private navActionContainer As NavigationActionContainer
        Protected Overrides Sub OnActivated()
            MyBase.OnActivated()
            AddHandler Window.ProcessActionContainer, AddressOf Window_ProcessActionContainer
        End Sub
        Protected Overrides Sub OnDeactivated()
            RemoveHandler Window.ProcessActionContainer, AddressOf Window_ProcessActionContainer
            UnsubscribeFromContainerEvents()
            navActionContainer = Nothing
            MyBase.OnDeactivated()
        End Sub
        Private Sub Window_ProcessActionContainer(ByVal sender As Object, ByVal e As ProcessActionContainerEventArgs)
            UnsubscribeFromContainerEvents()
            If TypeOf e.ActionContainer Is NavigationActionContainer Then
                navActionContainer = TryCast(e.ActionContainer, NavigationActionContainer)
                SubscribeToContainerEvents()
                SetupNavBar()
            End If
        End Sub
        Private Sub SubscribeToContainerEvents()
            If navActionContainer IsNot Nothing Then
                AddHandler navActionContainer.NavigationControlCreated, AddressOf navigationControlCreated
            End If
        End Sub
        Private Sub UnsubscribeFromContainerEvents()
            If navActionContainer IsNot Nothing Then
                RemoveHandler navActionContainer.NavigationControlCreated, AddressOf navigationControlCreated
            End If
        End Sub
        Private Sub navigationControlCreated(ByVal sender As Object, ByVal e As EventArgs)
            SetupNavBar()
        End Sub
        Private Sub SetupNavBar()
            If navActionContainer IsNot Nothing AndAlso TypeOf navActionContainer.NavigationControl Is NavBarNavigationControl Then
                Dim navBarNavigationControl As NavBarNavigationControl = TryCast(navActionContainer.NavigationControl, NavBarNavigationControl)
                navBarNavigationControl.SkinExplorerBarViewScrollStyle = SkinExplorerBarViewScrollStyle.ScrollBar
                navBarNavigationControl.PaintStyleKind = NavBarViewKind.ExplorerBar
            End If
        End Sub
    End Class
End Namespace
