using System;
using Xamarin.Forms;

namespace MeetupApp.Behaviors
{
    public class EventToCommandBehavior : Prism.Behaviors.EventToCommandBehavior
    {
        protected override void OnEventRaised(object sender, EventArgs eventArgs)
        {
            if (sender is ListView listView)
                listView.SelectedItem = null;
            
            base.OnEventRaised(sender, eventArgs);
        }
    }
}
