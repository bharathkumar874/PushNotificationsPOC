using Android.App;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Firebase.Iid;

namespace PushNotificationsPOC
{
    [Activity(Label = "PushNotificationsPOC", MainLauncher = true, Icon ="@drawable/notification")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            if (!GetString(Resource.String.google_app_id).Equals("1:800530973596:android:0dd23db5aed7c3cb"))
            {
                throw new System.Exception("invalid json file");
            }

            Task.Run(() =>
            {
                var instaneId = FirebaseInstanceId.Instance;
                instaneId.DeleteInstanceId();
                Android.Util.Log.Debug("TAG", "{0} {1}", instaneId.Token, instaneId.GetToken(GetString(Resource.String.gcm_defaultSenderId), Firebase.Messaging.FirebaseMessaging.InstanceIdScope));

            });
        }
    }
}

