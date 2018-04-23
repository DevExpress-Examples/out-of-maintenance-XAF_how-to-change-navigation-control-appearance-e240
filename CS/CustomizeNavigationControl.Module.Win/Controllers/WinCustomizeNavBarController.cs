using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;
using DevExpress.ExpressApp;
using DevExpress.XtraNavBar;

namespace CustomizeNavigationControl.Module.Win.Controllers {
    public class WinCustomizeNavBarController : WindowController {
        private NavigationActionContainer navActionContainer;
        protected override void OnActivated() {
            base.OnActivated();
            Window.ProcessActionContainer += Window_ProcessActionContainer;
        }
        protected override void OnDeactivated() {
            Window.ProcessActionContainer -= Window_ProcessActionContainer;
            UnsubscribeFromContainerEvents();
            navActionContainer = null;
            base.OnDeactivated();
        }
        void Window_ProcessActionContainer(object sender, ProcessActionContainerEventArgs e) {
            UnsubscribeFromContainerEvents();
            if (e.ActionContainer is NavigationActionContainer) {
                navActionContainer = e.ActionContainer as NavigationActionContainer;
                SubscribeToContainerEvents();
                SetupNavBar();
            }
        }
        private void SubscribeToContainerEvents() {
            if (navActionContainer != null) {
                navActionContainer.NavigationControlCreated += navigationControlCreated;
            }
        }
        private void UnsubscribeFromContainerEvents() {
            if (navActionContainer != null) {
                navActionContainer.NavigationControlCreated -= navigationControlCreated;
            }
        }
        private void navigationControlCreated(object sender, EventArgs e) {
            SetupNavBar();
        }
        private void SetupNavBar() {
            if (navActionContainer != null &&
                navActionContainer.NavigationControl is NavBarNavigationControl) {
                NavBarNavigationControl navBarNavigationControl =
                    navActionContainer.NavigationControl as NavBarNavigationControl;
                navBarNavigationControl.SkinExplorerBarViewScrollStyle =
                    SkinExplorerBarViewScrollStyle.ScrollBar;
                navBarNavigationControl.PaintStyleKind = NavBarViewKind.ExplorerBar;
            }
        }
    }
}
