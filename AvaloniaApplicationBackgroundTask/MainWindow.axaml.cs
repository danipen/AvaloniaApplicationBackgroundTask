using Avalonia.Controls;

using System;
using System.Threading;

namespace AvaloniaApplicationBackgroundTask
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            mCheckBox = new CheckBox();
            mCheckBox.Content = "IsBackground?";

            Button button = new Button();
            button.Content = "Launch background task";

            button.Click += Button_Click;

            StackPanel stackPanel = new StackPanel();

            stackPanel.Children.Add(mCheckBox);
            stackPanel.Children.Add(button);

            this.Content = stackPanel;
        }

        private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(DoSomethingForever));
            thread.IsBackground = mCheckBox.IsChecked.Value;


            thread.Start();

        }

        private void DoSomethingForever()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(150);
            }
        }

        CheckBox mCheckBox;
    }
}
