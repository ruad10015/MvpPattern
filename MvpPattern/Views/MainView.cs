using MvpPattern.Models;
using MvpPattern.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MvpPattern
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public List<Car> Cars
        {
            set
            {
                carListBox.DataSource = null;
                carListBox.DataSource = value;
            }
        }

        public string ModelText { get=>modelTxtbox.Text; set=>modelTxtbox.Text=value; }
        public string VendorText { get => vendorTxtb.Text; set => vendorTxtb.Text=value; }
        public string ColorText { get => colorTxtb.Text; set=>colorTxtb.Text=value; }
        public string TransmissionText { get => transmissionTxtb.Text; set => transmissionTxtb.Text=value; }
        public string YearText { get => yearTxtb.Text; set =>yearTxtb.Text=value; }
        public EventHandler<EventArgs> AddButtonClick { get; set; }
        public EventHandler<EventArgs> LoadButtonClick { get; set; }
        public EventHandler<EventArgs> DoubleClickButton { get; set; }

        public Car SelectedCar {
            get
            {
                return carListBox.SelectedItem as Car;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddButtonClick.Invoke(sender, e);
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            LoadButtonClick.Invoke(sender, e);
        }

        private void carListBox_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickButton.Invoke(sender, e);
        }
    }
}
