using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using System.IO;
using Xamarin.Forms;
using Seeing_I_Go_toy_project.Resources;
namespace Seeing_I_Go_toy_project.ViewModels
{
    public class NavigatorPageViewModel : BaseViewModel
    {
        #region For simulate a route with hard-code.
        private int _currentStep = -1;
        private int _routeLength = 5;
        #endregion
        public NavigatorPageViewModel()
        {
            InitialInstruction();
        }

        public void InitialInstruction()
        {
            DestinationWaypointName = "母雞都壓";//destinationWaypointName;
            CurrentStepImage = "waittingscan.gif";
            IsAnimated = true;
            IsArrowImgVisible = true;
            ProgressRatio = 33;
            ProgressText = "0/0";
            CurrentStepLabel = AppResources.NO_SIGNAL_STRING;
            CurrentWaypointName = AppResources.NULL_STRING;
            InstructionLabVerticalOption = LayoutOptions.CenterAndExpand;
            SetDefaultLayout();
        }
        private void SetInstruction(int Step)
        {

        }

        #region Layout control
        private void SetDefaultLayout()
        {
            FDPictureHeightScaleValue = 2;
            FDPictureHeightSpanValue = 3;
            InstructionWidthScaleValue = 1;
            InstructionWidthSpanValue = 2;
            InstructionLocationValue = 2;
        }
        private void SetPicturesLayout()
        {
            FDPictureHeightScaleValue = 1;
            FDPictureHeightSpanValue = 4;
            InstructionWidthScaleValue = 0;
            InstructionWidthSpanValue = 3;
            InstructionLocationValue = 1;
        }
        #endregion
        private void NextButton_ClickedCommand()
        {
            SetInstruction(_currentStep + 1);
            NextButtonEnabled = true;
        }
        private void PreButton_ClickedCommand() 
        {
            SetInstruction(_currentStep - 1);
            PreButtonEnabled = true;
        }

        #region Data Binding
        private string _currentStepImage;
        public string CurrentStepImage
        {
            get => _currentStepImage;
            set => SetProperty(ref _currentStepImage, value);
        }

        private string _currentWaypointName;
        public string CurrentWaypointName
        {
            get => _currentWaypointName;
            set => SetProperty(ref _currentWaypointName, value);
        }

        private string _currentStepLabel;
        public string CurrentStepLabel
        {
            get => _currentStepLabel;
            set => SetProperty(ref _currentStepLabel, value);
        }

        private string _destinationWaypointName;
        public string DestinationWaypointName
        {
            get => _destinationWaypointName;
            set => SetProperty(ref _destinationWaypointName, value);
        }

        private string _progressText;
        public string ProgressText
        {
            get => _progressText;
            set => SetProperty(ref _progressText, value);
        }
        private bool _isAnimated;
        public bool IsAnimated
        {
            get => _isAnimated;
            set => SetProperty(ref _isAnimated, value);
        }

        private double _progressRatio;
        public double ProgressRatio
        {
            get => _progressRatio;
            set => SetProperty(ref _progressRatio, value);
        }

        #region Layout properties
        private int _fdPictureHeightSpanValue;
        public int FDPictureHeightSpanValue
        {
            get => _fdPictureHeightSpanValue;
            set => SetProperty(ref _fdPictureHeightSpanValue, value);
        }

        private int _fdPictureHeightScaleValue;
        public int FDPictureHeightScaleValue
        {
            get => _fdPictureHeightScaleValue;
            set => SetProperty(ref _fdPictureHeightScaleValue, value);
        }

        private int _instructionWidthSpanValue;
        public int InstructionWidthSpanValue
        {
            get => _instructionWidthSpanValue;
            set => SetProperty(ref _instructionWidthSpanValue, value);
        }

        private LayoutOptions _instructionLabVerticalOption;
        public LayoutOptions InstructionLabVerticalOption
        {
            get => _instructionLabVerticalOption;
            set => SetProperty(ref _instructionLabVerticalOption, value);
        }

        //TODO the attribute name need to be replace in .xaml
        private bool _isArrowImgVisible;
        public bool IsArrowImgVisible
        {
            get => _isArrowImgVisible;
            set => SetProperty(ref _isArrowImgVisible, value);
        }

        private int _instructionWidthScaleValue;
        public int InstructionWidthScaleValue
        {
            get => _instructionWidthScaleValue;
            set => SetProperty(ref _instructionWidthScaleValue, value);

        }

        private int _instructionLocationValue;
        public int InstructionLocationValue
        {
            get => _instructionLocationValue;
            set => SetProperty(ref _instructionLocationValue, value);
        }
        #endregion

        #region Next and Previouse step Button Control 
        private bool _nextButtonEnabled = false;
        public bool NextButtonEnabled
        {
            get => _nextButtonEnabled;
            set => SetProperty(ref _nextButtonEnabled, (_currentStep > 5));
        }

        private bool _preButtonEnabled = true;
        public bool PreButtonEnabled
        {
            get => _preButtonEnabled;
            set => SetProperty(ref _preButtonEnabled, (_currentStep < 0));
        }

        #endregion
        #endregion
    }
}
