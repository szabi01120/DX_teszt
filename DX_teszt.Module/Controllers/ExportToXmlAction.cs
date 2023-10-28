using System.Xml;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;

public class ExportToXmlAction : ObjectViewController<ListView, OrderInHeader> {
    public ExportToXmlAction()
    {
        SimpleAction exportToXmlAction = new SimpleAction(this, "ExportToXmlAction", PredefinedCategory.Export)
        {
            Caption = "Export to XML",
            ImageName = "Action_ExportToXML"
        };
        exportToXmlAction.SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects;
        exportToXmlAction.Execute += ExportToXmlAction_Execute;
    }
    private void ExportToXmlAction_Execute(object sender, SimpleActionExecuteEventArgs e)
    {
        // Get the selected objects
        IList<OrderInHeader> selectedObjects = e.SelectedObjects.OfType<OrderInHeader>().ToList();    
        IList<OrderInRows> objectsInRow = e.SelectedObjects.OfType<OrderInRows>().ToList();


        if (selectedObjects.Count > 0)
        {
            // Create an XML document
            XmlDocument xmlDoc = new XmlDocument();

            // Create the root element
            XmlElement rootElement = xmlDoc.CreateElement("YourObjects");
            xmlDoc.AppendChild(rootElement);

            // Loop through the selected objects
            foreach (OrderInHeader selectedObject in selectedObjects)
            {
                // Create elements for each object's properties and add them to the root element
                XmlElement objectElement = xmlDoc.CreateElement("Object");
                rootElement.AppendChild(objectElement);

                XmlElement property1Element = xmlDoc.CreateElement("ID");
                property1Element.InnerText = selectedObject.ID.ToString();
                objectElement.AppendChild(property1Element);


                /*foreach (OrderInRows selectedObject_Rows in objectsInRow)
                {
                    //if (selectedObject_Rows.OrderInHeader.ToString() == selectedObject.ID.ToString())
                    //{
                        XmlElement property1Element = xmlDoc.CreateElement("ID");
                        property1Element.InnerText = selectedObject.ID.ToString();
                        objectElement.AppendChild(property1Element);

                        XmlElement property2Element = xmlDoc.CreateElement("OrderInHeader");
                        property2Element.InnerText = selectedObject_Rows.OrderInHeader.ToString();
                        objectElement.AppendChild(property2Element);

                        // Add more properties as needed
                    //}

                }*/
            }

            // Specify the file path for the XML output
            string outputPath = @"C:\Users\hajna\source\repos\DX_teszt\DX_teszt.Module\Controllers\File.xml";

            // Save the XML document to a file
            xmlDoc.Save(outputPath);
        }
    }
}

