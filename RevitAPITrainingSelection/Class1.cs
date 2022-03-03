using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingSelection
{
     class PipeFilter : ISelectionFilter
    {
        public bool AllowElement(Element elemPipe)
        {
            return elemPipe is Pipe;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new System.NotImplementedException();
        }
    }
}
