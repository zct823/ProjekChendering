using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections;
using System.Collections.Generic;

namespace SchoolApps
{
	[Activity(MainLauncher = true, Icon = "@drawable/ic_launcher", Theme = "@style/Theme.Schoolapp")]
	public class MainMenuDrawer : Activity
    {
        private DrawerLayout _drawer;
        private MyActionBarDrawerToggle _drawerToggle;
		private ListView _drawerList;
		private ListView _drawerListCustomed;
		List<LeftMenuDrawerItems> _leftMenuDrawerForDLC = new List<LeftMenuDrawerItems> ();

        private string _drawerTitle;
        private string _title;
		private string[] _menuTitles;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

            _title = _drawerTitle = Title;
			_menuTitles = Resources.GetStringArray(Resource.Array.MenuArrays);
            _drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			_drawerList = FindViewById<ListView>(Resource.Id.left_drawer);

			_drawerList.SetBackgroundResource (Resource.Color.schoolAppsBlueForMenu);
			//_drawerList.SetBackgroundColor (Android.Graphics.Color.White);

            _drawer.SetDrawerShadow(Resource.Drawable.drawer_shadow_dark, (int)GravityFlags.Start);

			_leftMenuDrawerForDLC.Add (new LeftMenuDrawerItems () { LeftMenuDrawerLabel = "Home", LeftMenuDrawerIconID = Resource.Drawable.ic_list_info });
			_leftMenuDrawerForDLC.Add (new LeftMenuDrawerItems () { LeftMenuDrawerLabel = "Messages", LeftMenuDrawerIconID = Resource.Drawable.ic_list_news });
			_leftMenuDrawerForDLC.Add (new LeftMenuDrawerItems () { LeftMenuDrawerLabel = "Profile", LeftMenuDrawerIconID = Resource.Drawable.ic_list_profile });
			_leftMenuDrawerForDLC.Add (new LeftMenuDrawerItems () { LeftMenuDrawerLabel = "School Info", LeftMenuDrawerIconID = Resource.Drawable.ic_list_info });
			_leftMenuDrawerForDLC.Add (new LeftMenuDrawerItems () { LeftMenuDrawerLabel = "Feedback", LeftMenuDrawerIconID = Resource.Drawable.ic_list_feedback });
			_leftMenuDrawerForDLC.Add (new LeftMenuDrawerItems () { LeftMenuDrawerLabel = "Settings", LeftMenuDrawerIconID = Resource.Drawable.ic_list_setting });
            
			//_drawerList.Adapter = new ArrayAdapter<string>(this, Resource.Layout.DrawerListItem, _menuTitles);
			LeftMenuDrawerAdapter lmda = new LeftMenuDrawerAdapter (this, _leftMenuDrawerForDLC);
			View headerView = ((LayoutInflater)GetSystemService (Context.LayoutInflaterService)).Inflate (Resource.Layout.LeftMenuHeaderLayout, null, false);
			_drawerList.AddHeaderView (headerView);
			_drawerList.Adapter = lmda;
			//_drawerList.ItemClick += (sender, args) => SelectItem(args.Position);
			_drawerList.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => ItemSelected (sender, e);
			//_drawerListCustomed.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => ItemSelected (sender, e);

            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetHomeButtonEnabled(true);

            //DrawerToggle is the animation that happens with the indicator next to the
            //ActionBar icon. You can choose not to use this.
            _drawerToggle = new MyActionBarDrawerToggle(this, _drawer,
													Resource.Drawable.ic_drawer_white,
                                                      Resource.String.DrawerOpen,
                                                      Resource.String.DrawerClose);

            //You can alternatively use _drawer.DrawerClosed here
            _drawerToggle.DrawerClosed += delegate
            {
				//ActionBar.Title = _title;
                InvalidateOptionsMenu();
            };

            //You can alternatively use _drawer.DrawerOpened here
            _drawerToggle.DrawerOpened += delegate
            {
				//ActionBar.Title = _drawerTitle;
                InvalidateOptionsMenu();
            };

            _drawer.SetDrawerListener(_drawerToggle);

            if (null == savedInstanceState)
				SelectItem(0);
        }

		private void ItemSelected(object sender, AdapterView.ItemClickEventArgs e)
		{
			//Toast.MakeText (this, ((TextView)e.View).Text, ToastLength.Short).Show ();
			SelectItem (e.Position);
		}

        private void SelectItem(int position)
        {
			Fragment fragmenter = new MainFragment ();

			switch(position){
			case 0:
				ActionBar.Title = "Woodgroove Secondary School";
				break;
			case 1:
				fragmenter = new MainFragment ();
				ActionBar.Title = "Woodgroove Secondary School";
				break;
			case 2:
				fragmenter = new MessagesFragment ();
				ActionBar.Title = "Messages";
				break;
			case 3:
				fragmenter = new ProfileFragment ();
				ActionBar.Title = "Profile";
				break;
			case 4:
				fragmenter = new SchoolInfoFragment ();
				ActionBar.Title = "School Info";
				break;
			case 5:
				fragmenter = new FeedbackFragment ();
				ActionBar.Title = "Feedback";
				break;
			case 6:
				fragmenter = new SettingsFragment ();
				ActionBar.Title = "Settings";
				break;
			default:
				fragmenter = new MainFragment ();
				break;

			}

			//if (position != 0) {
				FragmentManager.BeginTransaction ()
				.Replace (Resource.Id.content_frame, fragmenter)
				.Commit ();
			//}

			_drawerList.SetItemChecked (position, true);
			_drawer.CloseDrawer (_drawerList);
        }


        protected override void OnPostCreate(Bundle savedInstanceState)
        {
            base.OnPostCreate(savedInstanceState);
            _drawerToggle.SyncState();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            _drawerToggle.OnConfigurationChanged(newConfig);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
			//MenuInflater.Inflate(Resource.Menu.main, menu);
			IMenuItem createItem = menu.Add ("Create Message");
			createItem.SetShowAsAction (ShowAsAction.IfRoom);
			createItem.SetOnMenuItemClickListener (new MMDDelegatedMenuItemListener (OnAppearingMessage));
            return base.OnCreateOptionsMenu(menu);
        }

		private bool OnAppearingMessage(IMenuItem menuItem)
		{
			StartActivity (typeof(ComposeMsgActivity));

			return true;
		}

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
			//var drawerOpen = _drawer.IsDrawerOpen (Resource.Id.left_drawer);
			//menu.FindItem(Resource.Id.action_websearch).SetVisible(!drawerOpen);
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (_drawerToggle.OnOptionsItemSelected(item))
                return true;
			/*
            switch (item.ItemId)
            {
                case Resource.Id.action_websearch:
                    {
                        var intent = new Intent(Intent.ActionWebSearch);
                        intent.PutExtra(SearchManager.Query, ActionBar.Title);

                        if ((intent.ResolveActivity(PackageManager)) != null)
                            StartActivity(intent);
                        else
                            Toast.MakeText(this, Resource.String.app_not_available, ToastLength.Long).Show();
                        return true;
                    }
                case Resource.Id.action_slidingpane:
                    {
                        var intent = new Intent(this, typeof(SlidingPaneLayoutActivity));
                        intent.AddFlags(ActivityFlags.ClearTop);
                        StartActivity(intent);
                        return true;
                    }
                default:
                    return base.OnOptionsItemSelected(item);
            }
            */
			return true;
        }
    }
}

