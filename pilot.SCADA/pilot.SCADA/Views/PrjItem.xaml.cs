using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using pilot.SCADA.Models;
using pilot.SCADA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pilot.SCADA.Views
{
    /// <summary>
    /// PrjItem.xaml 的交互逻辑
    /// </summary>
    public partial class PrjItem : UserControl
    {
        public PrjItem()
        {
            InitializeComponent();
        }
    }

    class PrjItemViewModel : ViewModelBase
    {
        private ProjectRecordModel _prjModel;
        public ProjectRecordModel PrjModel
        {
            get { return _prjModel; }
            set
            {
                _prjModel = value;
                this.RaisePropertyChanged("PrjModel");
            }
        }


        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="prjModel"></param>
        /// <param name="projectManagerViewModel"></param>
        public PrjItemViewModel(ProjectRecordModel prjModel)
        {

            PrjModel = new ProjectRecordModel
            {
                ProjectName = prjModel.ProjectName,
                ProjectPath = prjModel.ProjectPath,
                SaveTime = prjModel.SaveTime
            };

        }

        #region 命令
        private RelayCommand<object> _myCommand1;
        /// <summary>
        /// 打开工程 的命令
        /// </summary>
        public RelayCommand<object> OpenPrjCommand
        {
            get
            {
                return _myCommand1 ?? (_myCommand1 = new RelayCommand<object>(OpenPrj));
            }
        }
        public void OpenPrj(object param)
        {
            //_projectManagerViewModel.OpenProjectFromRecord(PrjModel);
        }

        #endregion
    }
}
