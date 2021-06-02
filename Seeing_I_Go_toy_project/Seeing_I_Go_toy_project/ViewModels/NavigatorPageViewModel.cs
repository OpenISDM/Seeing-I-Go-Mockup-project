using System;
using System.Collections.Generic;
using System.Text;
using MvvmHelpers;
using Xamarin.Forms;
using Seeing_I_Go_toy_project.Resources;
using System.Windows.Input;
using Seeing_I_Go_toy_project.Helpers;
using System.Globalization;
namespace Seeing_I_Go_toy_project.ViewModels
{
    public class NavigatorPageViewModel : BaseViewModel
    {
        private int _currentStep = -1;

        public ICommand _nextStepCommand { private set; get; }
        public ICommand _prevStepCommand { private set; get; }
        public ICommand _changeLocaleCommand { private set; get; }

        public NavigatorPageViewModel()
        {
            _nextStepCommand = new Command(() => NextButton_ClickedCommand());
            _prevStepCommand = new Command(() => PreButton_ClickedCommand());
            _changeLocaleCommand = new Command(() => LocaleButton_ClickCommand());
            InitialInstruction();
        }

        public void InitialInstruction()
        {
           // DestinationWaypointName = AppResources.DESTINATION1_STRING;//destinationWaypointName;
            CurrentStepImage = "waittingscan.gif";
            IsAnimated = true;
            IsFinished = false;
            IsArrowImgVisible = true;
            FirstDirectionPicture = "";
            ProgressRatio = 0;
            ProgressText = "0/0";
            CurrentStepLabel = AppResources.NO_SIGNAL_STRING;
            CurrentWaypointName = AppResources.NULL_STRING;
            InstructionLabVerticalOption = LayoutOptions.CenterAndExpand;
            SetDefaultLayout();
        }
        private void SetInstruction(int Step)
        {
            if (Step >= -1 && Step <= 5) _currentStep = Step;
            DestinationWaypointName = AppResources.DESTINATION1_STRING;
            switch (Step)
            {
                case -1:
                    InitialInstruction();
                    break;
                case 0:  //show initial direction picture.
                    IsAnimated = false;
                    CurrentStepLabel = AppResources.PLEASE_FOLLOW_PICTURE_STRING;
                    CurrentWaypointName = "大廳門口";
                    FirstDirectionPicture = "CCH22201816.png";
                    IsArrowImgVisible = false;
                    ProgressRatio = 16;
                    ProgressText = "1/6";
                    SetPicturesLayout();
                    break;
                case 1:  //show go straight
                    IsAnimated = false;
                    CurrentStepLabel = "請繼續向前走，您會看到左手邊有服務櫃台，右手邊是手扶梯";
                    CurrentWaypointName = "大廳";
                    FirstDirectionPicture = "";
                    IsArrowImgVisible = true;
                    CurrentStepImage = "Arrow_up.png";
                    ProgressRatio = 33;
                    ProgressText = "2/6";
                    SetDefaultLayout();
                    break;
                case 2:  // show take elevator
                    IsAnimated = false;
                    CurrentStepLabel = "請搭乘手扶梯上樓到2樓";
                    CurrentWaypointName = "1F手扶梯旁通道";
                    CurrentStepImage = "Escalator_up.png";
                    IsArrowImgVisible = true;
                    ProgressRatio = 50;
                    ProgressText = "3/6";
                    SetDefaultLayout();
                    break;
                case 3:  // show take elevator then turn right
                    IsAnimated = false;
                    CurrentStepLabel = "搭乘手扶梯到達2樓後，請向右轉走約10公尺";
                    CurrentWaypointName = "一樓手扶梯";
                    CurrentStepImage = "Escalator_up.png";
                    IsArrowImgVisible = true;
                    ProgressRatio = 66;
                    ProgressText = "4/6";
                    SetDefaultLayout();
                    break;
                case 4: // show turn right
                    IsAnimated = false;
                    CurrentStepLabel = "請向右轉，你會看到目的地1就您的左前方";
                    CurrentWaypointName = "二樓手扶梯";
                    IsArrowImgVisible = true;
                    CurrentStepImage = "Arrow_right.png";
                    ProgressRatio = 83;
                    ProgressText = "5/6";
                    IsFinished = false;
                    SetDefaultLayout();
                    break;
                case 5:  //Arrived at destination
                    IsAnimated = false;
                    CurrentStepLabel = AppResources.DIRECTION_ARRIVED_STRING;
                    CurrentStepImage = "Arrived.png";
                    IsArrowImgVisible = true;
                    IsFinished = true;
                    ProgressRatio = 100;
                    ProgressText = "6/6";
                    SetDefaultLayout();
                    break;
            }
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
        }
        private void PreButton_ClickedCommand()
        {
            SetInstruction(_currentStep - 1);
        }

        private void LocaleButton_ClickCommand()
        {
            Console.WriteLine(">>LocaleButton Clicked.");

            string currentInfoName = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            switch(currentInfoName)
            {
                case "zh":
                    LocalizationResourceManager.Instance.SetCulture(new CultureInfo("en"));
                    break;
                case "en":
                    LocalizationResourceManager.Instance.SetCulture(new CultureInfo("zh-TW"));
                    break;
                default:
                    break;
            }
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

        private string _firstDirectionPicture;
        public string FirstDirectionPicture
        {
            get => _firstDirectionPicture;
            set => SetProperty(ref _firstDirectionPicture, value);
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

        private bool _isFinished;
        public bool IsFinished
        {
            get => _isFinished;
            set => SetProperty(ref _isFinished, value);
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


        #endregion
    }
}
