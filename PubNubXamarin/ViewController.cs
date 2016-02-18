using System;
using UIKit;
using PubNubMessaging.Core;

namespace PubNubXamarin
{
    public partial class ViewController : UIViewController
    {
        Pubnub pubnub;
        // Development keys:
        const string PUBLISH_KEY = "demo";
        const string SUBSCRIBE_KEY = "demo";
        const string channel1 = "channel1";
        const string channel2 = "channel2";
        bool subscribedToChannel;

        public ViewController(IntPtr handle)
            : base(handle)
        {
            pubnub = new Pubnub(publishKey: PUBLISH_KEY, subscribeKey: SUBSCRIBE_KEY, secretKey: null, cipherKey: null, sslOn: true);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            subButton.TouchUpInside += SubButton_TouchUpInside;  // Click this first to subscribe to channel1
            button.TouchUpInside += Button_TouchUpInside;  // Then click this to unsub from channel1 and sub to channel2
        }

        void SubButton_TouchUpInside(object sender, EventArgs e)
        {
            Subscribe(channel1);
        }

        void Button_TouchUpInside(object sender, EventArgs e)
        {
            // Unsubsubscribe from previous channel:
            if (subscribedToChannel)
            {
                InvokeInBackground(Unsubscribe);
            }
        }

        void Unsubscribe()
        {
            pubnub.Unsubscribe<string>(channel: channel1, userCallback: UnsubscribeReturnMessage, 
                connectCallback: UnsubscribeConnect, disconnectCallback: UnsubscribeDisconnect,
                errorCallback: DisplayErrorMessage);
        }

        void Subscribe(string channel)
        {
            pubnub.Subscribe<string>(channel: channel, userCallback: MessageReceived, 
                connectCallback: SubscribeConnect, errorCallback: DisplayErrorMessage);
        }

        #region Unsbuscribe callbacks

        void UnsubscribeConnect(string message)
        {
            // This callback is never called
            Console.WriteLine("--> UnsubscribeConnect: " + message);
        }

        void UnsubscribeReturnMessage(string message)
        {
            // This callback is never called
            Console.WriteLine("--> DisplayReturnMessage: " + message);
        }

        void UnsubscribeDisconnect(string message)
        {
            // Unsubscribe from channel1 complete.  Subscribe to channel2.
            Console.WriteLine("--> UnsubscribeDisconnect: " + message);
            Subscribe(channel2);
        }

        #endregion

        void SubscribeConnect(string message)
        {
            // Subscribe complete
            Console.WriteLine("--> SubscribeConnect: " + message);
            subscribedToChannel = true;
        }

        void DisplayErrorMessage(PubnubClientError error)
        {
            Console.WriteLine("--> DisplayErrorMessage: " + error.Description);
        }

        void MessageReceived(string message)
        {
            Console.WriteLine("***--> MessageReceived: " + message);
        }
    }
}
