using Sonosthesia.MIDI;

namespace Sonosthesia.UI
{
    public class CustomMPENoteChannelMonitorUI : CustomChannelMonitorUI<MPENote, CustomMPENoteChannelStreamListEntryController>
    {
        protected override float ItemHeight => 180;
    }
}