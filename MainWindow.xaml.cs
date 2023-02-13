using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (var uiElement in OperationGrid.Children)
            {
                if (uiElement is Button)
                {
                    ((Button)uiElement).Click += ButtonClick;
                }
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs routedEventArgs)
        {
            try
            {
                string textButton = ((Button)routedEventArgs.OriginalSource).Content.ToString();

                switch (textButton)
                {
                    case "C":
                        textLabel.Clear();
                        break;

                    case "←":

                        if (textLabel.Text.Length <= 0)
                        {
                            break;
                        }

                        textLabel.Text = textLabel.Text.Substring(0, textLabel.Text.Length - 1);
                        break;

                    case "=":
                        textLabel.Text = new DataTable().Compute(textLabel.Text, null).ToString();
                        textLabel.Text = textLabel.Text.Replace(",", ".");
                        break;

                    default:
                        textLabel.Text += textButton;
                        break;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
