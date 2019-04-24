namespace CHEJ_XamarinAndroidMySecondApp
{
    using System;
    using Android.App;
    using Android.Graphics;
    using Android.OS;
    using Android.Runtime;
    using Android.Support.V7.App;
    using Android.Widget;

    [Activity(
        Label = "@string/app_name",
        Theme = "@style/AppTheme",
        MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        #region Attributes

        private TextView lblStudentStatus;
        private EditText txtMath;
        private EditText txtPhysical;
        private EditText txtChemistry;

        private Button btnCalculate;
        private Button btnClear;

        #endregion Attributes

        #region Constrtuctor

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            this.InitialData();
        }

        #endregion Constructor

        #region Methods

        private void InitialData()
        {
            this.lblStudentStatus = (TextView)FindViewById(Resource.Id.lblStudentStatus);
            this.txtMath = (EditText)FindViewById(Resource.Id.txtMath);
            this.txtPhysical = (EditText)FindViewById(Resource.Id.txtPhysical);
            this.txtChemistry = (EditText)FindViewById(Resource.Id.txtChemistry);

            this.btnCalculate = (Button)FindViewById(Resource.Id.btnCalculate);
            this.btnClear = (Button)FindViewById(Resource.Id.btnClear);

            this.SetButtonsFuntion();
        }

        private void SetButtonsFuntion()
        {
            this.btnCalculate.Click += delegate
            {
                BtnCalculate_Click(null, null);
            };

            this.btnClear.Click += delegate
            {
                BtnClear_Click(null, null);
            };
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            this.lblStudentStatus.SetTextColor(Color.Gray);
            this.lblStudentStatus.Text = "Student status...!!!";

            this.txtMath.Text = string.Empty;
            this.txtPhysical.Text = string.Empty;
            this.txtChemistry.Text = string.Empty;
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            var mathValue = 
                double.Parse(string.IsNullOrEmpty(this.txtMath.Text) ? "0" : this.txtMath.Text);
            var physicalValue =
                double.Parse(string.IsNullOrEmpty(this.txtPhysical.Text) ? "0" : this.txtPhysical.Text);
            var chemistryValue =
                double.Parse(string.IsNullOrEmpty(this.txtChemistry.Text) ? "0" : this.txtChemistry.Text);

            var average = Math.Round(
                ((mathValue + physicalValue + chemistryValue) / 3), 
                2);

            if (average >= 6)
            {
                this.lblStudentStatus.SetTextColor(Color.Green);
                this.lblStudentStatus.Text = $"Status approved with: {average}";
            }
            else
            {
                this.lblStudentStatus.SetTextColor(Color.Red);
                this.lblStudentStatus.Text = $"Status reprobate with: {average}";
            }
        }

        public override void OnRequestPermissionsResult(
            int requestCode,
            string[] permissions,
            [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        #endregion Methods
    }
}