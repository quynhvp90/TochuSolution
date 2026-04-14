using IMIP.Tochu.UI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.UI.ViewModels
{
    public partial class MasterViewModel : ViewModelBase
    {
        // Được set từ NavigateTo/OpenWindow trước khi hiển thị
        public Guid? EditId { get; set; }

        // TODO: thêm fields khi thiết kế form
    }
}
