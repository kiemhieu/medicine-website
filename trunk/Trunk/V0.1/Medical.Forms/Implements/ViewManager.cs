using System;
using System.Collections.Generic;
using Medical.Forms.Enums;
using Medical.Forms.EventArgs;
using Medical.Forms.Interfaces;
using WeifenLuo.WinFormsUI.Docking;

namespace Medical.Forms.Implements {

    public class ViewManager {

        private IContainerProvider _container;
        private DockPanel _dockPane;

        private readonly Dictionary<String, DockContent> _documentList;
        private String _currentDoc;

        public ViewManager(IContainerProvider container, DockPanel dockingPane) {
            this._container = container;
            this._dockPane = dockingPane;
            this._documentList = new Dictionary<String, DockContent>();
        }

        public void ShowDocument(String documentId) {
            DockContent content;
            if (this._documentList.TryGetValue(documentId, out content)) {
                content.Activate();
                return;
            }

            content = this._container.GetComponentByKey(documentId) as DockContent; 
            if (content == null) throw new Exception("Khong có class " + documentId);
            content.Closed += new EventHandler(ContentClosed);
            content.Tag = documentId;
            content.Show(this._dockPane);
            this._documentList.Add(documentId, content);
            content.Activate();
        }

        private void ContentClosed(object sender, System.EventArgs e)
        {
            var content = sender as DockContent;
            if (content != null) this._documentList.Remove(content.Tag.ToString());
        }
    }
}
