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
    /// Interaction logic for frmVozac.xaml
    /// </summary>
    public partial class frmVozac : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmVozac()
        {
            InitializeComponent();
            txtImeVozac.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                if (MainWindow.azuriraj)
                {
                    DataRowView red = (DataRowView)MainWindow.pomocni;

                    string update = @"Update Vozac
                                        set ime='" + txtImeVozac.Text + "', prezime='" + txtPrezimeVozac.Text + "' , jmbg='" + txtJmbgVozac.Text + "', kontakt='" + txtKontaktVozac.Text + "', dozvola='" + txtVozackaDoz.Text + "',adresa='" + txtAdresaVozac.Text + "',grad='" + txtGradVozac.Text + "' where vozacID = " + red["vozacID"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();

                }
                else
                {
                    string insert = @"insert into Vozac(ime,prezime,jmbg,kontakt,dozvola,adresa,grad)
                values('" + txtImeVozac.Text + "','" + txtPrezimeVozac.Text + "','" + txtJmbgVozac.Text + "','" + txtKontaktVozac.Text + "','" + txtVozackaDoz.Text + "','" + txtAdresaVozac.Text + "','" + txtGradVozac.Text + "');"; //@ se stavlja da on gleda kao string, a ako nema @ smatrao bi da je to folder
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
