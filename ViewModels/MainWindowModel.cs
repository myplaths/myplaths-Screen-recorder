using Accord.Video;
using MyPlathsRecordingSoftware.Commands;
using MyPlathsRecordingSoftware;
using MyPlathsRecordingSoftware.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using MyPlathsRecordingSoftware.Dialog;

namespace MyPlathsRecordingSoftware.ViewModels
{
    public class MainWindowModel : BaseViewModel
    {
        public ICommand SetResolutionCommand { get; set; }
        private readonly IDialogService _dialogService;

        public MainWindowModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            SetResolutionCommand = new DelegateCommand(SetResolution);
        }

        private void SetResolution()
        {
            var viewModel = new RecordWindowModel();
            bool? result = _dialogService.ShowDialog(viewModel);
            if(result.HasValue)
            {
                if(result.Value)
                {
                    Console.WriteLine("width" + viewModel.Width);
                    Console.WriteLine("height" + viewModel.Height);
                    Console.WriteLine("result has value" + result.Value);
                }
                else
                {
                    Console.WriteLine("result do not have value" + result.Value);
                }
            }
        }


    }




}
