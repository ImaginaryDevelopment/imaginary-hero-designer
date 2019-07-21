using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hero_Designer
{
    public class ListBoxT<T>
    {
        readonly ListBox _lb;
        public T SelectedItem { get => (T)_lb.SelectedItem; set => _lb.SelectedItem = value; }
        public void AddItem(T item) => _lb.Items.Add(item);
        public ListBoxT(ListBox lb) => this._lb = lb;

    }
    public class ComboBoxT<T>
    {
        readonly ComboBox _cb;

        public ComboBoxT(ComboBox cb) => this._cb = cb;

        public T SelectedItem { get => (T)_cb.SelectedItem; set => _cb.SelectedItem = value; }
        public Rectangle Bounds => this._cb.Bounds;
        public int Count => this._cb.Items.Count;
        public IReadOnlyCollection<T> Items { get => new ReadOnlyCollection<T>(_cb.Items.Cast<T>().ToList()); }
        public void BeginUpdate() => _cb.BeginUpdate();
        public void Clear() => _cb.Items.Clear();
        public void AddRange(IEnumerable<T> items)
        {
            _cb.SuspendLayout();
            _cb.Items.AddRange(items.Cast<object>().ToArray());
            _cb.ResumeLayout();
        }
        public void EndUpdate() => _cb.EndUpdate();
        public bool Enabled { get => _cb.Enabled; set => _cb.Enabled = value; }
        public int SelectedIndex { get => _cb.SelectedIndex; set => _cb.SelectedIndex = value; }
        public ComboBox Value => _cb;
        public T this[int x]
        {
            get => (T)this._cb.Items[x];
            set => this._cb.Items[x] = value;
        }
    }

    public static class Extensions
    {
        public static void EventHandlerWithCatch(this IComponent _, Action f, string titlingOpt = null, string captionOpt = null) => ExecuteWithCatchMessage(f, titlingOpt, captionOpt);
        // execute immediately with a catch
        public static void ExecuteWithCatchMessage(this Action f, string titlingOpt = null, string captionOpt = null)
        {
            try
            {
                f();
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null && ex.InnerException.Message != null)
                    ex = ex.InnerException;
                MessageBox.Show(string.IsNullOrWhiteSpace(titlingOpt) ? ex.Message : (titlingOpt + ":" + ex.Message), captionOpt ?? ex.GetType().Name);
            }
        }

        // this could be chained indefinitely so... be careful with it
        // defer the execution until later
        public static Action WithCatchMessage(this Action f, string titling, string captionOpt = null)
        {
            return () => ExecuteWithCatchMessage(f, titling, captionOpt);
        }

        // does not handle the possibility this is a child control, and a parent is in design mode
        public static bool IsInDesignMode(this Control c) => LicenseManager.UsageMode == LicenseUsageMode.Designtime || c?.Site?.DesignMode == true;

    }
}
