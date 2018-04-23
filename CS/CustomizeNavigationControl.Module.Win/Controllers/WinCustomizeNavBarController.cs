using DevExpress.ExpressApp;
using DevExpress.XtraNavBar;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.XtraTreeList;

namespace CustomizeNavigationControl.Module.Win.Controllers {
    public class WinCustomizeNavBarController : WindowController {
        protected override void OnActivated() {
            base.OnActivated();
            ShowNavigationItemController navigationController = Frame.GetController<ShowNavigationItemController>();
            if (navigationController != null) {
                Frame.GetController<ShowNavigationItemController>().ShowNavigationItemAction.CustomizeControl += ShowNavigationItemAction_CustomizeControl;
            }
        }
        private void ShowNavigationItemAction_CustomizeControl(object sender,
    DevExpress.ExpressApp.Actions.CustomizeControlEventArgs e) {
            NavBarControl navBar = e.Control as NavBarControl;
            if (navBar != null) {
                // Customize NavBar
                foreach (NavBarGroup group in navBar.Groups) {
                    if (group.ControlContainer != null && group.ControlContainer.Controls.Count == 1) {
                        TreeList treeList = group.ControlContainer.Controls[0] as TreeList;
                        // Customize embedded TreeList
                    }
                }
            }
            else {
                TreeList treeList = e.Control as TreeList;
                if (treeList != null) {
                    // Customize TreeList
                }
            }
        }
        protected override void OnDeactivated() {
            ShowNavigationItemController navigationController = Frame.GetController<ShowNavigationItemController>();
            if (navigationController != null) {
                Frame.GetController<ShowNavigationItemController>().ShowNavigationItemAction.CustomizeControl -= ShowNavigationItemAction_CustomizeControl;
            }
            base.OnDeactivated();
        }
    }
}
