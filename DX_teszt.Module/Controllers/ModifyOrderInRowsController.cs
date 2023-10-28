using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;

public class ModifyOrderInRowsController : ObjectViewController<ListView, OrderInRows>
{
    public ModifyOrderInRowsController()
    {
        SimpleAction modifyOrderAction = new SimpleAction(this, "aModOrderInRows", PredefinedCategory.Edit);
        modifyOrderAction.Caption = "aModOrderInRows";
        modifyOrderAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
        modifyOrderAction.Execute += ModifyOrderAction_Execute;
    }

    private void ModifyOrderAction_Execute(object sender, SimpleActionExecuteEventArgs e)
    {
        OrderInRows selectedObject = View.CurrentObject as OrderInRows;
        if (selectedObject != null)
        {
            string additionalText = "vasaló";
            int startingPosition = 4; 

            selectedObject.PartName = selectedObject.PartName.Insert(startingPosition, additionalText);

            ObjectSpace.SetModified(selectedObject);
            ObjectSpace.CommitChanges();
        }
    }
}