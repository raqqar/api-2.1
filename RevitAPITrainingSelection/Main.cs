using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingSelection
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            //IList<Reference> selectedElementRefList = uidoc.Selection.PickObjects(ObjectType.Element, new WallFilter(), "Выберите стены");
            //var wallList = new List<Wall>();

            //string info = string.Empty;
            //foreach (var selectedElement in selectedElementRefList)
            //{
            //    Wall oWall = doc.GetElement(selectedElement) as Wall;
            //    wallList.Add(oWall);
            //    var width = UnitUtils.ConvertFromInternalUnits(oWall.Width, UnitTypeId.Millimeters);
            //    info+=$"Name: {oWall.Name}, width:{width}{Environment.NewLine}";

            //}

            //info += $"Количество: {wallList.Count}";

            //TaskDialog.Show("Selection", info);
            ////XYZ pickedPoint=null;
            ////try
            ////{
            ////    pickedPoint = uidoc.Selection.PickPoint(ObjectSnapTypes.Endpoints, "Выберите точку");
            ////}
            ////catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            ////{}
            ////if (pickedPoint == null)
            ////{
            ////    return Result.Cancelled;
            ////}
            ////TaskDialog.Show("Point info", $"X:{pickedPoint.X}, Y:{pickedPoint.Y}, Z:{pickedPoint.Z}");
            ////return Result.Succeeded;
            //////List<FamilyInstance> fInstances = new FilteredElementCollector(doc,doc.ActiveView.Id)
            //////    .OfCategory(BuiltInCategory.OST_Doors)
            //////    .WhereElementIsNotElementType().Cast<FamilyInstance>()
            //////    .ToList();
            //////TaskDialog.Show("Doors count:", fInstances.Count.ToString());

            //////return Result.Cancelled;

            ////////var walls = new FilteredElementCollector(doc)
            ////////    .OfClass(typeof(Wall))
            ////////    .Cast<Wall>()
            ////////    .ToList();
            ////////TaskDialog.Show("Wall info:", walls.Count.ToString());

            ////////return Result.Cancelled;

            //////////ElementCategoryFilter windowsCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Windows);
            //////////ElementClassFilter windowsInstancesFilter = new ElementClassFilter(typeof(FamilyInstance));

            //////////LogicalAndFilter windowsFilter = new LogicalAndFilter(windowsCategoryFilter,windowsInstancesFilter);
            //////////var windows =new FilteredElementCollector(doc)
            //////////    .WherePasses(windowsFilter)
            //////////    .Cast<FamilyInstance>()
            //////////    .ToList();
            //////////TaskDialog.Show("windows info", windows.Count.ToString());
            //////////return Result.Succeeded;

            //////////////List<FamilySymbol> doorTypes=new FilteredElementCollector(doc)
            //////////////    .OfCategory(BuiltInCategory.OST_Doors)
            //////////////    .WhereElementIsElementType()
            //////////////    .Cast<FamilySymbol>()
            //////////////    .ToList();

            List<Element> fInstances = new FilteredElementCollector(doc)
                 .OfCategory(BuiltInCategory.OST_Columns)
                .WhereElementIsNotElementType().Cast<Element>()
                .ToList();
                TaskDialog.Show("Columns count:", fInstances.Count.ToString());
          
            return Result.Succeeded;
        }

    }
}
