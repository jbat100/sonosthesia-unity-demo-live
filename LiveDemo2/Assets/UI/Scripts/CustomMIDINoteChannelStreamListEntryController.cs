using Sonosthesia.MIDI;
using UnityEngine.UIElements;

namespace Sonosthesia.UI
{
    public class CustomMIDINoteChannelStreamListEntryController : ISimpleListEntryController<ChannelStreamUIData<MIDINote>>
    {
        private const float BEND_SEMITONES_RANGE = 48f;
        
        private Label _descriptionLabel;
        private ProgressBar _pressureProgressBar;

        public void SetVisualElement(VisualElement visualElement)
        {
            _descriptionLabel = visualElement.Q<Label>("DescriptionLabel");
            _pressureProgressBar = visualElement.Q<ProgressBar>("PressureProgressBar");
        }

        public void SetData(ChannelStreamUIData<MIDINote>? data)
        {
            if (data.HasValue)
            {
                MIDINote note = data.Value.Data;
                _descriptionLabel.text = $"Chan {note.Channel}, Note {note.Note}, Vel {note.Velocity}";
                _pressureProgressBar.value = note.Pressure;
            }
        }
    }
}