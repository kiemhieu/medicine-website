using System;
using System.Windows.Forms;
using Medical.Forms.EventArgs;
using Medical.Forms.Implements;

namespace Medical.Forms.Interfaces
{
    public interface IMenuManager
    {
        /// <summary>
        /// Bindings the menu item.
        /// </summary>
        /// <param name="cntrl">The CNTRL.</param>
        /// <param name="item">The item.</param>
        void BindingMenuItem(Control cntrl, TopMenuItem item);

        /// <summary>
        /// Creates the menu item.
        /// </summary>
        void CreateMenuItem(int role, params Control [] menuCntrl);

        /// <summary>
        /// Gets the menu item by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        TopMenuItem GetMenuItemByKey(string key);

        void CreateToolBar(ToolStrip toolbar, int role);

        /// <summary>
        /// Occurs when [menu item clicked].
        /// </summary>
        event EventHandler<MenuItemClickedEventArgs> MenuItemClicked;

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        int Count { get;}
        
    }
}

