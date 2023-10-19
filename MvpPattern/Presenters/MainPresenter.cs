using MvpPattern.Data;
using MvpPattern.Models;
using MvpPattern.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MvpPattern.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;
        private readonly CarContext _db;
        public MainPresenter(IMainView view)
        {
            _view = view;

            _db = new CarContext();

            _view.AddButtonClick += ViewAddButtonClick;

            _view.LoadButtonClick += ViewLoadButtonClick;

            _view.DoubleClickButton += ViewDoubleClick;
        }

        private void ViewDoubleClick(object sender, EventArgs e)
        {
            try
            {
                var car = _view.SelectedCar;
                var dialog = MessageBox.Show("Are you sure to delete ?", car.ToString(), MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    _db.Cars.Remove(car);
                    _db.SaveChanges();
                    var cars = _db.Cars.ToList();
                    _view.Cars = cars;
                }
            }
            catch (Exception)
            {
            }
        }

        private void ViewLoadButtonClick(object sender, EventArgs e)
        {
            var cars = _db.Cars.ToList();
            _view.Cars = cars;
        }

        private void ViewAddButtonClick(object sender, EventArgs e)
        {
            var car = new Car
            {
                Model = _view.ModelText,
                Color = _view.ColorText,
                Transmission = _view.TransmissionText,
                Vendor = _view.VendorText,
                Year = int.Parse(_view.YearText)
            };
            _db.Cars.Add(car);
            _db.SaveChanges();

            _view.VendorText = "";
            _view.ModelText = "";
            _view.ColorText = "";
            _view.TransmissionText = "";
            _view.YearText = "";

        }
    }
}
