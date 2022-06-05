using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using pilot.SCADA.Global;
using pilot.SCADA.Models;
using pilot.SCADA.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace pilot.SCADA.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// 主界面CTOR
        /// </summary>
        /// <param name="initContent">主界面初始显示页面</param>
        /// <param name="projectManagerViewModel">依赖项目管理对象</param>
        /// <param name="modbusViewModel">依赖modbus对象，通过其控制开始、停止读数据</param>
        public MainViewModel(FrameworkElement initContent)
        {
            //依赖反转，外部使用依赖注入，
            this.MainDispContent = initContent;

            //还是依赖对象，未依赖 高层的接口
            //this._projectManagerViewModel = projectManagerViewModel;
            //还是依赖对象，未依赖 高层的接口

            //一旦工程管理 里面的 选中的工程 改变了，就切换到 TiledView，跳转页面
            Messenger.Default.Register<object>(this, "HasSelectedProjectToken", (o) => 
            { 
                this.SwitchContent("TiledView"); 
            });
        }


        #region 属性
        private FrameworkElement _mainDispContent;
        /// <summary>
        /// 主显示区域内容
        /// </summary>
        public FrameworkElement MainDispContent
        {
            get { return _mainDispContent; }
            set
            {
                if (_mainDispContent == value) { return; }
                _mainDispContent = value;
                RaisePropertyChanged(() => MainDispContent);
            }
        }

        #endregion


        #region 命令
        private RelayCommand<object> _myCommand1;
        /// <summary>
        /// 退出系统 的命令
        /// </summary>
        public RelayCommand<object> Exitcommand
        {
            get
            {
                return _myCommand1 ?? (_myCommand1 = new RelayCommand<object>(Exit));
            }
        }
        private void Exit(object param)
        {
            LogRecordModel log = null;
            try
            {
                Environment.Exit(Environment.ExitCode);
            }
            catch (Exception ex)
            {
                log = new LogRecordModel()
                {
                    Content = ex.Message,
                    Type = LogType.Failed
                };
            }
            finally
            {
                GlobalValues.Log(log);
            }
        }

        private RelayCommand _myCommand2;
        /// <summary>
        /// 打开新建传感器view 的命令
        /// </summary>
        public RelayCommand OpenNewSensorCommand
        {
            get
            {
                return _myCommand2 ?? (_myCommand2 = new RelayCommand(OpenNewSensor));
            }
        }
        private void OpenNewSensor()
        {
            LogRecordModel log = null;

            try
            {
                //还未选择工程文件时
                if (string.IsNullOrEmpty(GlobalValues.CurrentProjectPath))
                {
                    throw new Exception("未新建或选择工程");
                }

                //var model = new Models.SensorModel();
                //new CreateSensorView(ref model, null).ShowDialog();
                //使用messenger通知createsensorviewmodel新建传感器
            }
            catch (Exception ex)
            {
                log = new LogRecordModel()
                {
                    Content = ex.ToString(),
                    Type = LogType.Failed
                };
            }
            finally
            {
                GlobalValues.Log(log);
            }
        }

        private RelayCommand<object> _myCommand3;
        /// <summary>
        /// 打开 串口 socket modbus设置页面 命令 的命令
        /// </summary>
        public RelayCommand<object> OpenViewCommand
        {
            get
            {
                return _myCommand3 ?? (_myCommand3 = new RelayCommand<object>(OpenView));
            }
        }
        private void OpenView(object param)
        {
            LogRecordModel log = null;
            try
            {
                //还未选择工程文件时
                if (string.IsNullOrEmpty(GlobalValues.CurrentProjectPath))
                {
                    throw new Exception("未新建或选择工程");
                }

                var typeStr = "pilot.SCADA.Views." + param.ToString();
                Type type = Type.GetType(typeStr);

                if (type == null)//找不到此类型结束
                    return;

                object obj = type.Assembly.CreateInstance(typeStr);

                var view = obj as Window;
                view.ShowDialog();
            }
            catch (Exception ex)
            {
                log = new LogRecordModel()
                {
                    Content = ex.Message,
                    Type = LogType.Failed
                };
            }
            finally
            {
                GlobalValues.Log(log);
            }
        }

        private RelayCommand<object> _myCommand4;
        /// <summary>
        /// 切换页面 的命令
        /// </summary>
        public RelayCommand<object> SwitchContentCommand
        {
            get
            {
                return _myCommand4 ?? (_myCommand4 = new RelayCommand<object>(SwitchContent));
            }
        }
        private void SwitchContent(object param)
        {
            LogRecordModel log = null;
            try
            {
                //还未选择工程文件时
                if (string.IsNullOrEmpty(GlobalValues.CurrentProjectPath))
                {
                    throw new Exception("未新建或选择工程");
                }

                var typeStr = "pilot.SCADA.Views." + param.ToString();
                Type type = Type.GetType(typeStr);

                if (type == null)
                    return;

                ConstructorInfo cti = type.GetConstructor(Type.EmptyTypes);
                MainDispContent = (FrameworkElement)cti.Invoke(null);
            }
            catch (Exception ex)
            {
                log = new LogRecordModel()
                {
                    Content = ex.Message,
                    Type = LogType.Failed
                };
            }
            finally
            {
                GlobalValues.Log(log);
            }
        }

        private RelayCommand<object> _myCommand5;
        /// <summary>
        /// 开始读取 的命令
        /// </summary>
        public RelayCommand<object> StartReadCommand
        {
            get
            {
                return _myCommand5 ?? (_myCommand5 = new RelayCommand<object>(StartRead));
            }
        }
        private void StartRead(object param)
        {
            LogRecordModel log = null;

            try
            {
                //还未选择工程文件时
                if (string.IsNullOrEmpty(GlobalValues.CurrentProjectPath))
                {
                    throw new Exception("未新建或选择工程");
                }

                //发送messenger通知modbusviewmodel开始读取
                Messenger.Default.Send<object>(null, "StartModbusReadToken");
            }
            catch (Exception ex)
            {
                log = new LogRecordModel()
                {
                    Content = ex.ToString(),
                    Type = LogType.Failed
                };
            }
            finally
            {
                GlobalValues.Log(log);
            }
        }

        private RelayCommand<object> _myCommand6;
        /// <summary>
        /// 停止读取 的命令
        /// </summary>
        public RelayCommand<object> StopReadCommand
        {
            get
            {
                return _myCommand6 ?? (_myCommand6 = new RelayCommand<object>(StopRead));
            }
        }
        private void StopRead(object param)
        {
            LogRecordModel log = null;

            try
            {
                //还未选择工程文件时
                if (string.IsNullOrEmpty(GlobalValues.CurrentProjectPath))
                {
                    throw new Exception("未新建或选择工程");
                }

                //发送messenger通知modbusviewmodel停止读取
                Messenger.Default.Send<object>(null, "StopModbusReadToken");
            }
            catch (Exception ex)
            {
                log = new LogRecordModel()
                {
                    Content = ex.ToString(),
                    Type = LogType.Failed
                };
            }
            finally
            {
                GlobalValues.Log(log);
            }
        }

        private RelayCommand<object> _myCommand7;
        /// <summary>
        /// 新建工程 的命令
        /// </summary>
        public RelayCommand<object> NewProjectCommand
        {
            get
            {
                return _myCommand7 ?? (_myCommand7 = new RelayCommand<object>(NewProject));
            }
        }
        private void NewProject(object param)
        {
            LogRecordModel log = null;
            try
            {
                if (!string.IsNullOrEmpty(GlobalValues.CurrentProjectPath))//已经设置好当前系统实例的工程
                {
                    System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);//重开一个实例
                    log.Content = "已打开一个工程，将新建一软件实例";
                    log.Type = LogType.Nornal;
                    return;
                }

                new NewProjectView().ShowDialog();
            }
            catch (Exception ex)
            {
                log = new LogRecordModel()
                {
                    Content = ex.Message,
                    Type = LogType.Failed
                };
            }
            finally
            {
                GlobalValues.Log(log);
            }
        }

        private RelayCommand<object> _myCommand10;
        /// <summary>
        /// 打开工程 的命令
        /// </summary>
        public RelayCommand<object> OpenProjectCommand
        {
            get
            {
                return _myCommand10 ?? (_myCommand10 = new RelayCommand<object>(OpenProject));
            }
        }
        private void OpenProject(object param)
        {
            LogRecordModel log = null;
            try
            {
                Messenger.Default.Send<object>(null, "OpenProjectToken");
            }
            catch (Exception ex)
            {
                log = new LogRecordModel()
                {
                    Content = ex.Message,
                    Type = LogType.Failed
                };
            }
            finally
            {
                GlobalValues.Log(log);
            }
        }

        private RelayCommand<object> _myCommand8;
        /// <summary>
        /// 保存工程文件 的命令
        /// </summary>
        public RelayCommand<object> SaveProjectCommand
        {
            get
            {
                return _myCommand8 ?? (_myCommand8 = new RelayCommand<object>(SaveProject));
            }
        }
        private void SaveProject(object param)
        {
            //LoggerRecordViewModel.GetInstance().Record(new Models.LogRecordModel()
            //{
            //    RecordTime = DateTime.Now.ToString(),
            //    Content = "保存成功",
            //    Identity = Registrant.Name ?? "未登录",
            //    Type = "成功"
            //});
        }

        private RelayCommand<object> _myCommand9;
        /// <summary>
        /// 重启 的命令
        /// </summary>
        public RelayCommand<object> RestartCommand
        {
            get
            {
                return _myCommand9 ?? (_myCommand9 = new RelayCommand<object>(Restart));
            }
        }
        private void Restart(object param)
        {
            LogRecordModel log = null;
            try
            {
                log = new LogRecordModel()
                {
                    Content = "退出系统",
                    Type = LogType.Nornal
                };

                Application.Current.Shutdown();//关闭程序
                System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);//重启软件
            }
            catch (Exception ex)
            {
                log = new LogRecordModel()
                {
                    Content = ex.Message,
                    Type = LogType.Failed
                };
            }
            finally
            {
                GlobalValues.Log(log);
            }
        }


        #endregion
    }
}
