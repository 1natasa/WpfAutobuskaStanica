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
    /// Interaction logic for Kupac.xaml
    /// </summary>
    public partial class frmKupac : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmKupac()
        {
            InitializeComponent();
            txtImeKupac.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                konekcija.Open();
                string insert = @"insert into KupacKarte(popust,ime,prezime,jmbg,kontakt,adresa,grad)
                values(" + txtPopust.Text + ",'" + txtImeKupac.Text + "','" + txtPrezimeKupac.Text + "','" + txtJmbgKupac.Text + "','" + txtKontaktKupac.Text + "','" + txtAdresaKupac.Text + "','" + txtgGradKupac.Text + "');"; //@ se stavlja da on gleda kao string, a ako nema @ smatrao bi da je to folder
                SqlCommand cmd = new SqlCommand(insert, konekcija);
                cmd.ExecuteNonQuery();
                this.Close(); //ovo zatvara formu
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
