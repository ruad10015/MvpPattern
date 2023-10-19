using MvpPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvpPattern.Views
{
    public interface IMainView
    {
        List<Car> Cars { set; }
        string ModelText { get; set; }
        string VendorText { get; set; }
        string ColorText { get; set; }
        string TransmissionText { get; set; }
        string YearText { get; set; }
        Car SelectedCar { get; }
        EventHandler<EventArgs> AddButtonClick { get; set; }
        EventHandler<EventArgs> LoadButtonClick { get; set; }
        EventHandler<EventArgs> DoubleClickButton { get; set; }
    }
}
