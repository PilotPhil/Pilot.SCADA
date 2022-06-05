/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:pilot.SCADA" x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using pilot.Comms.DataBuffer;
using pilot.DAL.Serialization;
using pilot.SCADA.Global;
using pilot.SCADA.Models;
using pilot.SCADA.Sensor;
using pilot.SCADA.Views;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace pilot.SCADA.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            //����Ĭ�ϵ�simpleIOC
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            #region ע��ViewModels
            SimpleIoc.Default.Register<MainViewModel>();//ע��mainviewmodel
            SimpleIoc.Default.Register<FrameworkElement>(() => new Views.ProjectManagViewModel());//ע�� ͼֽҳ�� ��������mainview��ʱ����ʾ��--->mainviewmodel������

             SimpleIoc.Default.Register<ISerialize, JsonSerialize>(true);//���л�--->ʹ��json���л�
            SimpleIoc.Default.Register<IDataBuffer, RelatedDataBuffer>(true);//modbus���ݶ�ȡ�洢--->ʹ���ֵ�����Դ洢
            SimpleIoc.Default.Register<ISensorManage, SensorCollection>();//

            SimpleIoc.Default.Register<SerialViewModel>();
            SimpleIoc.Default.Register<ModbusViewModel>();

            SimpleIoc.Default.Register<ProjectManagViewModel>();
            SimpleIoc.Default.Register<NewProjectViewModel>();

            SimpleIoc.Default.Register<LogRecordViewModel>(true);

            SimpleIoc.Default.Register<DataCheckViewModel>();

            SimpleIoc.Default.Register<CreateSensorModelView>();
            SimpleIoc.Default.Register<SensorManagerViewModel>();

            SimpleIoc.Default.Register<TiledViewModel>();
            SimpleIoc.Default.Register<TiledCheckViewModel>();


           
            #endregion
        }

        #region viewModel
        public MainViewModel Main
        {
            get
            {
                //public MainViewModel(FrameworkElement initContent);//�����Զ�ƥ��ע�������
                return ServiceLocator.Current.GetInstance<MainViewModel>();//��ʼҳ��Ϊ ������̼�¼
            }
        }

        public SerialViewModel SerialCom
        {
            get
            {
                //public SerialComViewModel(ISerialize serialize);//�����Զ�ƥ��ע�������
                return ServiceLocator.Current.GetInstance<SerialViewModel>();//
            }
        }

        public ModbusViewModel Modbus
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ModbusViewModel>();//
            }
        }

        public ProjectManagViewModel ProjectManager
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProjectManagViewModel>();//
            }
        }

        public NewProjectViewModel NewProject
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NewProjectViewModel>(Guid.NewGuid().ToString());//ÿ�ζ���һ��
            }
        }

        public LogRecordViewModel LogRecord
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LogRecordViewModel>();
            }
        }

        public DataCheckViewModel DataCheck
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DataCheckViewModel>();
            }
        }

        public CreateSensorModelView CreateSensor
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CreateSensorModelView>(Guid.NewGuid().ToString());//�����´�������Ҫÿ��ʵ����һ��
            }
        }

        public SensorManagerViewModel SensorManager
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SensorManagerViewModel>();
            }
        }

        public TiledViewModel Tiled
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TiledViewModel>(Guid.NewGuid().ToString());
            }
        }

        public TiledCheckViewModel TiledCheck
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TiledCheckViewModel>(Guid.NewGuid().ToString());
            }
        }
        #endregion

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}