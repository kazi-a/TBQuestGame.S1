using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TBQuestGame.Models;

namespace TBQuestGame.PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerSetupView.xaml
    /// </summary>
    public partial class PlayerSetupView : Window
    {
        private Player _player;

        public PlayerSetupView(Player player)
        {
            _player = player;

            InitializeComponent();

            SetupWindow();
        }

        private void SetupWindow()
        {
            //
            // generate lists for each enum to use in the combo boxes
            //
            List<string> races = Enum.GetNames(typeof(Player.RaceType)).ToList();
            List<string> jobTitles = Enum.GetNames(typeof(Player.JobTitleName)).ToList();
            JobTitleComboBox.ItemsSource = jobTitles;
            RaceComboBox.ItemsSource = races;

            //
            // hide error message box initially
            //
            ErrorMessageTextBlock.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// event handler for the OK button
        /// </summary>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;
            
            if (IsValidInput(out errorMessage))
            {
                //
                // get values from combo boxes
                //
                Enum.TryParse(JobTitleComboBox.SelectionBoxItem.ToString(), out Player.JobTitleName jobTitle);
                Enum.TryParse(RaceComboBox.SelectionBoxItem.ToString(), out Player.RaceType race);

                //
                // set player properties
                //
                _player.JobTitle = jobTitle;
                _player.Type = race;

                Visibility = Visibility.Hidden;
            }
            else
            {
                //
                // display error messages
                //
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                ErrorMessageTextBlock.Text = errorMessage;
            }
        }

        /// <summary>
        /// validate user input and generate appropriate error messages
        /// </summary>
        /// <param name="errorMessage">user feedback</param>
        /// <returns>is user input valid</returns>
        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";

            if (NameTextBox.Text == "")
            {
                errorMessage += "Player Name is required.\n";
            }
            else
            {
                _player.Name = NameTextBox.Text;
            }
            if (!int.TryParse(AgeTextBox.Text, out int age))
            {
                errorMessage += "Player Age is required and must be an integer.\n";
            }
            else
            {
                _player.Age = age;
            }

            return errorMessage == "" ? true : false;
        }
    }
}
