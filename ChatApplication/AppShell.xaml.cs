using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ChatApplication
{
    public partial class AppShell : Shell
    {
        public ObservableCollection<Tab> tabs { get; set; }
        public AppShell()
        {
            tabs = new ObservableCollection<Tab>();
            var tab = new Tab()
            {
                Title = "AddedTab",
                Items =
                {
                    new ShellContent()
                    {
                        Title = "AddedContent",
                        Route = "AddedContent",
                        ContentTemplate = new DataTemplate(typeof(MainPage))
                    }
                }
            };

            var tab2 = new Tab()
            {
                Title = "AddedTab2",
                Items =
                {
                    new ShellContent()
                    {
                        Title = "AddedContent2",
                        Route = "AddedContent2",
                        ContentTemplate = new DataTemplate(typeof(MainPage))
                    }
                }
            };
            tabs.CollectionChanged += TabsChanged;
            InitializeComponent();
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                tabs.Add(tab);
                tabs.Add(tab2);
            });
        }

        private void TabsChanged(object? source, NotifyCollectionChangedEventArgs e)
        {
            //MainThread.BeginInvokeOnMainThread(() => TabMenu.Items.Clear());
            foreach (var item in tabs)
            {
                MainThread.BeginInvokeOnMainThread(() => {TabMenu.Items.Add(item); });
            }
        }
    }
}
