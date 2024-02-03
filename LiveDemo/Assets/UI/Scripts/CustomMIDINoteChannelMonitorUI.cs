using Sonosthesia.MIDI;

namespace Sonosthesia.UI
{
    public class CustomMIDINoteChannelMonitorUI : CustomChannelMonitorUI<MIDINote, CustomMIDINoteChannelStreamListEntryController>
    {
        protected override float ItemHeight => 90;
    }
}