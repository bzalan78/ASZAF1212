using ASZAF.Models;
using ASZAF.Services;
using eKreta.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ASZAF.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlUsers.xaml
    /// </summary>
    public partial class UserControlUsers : UserControl
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();
        private User selectedUser;

        internal event Action<User, string> AddRequested;
        internal event Action<User, string> UpdateRequested;
        internal event Action<User> DeleteRequested;

        public UserControlUsers()
        {
            InitializeComponent();

            roleText.ItemsSource = new[] { "Admin", "User", "Guest" };

            datagridUsers.ItemsSource = users;

            ResetButtons();
        }

        private void AdatbazisLekerdezes()
        {
            // elemek 0-ra...
            var felhasznaloRepo = new GenericRepository<User>(App.databasePath);
            var lekerdezes = felhasznaloRepo.GetAll();
            datagridUsers.ItemsSource = lekerdezes;

            //Gombok visszaállítása: 
            mentesBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Hidden;
            torlesBtn.Visibility = Visibility.Hidden;
        }

        public void SetRoles(System.Collections.Generic.IEnumerable<string> roles)
        {
            roleText.ItemsSource = roles?.ToArray() ?? Array.Empty<string>();
        }

        private void ResetButtons()
        {
            mentesBtn.Visibility = Visibility.Visible;
            modBtn.Visibility = Visibility.Collapsed;
            torlesBtn.Visibility = Visibility.Collapsed;
        }

        private void ClearInputs()
        {
            usernameText.Text = string.Empty;
            emailText.Text = string.Empty;
            firstNameText.Text = string.Empty;
            lastNameText.Text = string.Empty;
            roleText.Text = string.Empty;
            passwordText.Password = string.Empty;
        }

        private void datagridFelhasznalok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (datagridUsers.SelectedItem is User user)
            {
                selectedUser = user;

                usernameText.Text = user.Username;
                emailText.Text = user.Email;
                firstNameText.Text = user.FirstName;
                lastNameText.Text = user.LastName;
                roleText.Text = user.Role;

                passwordText.Password = string.Empty;

                mentesBtn.Visibility = Visibility.Collapsed;
                modBtn.Visibility = Visibility.Visible;
                torlesBtn.Visibility = Visibility.Visible;
            }
            else
            {
                selectedUser = null;
                ClearInputs();
                ResetButtons();
            }
        }

        private void mentesBtn_Click(object sender, RoutedEventArgs e)
        {
            //szerepkör
            string kivalasztottSzerepkorNev = (string)roleText.SelectedItem;
            Szerepkor kivalasztottSzerepkor = (Szerepkor)Enum.Parse(typeof(Szerepkor), kivalasztottSzerepkorNev);
            int kivalasztottSzerepkorId = (int)kivalasztottSzerepkor;

            //Felhasználó objektum összeállítása
            User ujFelhasznalo = new User(usernameText.Text,
                fullname.Text, PasswordHelper.HashPassword(passwordText.Password), kivalasztottSzerepkorId);

            //Adat insert...
            var felhasznaloRepo = new GenericRepository<User>(App.databasePath);
            felhasznaloRepo.Insert(ujFelhasznalo);
            //datagrid frissítés... 
            AdatbazisLekerdezes();


        }

        private void torlesBtn_Click(object sender, RoutedEventArgs e)
        {
            var felhasznaloRepo = new GenericRepository<User>(App.databasePath);
            felhasznaloRepo.Delete(selectedUser);
            AdatbazisLekerdezes();
        }

        private void ModBtn_Click(object sender, RoutedEventArgs e, Szerepkor kivalasztottSzerepkor, Szerepkor kivalasztottSzerepkor)
        {
            selectedUser.Username = usernameText.Text;
            
            string kivalasztottSzerepkorNev = (string)roleText.SelectedItem;
            Szerepkor kivalasztottSzerepkor = (Szerepkor)Enum.Parse(typeof(Szerepkor), kivalasztottSzerepkorNev);
            selectedUser.Role = (int)kivalasztottSzerepkor;

            if (jelszoText.Password != "")
            {
                kivalasztottFelhasznalo.Jelszo = PasswordHelper.HashPassword(jelszoText.Password); // TODO: jelszó kódolás
            }

            var felhasznaloRepo = new GenericRepository<Felhasznalo>(App.databasePath);
            felhasznaloRepo.Update(kivalasztottFelhasznalo);

            AdatbazisLekerdezes();
        }

    }
}
