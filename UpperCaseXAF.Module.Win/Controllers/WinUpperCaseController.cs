using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;

namespace UpperCaseXAF.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class WinUpperCaseController : ViewController
    {

        System.Collections.Generic.IList<StringPropertyEditor> _editor;
        public WinUpperCaseController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();


                var detailView = View as DetailView;
                if (detailView != null)
                {
                    _editor = detailView.GetItems<StringPropertyEditor>(); //as StringPropertyEditor;
                    if (_editor != null)
                    {
                        foreach (var editor in _editor)
                        {
                            editor.ControlCreated += editor_ControlCreated;
                        }


                    }
                }
            

            // Perform various tasks depending on the target View.
        }

        void editor_ControlCreated(object sender, EventArgs e)
        {


            ((StringPropertyEditor)sender).Control.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;


        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();

            
                var listView = View as ListView;
                GridListEditor gridListEditor = listView?.Editor as GridListEditor;
                if (gridListEditor != null)
                {
                    var gridControl = gridListEditor.Grid;
                    RepositoryItemTextEdit editor = (RepositoryItemTextEdit)gridControl.RepositoryItems.Add("TextEdit");
                    editor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                    foreach (GridColumn col in gridListEditor.GridView.Columns)
                        col.ColumnEdit = editor;
                }
                // Access and customize the target View control.
            
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
            if (_editor != null)
            {

                foreach (var editor in _editor)
                {
                    editor.ControlCreated -= editor_ControlCreated;
                }

                _editor = null;
            }
        }
    }
}
