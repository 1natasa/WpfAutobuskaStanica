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
using System.Data;
using System.Data.SqlClient;
namespace WpfAutobuskaStanica.Forme
{
    /// <summary>
    /// Interaction logic for Korisnik.xaml
    /// </summary>
    public partial class frmKorisnik : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmKorisnik()
        {
            InitializeComponent();
            txtImeKorisnik.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                if (MainWindow.azuriraj)
                {

                    DataRowView red = (DataRowView)MainWindow.pomocni;

                    string update = @"Update Korisnik
                                        set ime='" + txtImeKorisnik.Text + "', prezime='" + txtPrezimeKorisnik.Text + "' , jmbg='" + txtJmbgKorisnik.Text + "', kontakt='" + txtKontaktKorisnik.Text + "', adresa='" + txtAdresaKorisnik.Text + "', grad='"+ txtgGradKorisnik.Text+"' where korisnikID = " + red["korisnikID"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();
                }
                else
                {
                   // konekcija.Open();
                    string insert = @"insert into Korisnik(ime,prezime,jmbg,kontakt,adresa,grad)
                values('" + txtImeKorisnik.Text + "','" + txtPrezimeKorisnik.Text + "','" + txtJmbgKorisnik.Text + "','" + txtKontaktKorisnik.Text + "','" + txtAdresaKorisnik.Text + "','" + txtgGradKorisnik.Text + "');"; //@ se stavlja da on gleda kao string, a ako nema @ smatrao bi da je to folder
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    this.Close(); //ovo zatvara formu
                }
                
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih podataka nije validan", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
