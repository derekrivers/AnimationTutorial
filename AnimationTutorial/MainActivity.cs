using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using Android.Views.InputMethods;
using Android.Views.Animations;

namespace AnimationTutorial
{
    [Activity(Label = "AnimationTutorial", MainLauncher = true, Icon = "@drawable/xs")]
    public class MainActivity : Activity
    {
        private List<Friend> mFriends;
        private ListView mListView;
        private EditText mSearch;
        private LinearLayout mContainer;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mListView = FindViewById<ListView>(Resource.Id.listView);
            mSearch = FindViewById<EditText>(Resource.Id.etSearch);
            mContainer = FindViewById<LinearLayout>(Resource.Id.llContainer);

            mSearch.Alpha = 0;


            mFriends = new List<Friend>();
            mFriends.Add(new Friend { FirstName = "Bob", LastName = "Smith", Age = "33", Gender = "Male" });
            mFriends.Add(new Friend { FirstName = "Tom", LastName = "Smith", Age = "45", Gender = "Male" });
            mFriends.Add(new Friend { FirstName = "Julie", LastName = "Smith", Age = "2020", Gender = "Unknown" });
            mFriends.Add(new Friend { FirstName = "Molly", LastName = "Smith", Age = "21", Gender = "Female" });
            mFriends.Add(new Friend { FirstName = "Joe", LastName = "Lopez", Age = "22", Gender = "Male" });
            mFriends.Add(new Friend { FirstName = "Ruth", LastName = "White", Age = "81", Gender = "Female" });
            mFriends.Add(new Friend { FirstName = "Sally", LastName = "Johnson", Age = "54", Gender = "Female" });

            FriendsAdapter adapter = new FriendsAdapter(this, Resource.Layout.row_friend, mFriends);
            mListView.Adapter = adapter;
        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar, menu);

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.search:
          
                        MyAnimation anim = new MyAnimation(mListView, mListView.Height - mSearch.Height);
                        anim.Duration = 500;
                        mListView.StartAnimation(anim);
                        anim.AnimationStart += Anim_AnimationStartDown;
                        mContainer.Animate().TranslationYBy(-mSearch.Height).SetDuration(500).Start();
                        return true;
                    
                   
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }


        private void Anim_AnimationStartDown(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

