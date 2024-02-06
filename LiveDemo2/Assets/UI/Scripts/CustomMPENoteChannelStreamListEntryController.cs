using Sonosthesia.MIDI;
using UnityEngine.UIElements;

namespace Sonosthesia.UI
{
    public class CustomMPENoteChannelStreamListEntryController : ISimpleListEntryController<ChannelStreamUIData<MPENote>>
    {
        private const float BEND_SEMITONES_RANGE = 48f;
        
        private Label _descriptionLabel;
        private ProgressBar _slideProgressBar;
        private ProgressBar _pressureProgressBar;
        private ProgressBar _bendProgressBar;

        public void SetVisualElement(VisualElement visualElement)
        {
            _descriptionLabel = visualElement.Q<Label>("DescriptionLabel");
            _slideProgressBar = visualElement.Q<ProgressBar>("SlideProgressBar");
            _pressureProgressBar = visualElement.Q<ProgressBar>("PressureProgressBar");
            _bendProgressBar = visualElement.Q<ProgressBar>("BendProgressBar");
        }

        public void SetData(ChannelStreamUIData<MPENote>? data)
        {
            if (data.HasValue)
            {
                MPENote note = data.Value.Data;
                _descriptionLabel.text = $"Note {note.Note}, Velocity {note.Velocity}";
                _slideProgressBar.value = note.Slide;
                _pressureProgressBar.value = note.Pressure;
                _bendProgressBar.value = note.Bend + BEND_SEMITONES_RANGE;
            }
        }
    }
}