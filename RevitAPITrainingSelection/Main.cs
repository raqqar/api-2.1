using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
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
            #region Примеры из лекций
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

            ////////////////List<Duct> fInstances = new FilteredElementCollector(doc)
            ////////////////     .OfCategory(BuiltInCategory.OST_DuctCurves)
            ////////////////    .WhereElementIsNotElementType().Cast<Duct>()
            ////////////////    .ToList();

            ////////////////var selectedRef = uidoc.Selection.PickObject(ObjectType.Element, "Change element");
            ////////////////var selectedElement = doc.GetElement(selectedRef);

            ////////////////if(selectedElement is Wall)
            ////////////////{
            ////////////////    Parameter lengthParametr = selectedElement.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH);
            ////////////////    if(lengthParametr.StorageType==StorageType.Double)
            ////////////////    {
            ////////////////        double lengthValue = UnitUtils.ConvertFromInternalUnits(lengthParametr.AsDouble(), UnitTypeId.Meters);
            ////////////////        TaskDialog.Show("Length",lengthValue.ToString());
            ////////////////    }
            ////////////////}           

            ////////////////return Result.Succeeded;

            //////////////////List<Duct> fInstances = new FilteredElementCollector(doc)
            //////////////////     .OfCategory(BuiltInCategory.OST_DuctCurves)
            //////////////////    .WhereElementIsNotElementType().Cast<Duct>()
            //////////////////    .ToList();

            //////////////////var selectedRef = uidoc.Selection.PickObject(ObjectType.Element, "Change element");
            //////////////////var selectedElement = doc.GetElement(selectedRef);

            //////////////////if (selectedElement is FamilyInstance)
            //////////////////{
            //////////////////   var familyInstance = selectedElement as FamilyInstance;
            //////////////////    Parameter widthParameter = familyInstance.Symbol.LookupParameter("Ширина");
            //////////////////    TaskDialog.Show("width info",widthParameter.AsDouble().ToString());

            //////////////////    Parameter widthParameter2 = familyInstance.Symbol.get_Parameter(BuiltInParameter.CASEWORK_WIDTH);
            //////////////////    TaskDialog.Show("width info", widthParameter2.AsDouble().ToString());
            //////////////////}

            //////////////////return Result.Succeeded;

            ////////////////////List<Duct> fInstances = new FilteredElementCollector(doc)
            ////////////////////    .OfCategory(BuiltInCategory.OST_DuctCurves)
            ////////////////////   .WhereElementIsNotElementType().Cast<Duct>()
            ////////////////////   .ToList();

            ////////////////////var selectedRef = uidoc.Selection.PickObject(ObjectType.Element, "Change element");
            ////////////////////var selectedElement = doc.GetElement(selectedRef);

            ////////////////////if (selectedElement is FamilyInstance)
            ////////////////////{
            ////////////////////    using (Transaction ts = new Transaction(doc, "Set parametrs"))
            ////////////////////    {
            ////////////////////        ts.Start();
            ////////////////////        var familyInstance = selectedElement as FamilyInstance;
            ////////////////////        Parameter commentParametr = familyInstance.get_Parameter(BuiltInParameter.ALL_MODEL_INSTANCE_COMMENTS);
            ////////////////////        commentParametr.Set("TestComment");

            ////////////////////        Parameter typeCommentsParametr = familyInstance.Symbol.get_Parameter(BuiltInParameter.ALL_MODEL_TYPE_COMMENTS);
            ////////////////////        ts.Commit();
            ////////////////////    }
            ////////////////////}

            ////////////////////return Result.Succeeded;

            ////IList<Reference> reference = uidoc.Selection.PickObjects(ObjectType.Face, "Выбор стен по грани");
            ////List<ElementId> walls = new List<ElementId>();

            ////double volum = 0;
            ////foreach (var item in reference)
            ////{
            ////    Element element = doc.GetElement(item);
            ////    if (element is Wall)
            ////    {
            ////        Wall wll = element as Wall;


            ////        if (!walls.Contains(wll.Id))
            ////        {
            ////            walls.Add(wll.Id);
            ////            double v1 = wll.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED).AsDouble();
            ////            double v2 = UnitUtils.ConvertFromInternalUnits(v1, UnitTypeId.CubicMeters);

            ////            volum += v2;

            ////        }
            ////    }
            ////}
            ////TaskDialog.Show($"ОбщиЙ объем стен: ", volum.ToString() + "м³");
            ////return Result.Succeeded;
            ///
            ////////IList<Reference> references = uidoc.Selection.PickObjects(
            ////////    ObjectType.Element, selectionFilter: new PipeCurvesFilter(), "Выбор труб");
            ////////double volum = 0;

            ////////foreach (var item in references)
            ////////{
            ////////    Element element = doc.GetElement(item);
            ////////    Pipe pipe = element as Pipe;
            ////////    double v1 = pipe.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble();
            ////////    double v2 = UnitUtils.ConvertFromInternalUnits(v1, UnitTypeId.Millimeters);
            ////////    volum += v2;
            ////////}

            ////////TaskDialog.Show($"Общая длина выбранных труб: ", volum.ToString("0.00") + " мм");
            ////////return Result.Succeeded;
            #endregion

            IList<Reference> references = uidoc.Selection.PickObjects(ObjectType.Element,
                selectionFilter: new PipeFilter(), "Выбор труб");

            
            using (Transaction ts = new Transaction(doc, "Set parametrs"))
            {
                ts.Start();
               
                foreach (var item in references)
                {
                    Element elemPipe = doc.GetElement(item);
                    Pipe pipe = elemPipe as Pipe;
                    double v1 = pipe.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble();
                    Parameter paramPipe = pipe.LookupParameter("Длина с коэффициентом 1.1");
                    paramPipe.Set(v1 * 1.1);
                    
                }
                ts.Commit();
                
            }
            TaskDialog.Show("Сщщбщение \n", "Длина труб изменена с учетом коэффициента 1.1");
            return Result.Succeeded;

        }
    }
}
