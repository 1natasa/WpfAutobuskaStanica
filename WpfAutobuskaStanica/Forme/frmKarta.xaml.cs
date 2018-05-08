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
    /// Interaction logic for frmKarta.xaml
    /// </summary>
    public partial class frmKarta : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmKarta()
        {
            InitializeComponent();
            txtBrKarte.Focus();
            //txtVrstaKarte.Focus();

            try
            {
                
                //cbxRelacija
                //komentar
                konekcija.Open();
                string vratiRelaciju = "select relacijaID, pocetnaStanica + ' ' + krajnjaStanica as Relacija, peron, cena  from Relacija";
                DataTable dtRelacija = new DataTable();
                SqlDataAdapter daKarta = new SqlDataAdapter(vratiRelaciju, konekcija);
                daKarta.Fill(dtRelacija);
                cbxRelacija.ItemsSource = dtRelacija.DefaultView;

                //cbxKorisnik
                string vratiKorisnika = "select korisnikID, ime + ' ' + prezime + ' ' + jmbg + ' ' + kontakt as Korisnik from Korisnik";
                DataTable dtKorisnik = new DataTable();
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnika, konekcija);
                daKorisnik.Fill(dtKorisnik);
                cbxKorisnik.ItemsSource = dtKorisnik.DefaultView;

                //cbxKupacKarte
                string vratiKupca = "select kupacKarteID, ime+ ' ' + prezime as Kupac, popust from kupacKarte";
                DataTable dtKupac = new DataTable();
                SqlDataAdapter daKupac = new SqlDataAdapter(vratiKupca,konekcija);
                daKupac.Fill(dtKupac);
                cbxKupacKarte.ItemsSource = dtKupac.DefaultView;





            }
            
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //.Text stavimo kad imamo broj
                //
                konekcija.Open();
                string insert = @"insert into Karta(brKarte,vrsta,relacijaID,korisnikID,kupacKarteID)
                values(" + txtBrKarte.Text + ",'" + txtVrstaKarte.Text + "','" + cbxRelacija.SelectedValue + "','" + cbxKorisnik.SelectedValue + "','" + cbxKupacKarte.SelectedValue + "');"; //@ se stavlja da on gleda kao string, a ako nema @ smatrao bi da je to folder
                SqlCommand cmd = new SqlCommand(insert,konekcija);
                cmd.ExecuteNonQuery();
                this.Close(); //ovo zatvara formu
            }
            catch(SqlException)
            {
                MessageBox.Show("Unos odredjenih podataka nije validan", "Greska",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            finally {

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
