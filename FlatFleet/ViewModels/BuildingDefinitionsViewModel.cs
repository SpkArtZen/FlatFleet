using System.Windows.Input;

namespace FlatFleet.ViewModels
{
    public class BuildingDefinitionsViewModel : ViewModelBase
    {
        public ICommand SubmitCommand { get; }
        public ICommand FloorDefinitionCommand { get; }
        private Color _frameColor = Colors.Gray; 
        
        public Color FrameColor
        {
            get { return _frameColor; }
            set 
            { 
                _frameColor = value; 
                OnPropertyChanged(nameof(FrameColor));
            }
        }

        private bool isFrameEmpty = true;

        public bool IsFrameEmpty
        {
            get { return isFrameEmpty; }
            set { isFrameEmpty = value; }
        }

        public BuildingDefinitionsViewModel()
        {
            SubmitCommand = new Command(Submit);
            FloorDefinitionCommand = new Command(GoToFloorDefinition);
        }

        private async void Submit()
        {
            // TODO: Remove comments after adding IsFrameEmpty logic 
            /* if (IsFrameEmpty) 
            {
                FrameColor = Colors.Red;
            }
            else { } */
            await Shell.Current.GoToAsync("StatusCheck");
        }

        private async void GoToFloorDefinition()
        {
            await Shell.Current.GoToAsync("FloorDefinition");
        }
    }
}
