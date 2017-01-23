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
using System.Linq;

namespace AnimationTutorial
{
    [Activity(Label = "AnimationTutorial", MainLauncher = true, Icon = "@drawable/xs")]
    public class MainActivity : Activity
    {
        private List<Friend> mFriends;
        private ListView mListView;
        private EditText mSearch;
        private LinearLayout mContainer;
        private bool mAnimatedDown;
        private bool mIsAnimating;
        private FriendsAdapter mAdapter;

        private TextView mTxtHeaderFirstName;
        private TextView mTxtHeaderLastName;
        private TextView mTxtHeaderAge;
        private TextView mTxtHeaderGender;

        private bool mFirstNameOrderAsc;
        private bool mlastNameOrderAsc;
        private bool mAgeOrderAsc;
        private bool mGenderNameOrderAsc;



        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            mListView = FindViewById<ListView>(Resource.Id.listView);
            mSearch = FindViewById<EditText>(Resource.Id.etSearch);
            mContainer = FindViewById<LinearLayout>(Resource.Id.llContainer);

            mTxtHeaderFirstName = FindViewById<TextView>(Resource.Id.txtHeaderFirstName);
            mTxtHeaderLastName = FindViewById<TextView>(Resource.Id.txtHeaderLastName);
            mTxtHeaderAge = FindViewById<TextView>(Resource.Id.txtHeaderAge);
            mTxtHeaderGender = FindViewById<TextView>(Resource.Id.txtHeaderGender);

            mTxtHeaderFirstName.Click += MTxtHeaderFirstName_Click;
            mTxtHeaderLastName.Click += MTxtHeaderLastName_Click;
            mTxtHeaderAge.Click += MTxtHeaderAge_Click;
            mTxtHeaderGender.Click += MTxtHeaderGender_Click;

            mSearch.Alpha = 0; //Make it invisible (values between 0 through 1).
            mContainer.BringToFront();

            mSearch.TextChanged += MSearch_TextChanged;


            mFriends = new List<Friend>();
            mFriends.Add(new Friend { FirstName = "Bob", LastName = "Smith", Age = "33", Gender = "Male" });
            mFriends.Add(new Friend { FirstName = "Tom", LastName = "Smith", Age = "45", Gender = "Male" });
            mFriends.Add(new Friend { FirstName = "Julie", LastName = "Smith", Age = "2020", Gender = "Unknown" });
            mFriends.Add(new Friend { FirstName = "Molly", LastName = "Smith", Age = "21", Gender = "Female" });
            mFriends.Add(new Friend { FirstName = "Joe", LastName = "Lopez", Age = "22", Gender = "Male" });
            mFriends.Add(new Friend { FirstName = "Ruth", LastName = "White", Age = "81", Gender = "Female" });
            mFriends.Add(new Friend { FirstName = "Sally", LastName = "Johnson", Age = "54", Gender = "Female" });

            mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, mFriends);
            mListView.Adapter = mAdapter;
        }

        private void MTxtHeaderGender_Click(object sender, EventArgs e)
        {
            List<Friend> filteredFriends;

            if (!mFirstNameOrderAsc)
            {
                filteredFriends = mFriends.OrderBy(x => x.Gender).ToList<Friend>();

                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filteredFriends);

                mListView.Adapter = mAdapter;
            }
            else
            {
                filteredFriends = mFriends.OrderByDescending(x => x.Gender).ToList<Friend>();

                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filteredFriends);

                mListView.Adapter = mAdapter;
            }

            mGenderNameOrderAsc = !mGenderNameOrderAsc;
        }

        private void MTxtHeaderAge_Click(object sender, EventArgs e)
        {
            List<Friend> filteredFriends;

            if (!mFirstNameOrderAsc)
            {
                filteredFriends = mFriends.OrderBy(x => x.Age).ToList<Friend>();

                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filteredFriends);

                mListView.Adapter = mAdapter;
            }
            else
            {
                filteredFriends = mFriends.OrderByDescending(x => x.Age).ToList<Friend>();

                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filteredFriends);

                mListView.Adapter = mAdapter;
            }

            mAgeOrderAsc = !mAgeOrderAsc;
        }

        private void MTxtHeaderLastName_Click(object sender, EventArgs e)
        {
            List<Friend> filteredFriends;

            if (!mFirstNameOrderAsc)
            {
                filteredFriends = mFriends.OrderBy(x => x.LastName).ToList<Friend>();

                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filteredFriends);

                mListView.Adapter = mAdapter;
            }
            else
            {
                filteredFriends = mFriends.OrderByDescending(x => x.LastName).ToList<Friend>();

                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filteredFriends);

                mListView.Adapter = mAdapter;
            }

            mlastNameOrderAsc = !mlastNameOrderAsc;
        }

        private void MTxtHeaderFirstName_Click(object sender, EventArgs e)
        {
            List<Friend> filteredFriends;

            if (!mFirstNameOrderAsc)
            {
                filteredFriends = mFriends.OrderBy(x => x.FirstName).ToList<Friend>();

                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filteredFriends);

                mListView.Adapter = mAdapter;
            }
            else
            {
                filteredFriends = mFriends.OrderByDescending(x => x.FirstName).ToList<Friend>();

                mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, filteredFriends);

                mListView.Adapter = mAdapter;
            }

            mFirstNameOrderAsc = !mFirstNameOrderAsc;
           
        }

        private void MSearch_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            List<Friend> searchedFriends = mFriends
                .Where(
                    x => x.FirstName.Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase) || 
                    x.LastName.Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase) || 
                    x.Age.Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase) || 
                    x.Gender.Contains(mSearch.Text, StringComparison.OrdinalIgnoreCase)).ToList();

            mAdapter = new FriendsAdapter(this, Resource.Layout.row_friend, searchedFriends);

            mListView.Adapter = mAdapter;
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

                    mSearch.Visibility = ViewStates.Visible;

                    if (mIsAnimating)
                    {
                        return true;
                    }

                    if (!mAnimatedDown)
                    {
                        MyAnimation anim = new MyAnimation(mListView, mListView.Height - mSearch.Height);
                        anim.Duration = 500;
                        mListView.StartAnimation(anim);
                        anim.AnimationStart += Anim_AnimationStartDown;
                        anim.AnimationEnd += Anim_AnimationEndDown;

                        mContainer.Animate().TranslationYBy(mSearch.Height).SetDuration(500).Start();
             
      
                    }
                    else
                    {
                        MyAnimation anim = new MyAnimation(mListView, mListView.Height + mSearch.Height);
                        anim.Duration = 500;
                        mListView.StartAnimation(anim);
                        anim.AnimationStart += Anim_AnimationStartUp;
                        anim.AnimationEnd += Anim_AnimationEndUp;

                        mContainer.Animate().TranslationYBy(-mSearch.Height).SetDuration(500).Start();
                        //ListView is down.
                    }

                    mAnimatedDown = !mAnimatedDown;

                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        private void Anim_AnimationEndUp(object sender, Animation.AnimationEndEventArgs e)
        {
            mIsAnimating = false;
            mSearch.ClearFocus();
            InputMethodManager inputManager = (InputMethodManager)this.GetSystemService(Context.InputMethodService);
            inputManager.HideSoftInputFromWindow(this.CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
        }

        private void Anim_AnimationEndDown(object sender, Animation.AnimationEndEventArgs e)
        {
            mIsAnimating = false;
        }

        private void Anim_AnimationStartDown(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mIsAnimating = true;
            mSearch.Animate().AlphaBy(1.0f).SetDuration(500).Start();
        }

        private void Anim_AnimationStartUp(object sender, Android.Views.Animations.Animation.AnimationStartEventArgs e)
        {
            mIsAnimating = true;
            mSearch.Animate().AlphaBy(-1.0f).SetDuration(300).Start();
        }
    }
}

