using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp;
using DevExpress.Web.ASPxNavBar;
using DevExpress.ExpressApp.Web.Templates.ActionContainers;
using DevExpress.Web.ASPxTreeView;

namespace CustomizeNavigationControl.Module.Web.Controllers {
    public class WebCustomizeNavBarController : WindowController {
        public WebCustomizeNavBarController() {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated() {
            base.OnActivated();
            Frame.ProcessActionContainer += Frame_ProcessActionContainer;
        }
        private void Frame_ProcessActionContainer(object sender, ProcessActionContainerEventArgs e) {
            if(e.ActionContainer is NavigationActionContainer) {
                ASPxNavBar navBar = ((NavigationActionContainer)e.ActionContainer).NavigationControl as ASPxNavBar;
                if(navBar != null) {
                    // Customize the main ASPxNavBar control.
                    navBar.EnableAnimation = true;
                    foreach(NavBarGroup group in navBar.Groups) {
                        foreach(NavBarItem item in group.Items) {
                            if(item is NavBarTreeViewItem) {
                                ASPxTreeView innerTreeView = ((NavBarTreeViewItem)item).TreeViewNavigationControl.Control;
                                // Customize the inner ASPxTreeView control inside the navigation group.
                                innerTreeView.ShowExpandButtons = false;
                            }
                        }
                    }
                }
                else {
                    ASPxTreeView mainTreeView = ((NavigationActionContainer)e.ActionContainer).NavigationControl as ASPxTreeView;
                    if(mainTreeView != null) {
                        // Customize the main ASPxTreeView control.
                        mainTreeView.ShowExpandButtons = false;
                    }
                }
            }
        }
        protected override void OnDeactivated() {
            base.OnDeactivated();
            Frame.ProcessActionContainer -= Frame_ProcessActionContainer;
        }
    }
}
